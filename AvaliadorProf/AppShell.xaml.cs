using AvaliadorProf.MVVM.Views;

namespace AvaliadorProf
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("login", typeof(Login));

        }
    }
}
