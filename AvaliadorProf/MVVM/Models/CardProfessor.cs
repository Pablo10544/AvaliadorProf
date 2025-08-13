using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvaliadorProf.MVVM.Models
{
    public class CardProfessor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string urlFoto { get; set; }
        public List<string> Disciplinas { get; set; }
        public float NotaDidatica { get; set; }
        public float NotaDificuldadeProva { get; set; }
        public float NotaPlanoEnisno{ get; set; }
        public float MediaNotas { get; set; }
        public int TotalAvaliacoes { get; set; }
        public int quantidade_nota_5 { get; set; }
        public int quantidade_nota_4 { get; set; }
        public int quantidade_nota_3 { get; set; }
        public int quantidade_nota_2 { get; set; }
        public int quantidade_nota_1 { get; set; }

        public List<string> Comentarios { get; set; } = new();


    }
}
