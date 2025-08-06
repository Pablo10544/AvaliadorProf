using AvaliadorProf.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaliadorProf.Services
{
    public class AvaliacaoViewService
    {
        private HttpClient _client;
        private Uri base_url = new Uri(Preferences.Get("back_end_url", ""));
        const string urlGetCards = "buscar-avaliacao";
 

        public AvaliacaoViewService(HttpClient cliente)
        {
            _client = cliente;
            _client.BaseAddress = base_url;
        }

        public async Task<CardProfessor> GetDetail(int id)
        {


            var response = await _client.GetAsync(urlGetCards+"?professor_id="+id);
            var teste = await response.Content.ReadAsStringAsync();
            var Card = JsonSerializer.Deserialize<CardProfessor>(teste, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //convert response to object
            return Card;
        }
    }
}
