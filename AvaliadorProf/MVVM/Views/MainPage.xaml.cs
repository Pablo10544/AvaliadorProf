using AvaliadorProf.MVVM.ViewModels;
using AvaliadorProf.MVVM.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using System.Collections.ObjectModel;

namespace AvaliadorProf
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel main)
        {
            InitializeComponent();
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
    }
}
