using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class FeedbackModel
    {
        public int Idfeedback { get; set; }
        public string Descricao { get; set; }
        public AulaModel Aula { get; set; }

    }
}