using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.ViewModels;
using AvaliadorProf.MVVM.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using PanCardView.Enums;
using System.Collections.ObjectModel;

namespace AvaliadorProf
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel main)
        {
            InitializeComponent();
            main.cardView = cardView;
            BindingContext = main;
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as MainViewModel)?.AppearingCommand.Execute(null);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

            //var popup = new AvaliacaoView();
            // this.ShowPopup(popup, PopupOptions.Empty);
        }

        private void cardView_ItemSwiped(PanCardView.CardsView view, PanCardView.EventArgs.ItemSwipedEventArgs args)
        {
            if (args?.Item is CardProfessor card)
            {
                if (args.Direction == ItemSwipeDirection.Left)
                {
                    (BindingContext as MainViewModel).Rejeitar(card.Id);

                }
                else if (args.Direction == ItemSwipeDirection.Right)
                {
                    (BindingContext as MainViewModel).Match(card);
                }
            }
        }
    }
}
