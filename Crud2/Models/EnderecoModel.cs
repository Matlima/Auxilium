using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class EnderecoModel
    {
        public int Idendereco { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Cep { get; set; }
        public EstadosModel Estado { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}