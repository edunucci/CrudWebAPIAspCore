using CrudWebAPIAspCore.Models;
using System.Collections.Generic;

namespace CrudWebAPIAspCore.Service
{
    public interface IPacienteService
    {
        List<Paciente> GetPacientes();
        Paciente GetPaciente(int id);
        void AddPaciente(Paciente item);
        void UpdatePaciente(Paciente item);
        void DeletePaciente(int id);
        bool PacienteExists(int id);
    }
}
