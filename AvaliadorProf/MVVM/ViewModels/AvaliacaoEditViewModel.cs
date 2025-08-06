using AvaliadorProf.MVVM.Models;
using AvaliadorProf.Services;
using CommunityToolkit.Maui.Extensions;
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
    public partial class AvaliacaoEditViewModel: ObservableObject
    {
        [ObservableProperty]
        public CardProfessor card;
        public ObservableCollection<double> opacidadeEstrelaDidadica { get; set; } = new();
        public ObservableCollection<double> opacidadeEstrelaDificuldadeProva { get; set; } = new();
        public ObservableCollection<double> opacidadeEstrelaNotaPlanoEnsino { get; set; } = new();
        [ObservableProperty]
        public int notaDidatica;
        [ObservableProperty]
        public int notaDificuldadeProva;
        [ObservableProperty]
        public int notaPlanoDeEnsino;
        [ObservableProperty]
        public string comentario;
        private AvaliacaoEditViewService _avaliacaoEditViewService;
        private Page _page;
        public AvaliacaoEditViewModel(CardProfessor card, AvaliacaoEditViewService avaliacaoEditViewService,Page page) {
            this.card = card;
            for (int i = 0; i < 5; i++)
            {
                opacidadeEstrelaDidadica.Add(0.2);
                opacidadeEstrelaDificuldadeProva.Add(0.2);
                opacidadeEstrelaNotaPlanoEnsino.Add(0.2);
            }
            _avaliacaoEditViewService = avaliacaoEditViewService;
            _page = page;
        }
        [RelayCommand]
        public async Task EnviarAvaliacao() {
            await _avaliacaoEditViewService.Avaliar(NotaDidatica,NotaDificuldadeProva,NotaPlanoDeEnsino,Comentario,Card.Id);
            await _page.ClosePopupAsync();

        }
        [RelayCommand]
        public void AvalDidatica(string valor)
        {
            NotaDidatica = Int32.Parse(valor); 
            ShowStars(opacidadeEstrelaDidadica, NotaDidatica);
            OnPropertyChanged(nameof(opacidadeEstrelaDidadica));


        }
        [RelayCommand]
        public void AvalDificuldadeProva(string valor)
        {
            NotaDificuldadeProva = Int32.Parse(valor);
            ShowStars(opacidadeEstrelaDificuldadeProva, NotaDificuldadeProva);
            OnPropertyChanged(nameof(opacidadeEstrelaDificuldadeProva));
        }
        [RelayCommand]
        public void AvalPlanoDeEnsino(string valor)
        {
            NotaPlanoDeEnsino = Int32.Parse(valor);
            ShowStars(opacidadeEstrelaNotaPlanoEnsino, NotaPlanoDeEnsino);
            OnPropertyChanged(nameof(opacidadeEstrelaNotaPlanoEnsino));
        }
        private void ShowStars(ObservableCollection<double> colecao, double nota)
        {
            for (int i = 0; i < colecao.Count(); i++)
            {
                colecao[i] = 0.2;
            }
            int quantidadeEstrelas = (int)Math.Floor(nota) - 1;
            for (int i = quantidadeEstrelas; i >= 0; i--)
            {
                colecao[i] = 1;
            }
        }
    }
}
