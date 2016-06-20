using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardapioDigital.Entity
{
    public class Pessoa
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string dataNasc { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string cargo { get; set; }
    }
}