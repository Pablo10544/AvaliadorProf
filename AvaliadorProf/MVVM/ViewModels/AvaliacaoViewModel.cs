using AvaliadorProf.MVVM.Models;
using AvaliadorProf.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf.MVVM.ViewModels
{
    public partial class AvaliacaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private CardProfessor card;
        [ObservableProperty]
        public float progress5stars;
        [ObservableProperty]
        public float progress4stars;
        [ObservableProperty]
        public float progress3stars; 
        [ObservableProperty]
        public float progress2stars; 
        [ObservableProperty]
        public float progress1stars;
        public ObservableCollection<double> opacidadeEstrelaDidadica { get; set; } =new();
        public ObservableCollection<double> opacidadeEstrelaDificuldadeProva { get; set; } = new();
        public ObservableCollection<double> opacidadeEstrelaNotaPlanoEnsino { get; set; } = new();
        private AvaliacaoViewService _avaliacaoViewService;



        public AvaliacaoViewModel(CardProfessor card,AvaliacaoViewService avaliacao)
        {
            this.card = card;
            _avaliacaoViewService = avaliacao;
            for (int i = 0; i < 5; i++)
            {
                opacidadeEstrelaDidadica.Add(0.2);
                opacidadeEstrelaDificuldadeProva.Add(0.2);
                opacidadeEstrelaNotaPlanoEnsino.Add(0.2);
            }
           _=PopularCards(card.Id);

        }
        private void ShowStars(ObservableCollection<double> colecao, double nota)
        {
           int quantidadeEstrelas= (int)Math.Floor(nota)-1;
            for (int i = quantidadeEstrelas; i >=0; i--)
            {
                colecao[i] = 1;
            }
        }
        public async Task PopularCards(int id)
        {
            var CardNovo = await _avaliacaoViewService.GetDetail(id);
             AtualizarObjeto<CardProfessor>(Card,CardNovo);
            Card.MediaNotas = (Card.NotaDidatica + Card.NotaPlanoEnisno + Card.NotaDificuldadeProva) / 3;
            ShowStars(opacidadeEstrelaDidadica, Card.NotaDidatica);
            ShowStars(opacidadeEstrelaDificuldadeProva, Card.NotaDificuldadeProva);
            ShowStars(opacidadeEstrelaNotaPlanoEnsino, Card.NotaPlanoEnisno);
            Progress5stars = (float)Card.quantidade_nota_5 /(float) Card.TotalAvaliacoes;
            Progress4stars = (float)Card.quantidade_nota_4 / (float)Card.TotalAvaliacoes;
            Progress3stars = (float)Card.quantidade_nota_3 / (float)Card.TotalAvaliacoes;
            Progress2stars = (float)Card.quantidade_nota_2 / (float)Card.TotalAvaliacoes;
            Progress1stars = (float)Card.quantidade_nota_1 / (float)Card.TotalAvaliacoes;

            OnPropertyChanged(nameof(opacidadeEstrelaDidadica));
            OnPropertyChanged(nameof(opacidadeEstrelaDificuldadeProva));
            OnPropertyChanged(nameof(opacidadeEstrelaNotaPlanoEnsino));
            OnPropertyChanged(nameof(Card));
            OnPropertyChanged(nameof(Progress5stars));


        }
        public void AtualizarObjeto<T>(T antigo, T novo)
        {
            var propriedades = typeof(T).GetProperties();

            foreach (var prop in propriedades)
            {
                var novoValor = prop.GetValue(novo);
                var tipo = prop.PropertyType;

                // Só atualiza se o novo valor for "significativo"
                if (tipo == typeof(string))
                {
                    if (!string.IsNullOrEmpty((string)novoValor))
                        prop.SetValue(antigo, novoValor);
                }
                else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(tipo) && tipo != typeof(string))
                {
                    if (novoValor != null && ((System.Collections.IEnumerable)novoValor).Cast<object>().Any())
                        prop.SetValue(antigo, novoValor);
                }
                else if (tipo.IsValueType)
                {
                    var defaultValue = Activator.CreateInstance(tipo);
                    if (!Equals(novoValor, defaultValue))
                        prop.SetValue(antigo, novoValor);
                }
                else
                {
                    if (novoValor != null)
                        prop.SetValue(antigo, novoValor);
                }
            }
        }

    }
}
