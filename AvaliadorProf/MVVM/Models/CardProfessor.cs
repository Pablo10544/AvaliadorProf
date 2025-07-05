using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf.MVVM.Models
{
    public class CardProfessor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string caminhoFoto { get; set; }
        public List<string> Disciplinas { get; set; }
        public float NotaDidatica { get; set; }
        public float NotaDificuldadeProva { get; set; }
        public float NotaPlanoEnisno{ get; set; }
        public List<string> Comentarios { get; set; }


    }
}
