using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class TelefoneModel
    {

        public int idtelefone { get; set; }
        public int telefone { get; set; }
        public UsuarioModel usuario { get; set; }

    }
}