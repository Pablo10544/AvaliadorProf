using AvaliadorProf.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaliadorProf
{
    public class MainViewService
    {
        private HttpClient _client;
        private Uri base_url = new Uri("http://10.0.2.2:5000");
        const string urlGetCards = "buscar-cards?aluno_id=1&curso=1";
        const string rejeitar = "rejeitar-professor";
        public MainViewService(HttpClient cliente) {
            _client = cliente;
            _client.BaseAddress = base_url;
        }
        public async Task<List<CardProfessor>> GetCards()
        {


           var response = await _client.GetAsync(urlGetCards);
            var teste=await response.Content.ReadAsStringAsync();
            var Card = JsonSerializer.Deserialize<List<CardProfessor>>(teste, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //convert response to object
            return Card;
        }
        public async Task Rejeitar(int professor_id)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("professor_id", professor_id.ToString()),
                new KeyValuePair<string, string>("aluno_id", "1")

            };
            var content = new FormUrlEncodedContent(pairs);
            var response = await _client.PostAsync(rejeitar, content);

        }
    }
}
