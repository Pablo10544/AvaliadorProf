using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.ViewModels;

namespace AvaliadorProf.MVVM.Views;

public partial class AvaliacaoView : ContentView
{
	public AvaliacaoView(CardProfessor card)
	{
		InitializeComponent();
		BindingContext = new AvaliacaoViewModel(card,new Services.AvaliacaoViewService(new HttpClient()));
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		((ImageButton)sender).BackgroundColor = Color.FromRgb(0, 0, 0);
    }
}