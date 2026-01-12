
using AvaliadorProf.MVVM.ViewModels;
using CommunityToolkit.Maui.Alerts;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AvaliadorProf.MVVM.Views;

public partial class Login : ContentPage
{
    bool IsCreatingAccount = false;
    public Login()
    {
        InitializeComponent();

    }
    private void AnimateOrbit()
    {
        const double radiusX = 100; // Raio no eixo X
        const double radiusY = 200; // Raio no eixo Y
        const double centerX = 0; // Centro horizontal
        const double centerY = 0; // Centro vertical
        const int duration = 5000;  // Duração em ms

        var animation = new Animation(v =>
        {
            double angle = 2 * Math.PI * v;
            double x = centerX + radiusX * Math.Cos(angle);
            double y = centerY + radiusY * Math.Sin(angle);

            OrbitPath.TranslationX = x;
            OrbitPath.TranslationY = y;

        }, 0, 1); // v vai de 0 até 1 (1 ciclo completo)

        animation.Commit(this, "OrbitLoop", 16, (uint)duration, Easing.Linear, finished: (v, c) =>
        {
            // Repetir a animação em loop
            AnimateOrbit();
        });
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        AnimateOrbit();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (email.Text!=null && senha.Text!=null) {
            // Preferences.Set("back_end_url", IP.Text?? "https://backendavaliaufjf-production.up.railway.app/");
            Preferences.Set("back_end_url", IP.Text ?? "http://192.168.2.105:5000");

            if (IsCreatingAccount)
            {
                var toast = Toast.Make("Conta criada com sucesso!");
                toast.Show();
            }        
             HttpClient _client = new HttpClient();
            Uri base_url = new Uri(Preferences.Get("back_end_url", ""));
            _client.BaseAddress = base_url;
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email",email.Text ),
                new KeyValuePair<string, string>("senha", senha.Text)

            };
            var content = new FormUrlEncodedContent(pairs);
           HttpResponseMessage response= _client.PostAsync("login",content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               var token =response.Content.ReadAsStringAsync().Result;
                var token2 = token.Substring(token.IndexOf("\"token\":")).Replace("\"", "").Replace("token: ","").Replace("\n","").Replace("}","") ;
                Preferences.Set("token",token2);

                NavigateToMain();
            }
        }
    }
    void NavigateToMain()
    {
        NavigationAux.Instancia.GoToMainAsRoot();

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        IsCreatingAccount = true;
        BotaoEntrar.Text = "Criar Conta";
        BotaoEntrar.FontSize = 15;
        CriarContaButton.TextColor =Colors.Transparent;
        CriarContaButton.IsEnabled = false;
        CriarContaLabel.TextColor = Colors.Transparent;
    }
}