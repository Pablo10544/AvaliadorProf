using AvaliadorProf.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        const string urlGetIdComentario = "buscar-id-avaliacao";
        const string urlRemoveComentario = "deletar-comentario";



        public AvaliacaoViewService(HttpClient cliente)
        {
            _client = cliente;
            _client.BaseAddress = base_url;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", ""));

        }

        public async Task<CardProfessor> GetDetail(int id)
        {


            var response = await _client.GetAsync(urlGetCards+"?professor_id="+id);
            var teste = await response.Content.ReadAsStringAsync();
            var Card = JsonSerializer.Deserialize<CardProfessor>(teste, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //convert response to object
            return Card;
        }
        public async Task RemoveComentario(int id) {
            await _client.DeleteAsync(urlRemoveComentario+"?avaliacao_id="+id);
        }
        public async Task<int> GetComentarioId(string comentario,int professor_id) {
            var response = await _client.GetAsync(urlGetIdComentario+"?professor_id="+professor_id+"&comentario="+comentario);
             var content=await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(content);
            int id = doc.RootElement.GetProperty("id").GetInt32();
            return id;
        }
    }

}
