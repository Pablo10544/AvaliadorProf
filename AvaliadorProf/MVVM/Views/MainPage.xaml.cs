using AvaliadorProf.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace AvaliadorProf
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
            
        }


    }
}
