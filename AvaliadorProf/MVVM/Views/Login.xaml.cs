
using AvaliadorProf.MVVM.ViewModels;

namespace AvaliadorProf.MVVM.Views;

public partial class Login : ContentPage
{
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
        NavigationAux.Instancia.GoToMainAsRoot();
        }
    }
}