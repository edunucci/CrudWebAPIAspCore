using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebAPIAspCore.Models
{
    public class PacienteInputModel
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Convenio { get; set; }
    }
}
