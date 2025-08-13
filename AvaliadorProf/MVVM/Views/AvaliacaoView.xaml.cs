using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.ViewModels;

namespace AvaliadorProf.MVVM.Views;

public partial class AvaliacaoView : ContentView
{
	public AvaliacaoView(CardProfessor card,bool showDeleteButton=false)
	{
		InitializeComponent();
		BindingContext = new AvaliacaoViewModel(card,new Services.AvaliacaoViewService(new HttpClient()),showDeleteButton);
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		((ImageButton)sender).BackgroundColor = Color.FromRgb(0, 0, 0);
    }
}