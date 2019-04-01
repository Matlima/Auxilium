using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class AulaModel
    {

        public int Idaula { get; set; }
        public string Disciplina { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string LocalAula { get; set; }
        public DateTime Horario { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Concluida { get; set; }

    }
}