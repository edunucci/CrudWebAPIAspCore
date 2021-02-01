using CrudWebAPIAspCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebAPIAspCore.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly List<Paciente> pacientes;

        public PacienteService()
        {
            this.pacientes = new List<Paciente>
            {
                new Paciente { PacienteId = 1, Nome = "Joao API", Sexo = "Masculino", Convenio = "Unimed" },
                new Paciente { PacienteId = 2, Nome = "Jose API", Sexo = "Masculino", Convenio = "Amil" },
                new Paciente { PacienteId = 3, Nome = "Maria API", Sexo = "Feminino", Convenio = "Unimed" }
            };
        }

        public void AddPaciente(Paciente item)
        {
            this.pacientes.Add(item);
        }

        public void DeletePaciente(int id)
        {
            var model = this.pacientes.Where(m => m.PacienteId == id).FirstOrDefault();
            this.pacientes.Remove(model);
        }

        public bool PacienteExists(int id)
        {
            return this.pacientes.Any(m => m.PacienteId == id);
        }

        public Paciente GetPaciente(int id)
        {
            return this.pacientes.Where(m => m.PacienteId == id).FirstOrDefault();
        }

        public List<Paciente> GetPacientes()
        {
            return this.pacientes.ToList();
        }

        public void UpdatePaciente(Paciente item)
        {
            var model = this.pacientes.Where(m => m.PacienteId == item.PacienteId).FirstOrDefault();
            model.PacienteId = item.PacienteId;
            model.Nome = item.Nome;
            model.Sexo = item.Sexo;
            model.Convenio = item.Convenio;
        }

    }
}
