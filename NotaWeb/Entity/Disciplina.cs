using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaWeb.Entity
{
    public class Disciplina
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public string Nome { get; set; }

        // Classes Associadas
        public Professor Professor { get; set; }
    }
}