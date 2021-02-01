using CrudWebAPIAspCore.Models;
using CrudWebAPIAspCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudWebAPIAspCore.Controllers
{
    [Route("pacientes")]
    public class PacientesController : Controller
    {
        private readonly IPacienteService service;

        public PacientesController(IPacienteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = service.GetPacientes();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetPacientes")]
        public IActionResult Get(int id)
        {
            var model = service.GetPaciente(id);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PacienteInputModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            var model = ToDomainModel(inputModel);
            service.AddPaciente(model);

            var outputModel = ToOutputModel(model);
            return CreatedAtRoute("GetPacientes", new { id = outputModel.PacienteId }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PacienteInputModel inputModel)
        {
            if (inputModel == null || id != inputModel.PacienteId)
                return BadRequest();

            if (!service.PacienteExists(id))
                return NotFound();

            var model = ToDomainModel(inputModel);
            service.UpdatePaciente(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.PacienteExists(id))
                return NotFound();

            service.DeletePaciente(id);

            return NoContent();
        }


        private PacienteOutputModel ToOutputModel(Paciente model)
        {
            return new PacienteOutputModel
            {
                PacienteId = model.PacienteId,
                Nome = model.Nome,
                Sexo = model.Sexo,
                Convenio = model.Convenio
            };
        }

        private List<PacienteOutputModel> ToOutputModel(List<Paciente> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }

        private Paciente ToDomainModel(PacienteInputModel inputModel)
        {
            return new Paciente
            {
                PacienteId = inputModel.PacienteId,
                Nome = inputModel.Nome,
                Sexo = inputModel.Sexo,
                Convenio = inputModel.Convenio
            };
        }

        private PacienteInputModel ToInputModel(Paciente model)
        {
            return new PacienteInputModel
            {
                PacienteId = model.PacienteId,
                Nome = model.Nome,
                Sexo = model.Sexo,
                Convenio = model.Convenio
            };
        }
    }
}
