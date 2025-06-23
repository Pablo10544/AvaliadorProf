using System.Collections.ObjectModel;

namespace AvaliadorProf
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> x { get; set; } = new ();
        public MainPage()
        {
            InitializeComponent();
            x.Add("teste");
            x.Add("teste");
            BindingContext = this;
        }


    }
}
