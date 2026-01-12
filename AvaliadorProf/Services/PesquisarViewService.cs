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
    public class PesquisarViewService
    {
        private HttpClient _client;
        private Uri base_url = new Uri(Preferences.Get("back_end_url", ""));
        const string urlGetListaPesquisar = "listar-professores";
        const string urlGetCard = "buscar-avaliacao";
        public PesquisarViewService(HttpClient cliente)
        {
            _client = cliente;
            _client.BaseAddress = base_url;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", ""));

        }
        public async Task<List<SearchProfessor>> GetPesquisarLista()
        {
            var response = await _client.GetAsync(urlGetListaPesquisar);
            var teste = await response.Content.ReadAsStringAsync();
            var Card = JsonSerializer.Deserialize<List<SearchProfessor>>(teste, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //convert response to object
            return Card;
        }
        public async Task<CardProfessor> GetCard(int id)
        {
            var response = await _client.GetAsync(urlGetCard+"?professor_id="+id);
            var teste = await response.Content.ReadAsStringAsync();
            var Card = JsonSerializer.Deserialize<CardProfessor>(teste, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //convert response to object
            return Card;
        }
    }
}
