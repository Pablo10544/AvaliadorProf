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
        INavigation nav;
        Page page;
        public string search { get; set; }
        public MainViewModel()
        {
            cards.Add(new CardProfessor());
            cards.Add(new CardProfessor());
            this.page = App.Current.Windows[0].Page;

        }
        [RelayCommand]
        async Task IrParaCards()
        {
            await NavigationAux.Instancia.GoToMainAsRoot();

        }
        [RelayCommand]
        async Task IrParaProcurar()
        {
            await NavigationAux.Instancia.GoToLoginAsRoot();
        }
        [RelayCommand]
        public async Task PopUpAvaliacao()
        {
            var popup = new AvaliacaoView();
            Console.WriteLine("show popup");
             page.ShowPopup(popup, PopupOptions.Empty);
        }


    }
}
