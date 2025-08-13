
using AvaliadorProf.MVVM.ViewModels;
using CommunityToolkit.Maui.Alerts;

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
            Preferences.Set("back_end_url", IP.Text?? "https://backendavaliaufjf-production.up.railway.app/");
            if (IsCreatingAccount)
            {
                var toast = Toast.Make("Conta criada com sucesso!");
                toast.Show();
            }
            NavigateToMain();
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