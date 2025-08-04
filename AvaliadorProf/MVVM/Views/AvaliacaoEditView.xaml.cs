using AvaliadorProf.MVVM.Models;
using AvaliadorProf.MVVM.ViewModels;

namespace AvaliadorProf.MVVM.Views;

public partial class AvaliacaoEditView : ContentView
{
	public AvaliacaoEditView(CardProfessor card)
	{
		InitializeComponent();
		BindingContext = new AvaliacaoEditViewModel(card,new Services.AvaliacaoEditViewService(new HttpClient()));
}
}