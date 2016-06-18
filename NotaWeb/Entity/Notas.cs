using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaWeb.Entity
{
    public class Notas
    {
        public int IdDisciplina { get; set; }
        public int IdAluno { get; set; }
        public decimal Nota { get; set; }

        public string Disciplina { get; set; }
        public string Aluno { get; set; }
    }
}