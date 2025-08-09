using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using PanCardView;
using PanCardView.Processors;
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
        public ObservableCollection<ImageSource> images { get; set; } = new();
        Page page;
        public CardsView cardView;
        [ObservableProperty]
        public string search;
        private MainViewService _mainViewService;
        public MainViewModel(MainViewService mainViewService)
        {
            _mainViewService = mainViewService;
            //cards.Add(new CardProfessor());
            //cards.Add(new CardProfessor());
            this.page = App.Current.Windows[0].Page;

        }
        [RelayCommand]
        async Task Appearing()
        {   if (cards.Count() > 0) {
                return;
            }
            var list = await PopularCards();
            //var tasks = list.Select(async item =>
            //{
            //    item.Foto = await GetImage(item.Id);
            //    return item;
            //});
            //var completedItems = await Task.WhenAll(tasks);
            Uri base_url = new Uri(Preferences.Get("back_end_url", ""));

            foreach (var item in list)
            {
                item.urlFoto = base_url + "foto-professor?professor_id=" + item.Id+"&l=l";
                cards.Add(item);
            }
            OnPropertyChanged(nameof(cards));

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
        async Task IrParaProcurarComParametro(string search)
        {
            await NavigationAux.Instancia.GoToSearchAsRootWithSearch(search);
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
        [RelayCommand]
        public async Task Rejeitar(int professor_id)
        {   
            cards.RemoveAt(0);
            await _mainViewService.Rejeitar(professor_id);
        }

        [RelayCommand]
        public void Match(CardProfessor Professor)
        {
            var popup = new AvaliacaoEditView(Professor,page);
            Console.WriteLine("show popup");
            page.ShowPopup(popup, PopupOptions.Empty);
            cards.RemoveAt(0);
        }
        [RelayCommand]
        public async Task<ImageSource> GetImage(int professor_id)
        {
            var imageBytes=await _mainViewService.GetImageProfessor(professor_id);

                     ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            return imageSource;
        }

    }
}
