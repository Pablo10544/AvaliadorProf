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
    partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<CardProfessor> cards { get; set; } = new();
        INavigation nav;
        ContentPage page;
        public MainViewModel(INavigation navigation,ContentPage pageO)
        {
            cards.Add(new CardProfessor());
            cards.Add(new CardProfessor());
            nav=navigation;
            this.page = pageO;

        }
        [RelayCommand]
        async Task IrParaCards()
        {
           await Shell.Current.GoToAsync("main");
        }
        async Task IrParaProcurar()
        {

        }
        [RelayCommand]
        public async Task TesteTelaAval()
        {
            var popup = new AvaliacaoView();
             page.ShowPopup(popup, PopupOptions.Empty);
        }


    }
}
