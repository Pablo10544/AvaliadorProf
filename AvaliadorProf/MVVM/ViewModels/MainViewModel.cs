using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<CardProfessor> cards { get; set; } = new();
        Page page;
        public string search { get; set; }
        private MainViewService _mainViewService;
        public MainViewModel(MainViewService mainViewService)
        {
            _mainViewService = mainViewService;
            //cards.Add(new CardProfessor());
            //cards.Add(new CardProfessor());
            this.page = App.Current.Windows[0].Page;

        }
        [RelayCommand]
        async void Appearing()
        {
            var list = await PopularCards();
            foreach (var item in list)
            {
                cards.Add(item);
            }
            OnPropertyChanged();

        }

        [RelayCommand]
        async Task IrParaCards()
        {
            await NavigationAux.Instancia.GoToMainAsRoot();

        }
        [RelayCommand]
        async Task IrParaProcurar()
        {
            await NavigationAux.Instancia.GoToSearchAsRoot();
        }
        [RelayCommand]
        public async Task PopUpAvaliacao(CardProfessor Professor)
        {
            var popup = new AvaliacaoView(Professor);
            Console.WriteLine("show popup");
             page.ShowPopup(popup, PopupOptions.Empty);
        }
        public async Task<List<CardProfessor>> PopularCards()
        {
           return await _mainViewService.GetCards();
        }


    }
}
