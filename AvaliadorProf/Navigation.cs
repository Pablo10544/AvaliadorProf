using AvaliadorProf.MVVM.ViewModels;
using AvaliadorProf.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf
{
    public  class NavigationAux
    {
        INavigation _nav;
       private static NavigationAux _instancia;
        IServiceProvider Service;
        Login _login;
        MainPage _mainPage;
        MainViewModel _mv;
        public NavigationAux(IServiceProvider serviceProvider,MVVM.Views.Login login, MainPage mainPage,MainViewModel mv)
        {
            _nav = App.Current.Windows[0].Page.Navigation;
            _login = login;
            _mainPage = mainPage;
            _mv = mv;
        }
        public static NavigationAux Instancia => _instancia
    ??= IPlatformApplication.Current.Services.GetRequiredService<NavigationAux>();
        public  void GoToLogin() {
            _nav.PushAsync(_login);
        }
        public void GoToMain()
        {
            _nav.PushAsync(_mainPage);
        }
        public async  Task GoToMainAsRoot() {
            //await _nav.PushAsync(new MainPage(_mv));
            _nav.InsertPageBefore(new MainPage(_mv), _nav.NavigationStack[0]);
            await _nav.PopToRootAsync();
        }
        public async Task GoToLoginAsRoot() {
            _nav.InsertPageBefore(new Login(), _nav.NavigationStack[0]);
            await _nav.PopToRootAsync();
        }
        public async Task GoToSearchAsRoot()
        {
            _nav.InsertPageBefore(new Pesquisar(), _nav.NavigationStack[0]);
            await _nav.PopToRootAsync();
        }
    }
}
