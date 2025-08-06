using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf.Services
{
    public class AvaliacaoEditViewService
    {
        private HttpClient _client;
        private Uri base_url = new Uri(Preferences.Get("back_end_url", ""));
        const string avaliar = "avaliar";
        public AvaliacaoEditViewService(HttpClient cliente)
        {
            _client = cliente;
            _client.BaseAddress = base_url;
        }
        public async Task Avaliar(int didatica,int dificuldadeProva, int planoDeEnsino,string comentario,int professor_id)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("nota1", didatica.ToString()),
                new KeyValuePair<string, string>("nota2", dificuldadeProva.ToString()),
                new KeyValuePair<string, string>("nota3", planoDeEnsino.ToString()),
                new KeyValuePair<string, string>("comentario",comentario),
                new KeyValuePair<string, string>("aluno_id","1"), new KeyValuePair<string, string>("professor_id",professor_id.ToString()),
                new KeyValuePair<string, string>("disciplina_id","1"),

            };
            var content = new FormUrlEncodedContent(pairs);
            var response = await _client.PostAsync(avaliar, content);

        }
    }
}
