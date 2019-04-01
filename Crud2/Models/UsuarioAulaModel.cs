using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class UsuarioAulaModel
    {
        public int IdUsuarioAula { get; set; }
        public UsuarioModel Usuario { get; set; }
        public AulaModel Aula { get; set; }
    }
}