namespace AvaliadorProf.MVVM.Views;

public partial class AvaliacaoView : ContentView
{
	public AvaliacaoView()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		((ImageButton)sender).BackgroundColor = Color.FromRgb(0, 0, 0);
    }
}