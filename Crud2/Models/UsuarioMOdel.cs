using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class UsuarioModel
    {
        public int Idusuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuarioModel TipoUsuario { get; set; }
        public EnderecoModel Endereco { get; set; }
        public InstituicaoEnsinoModel InstituicaoEnsino { get; set; }


    }
}