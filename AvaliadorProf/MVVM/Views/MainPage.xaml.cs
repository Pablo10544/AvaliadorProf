using AvaliadorProf.MVVM.ViewModels;
using AvaliadorProf.MVVM.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using System.Collections.ObjectModel;

namespace AvaliadorProf
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation,this);
            
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            
                //var popup = new AvaliacaoView();
                // this.ShowPopup(popup, PopupOptions.Empty);
            
        }
    }
}
