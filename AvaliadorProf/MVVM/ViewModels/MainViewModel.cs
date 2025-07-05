using AvaliadorProf.MVVM.Models;
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
    partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<CardProfessor> cards { get; set; } = new();
        INavigation nav;
        public MainViewModel(INavigation navigation)
        {
            cards.Add(new CardProfessor());
            cards.Add(new CardProfessor());
            nav=navigation;

        }
        [RelayCommand]
        async Task IrParaCards()
        {
           await Shell.Current.GoToAsync("main");
        }
        async Task IrParaProcurar()
        {

        }


    }
}
