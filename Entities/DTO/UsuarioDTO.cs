using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string CorreoElectronico { get; set; }
        public string Usuario { get; set; }
        public string Estatus { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
