using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AvaliadorProf.MVVM.Views;

public partial class Pesquisar : ContentPage
{
	List<string> _professores = new();
	public List<string> Professores { get { return _professores; } set { professoresShow = ConvertToObservableCollection(value); _professores = value; } }
	public ObservableCollection<string> professoresShow { get; set; } = new();
	public string search { get; set; }

    public Pesquisar()
	{
		List<string> temp = new();
        temp.Add("maria");
        temp.Add("joao");
        temp.Add("jose");
		Professores = temp;
        BindingContext = this;
		InitializeComponent();
	}
	public void searchForText()
	{
		professoresShow = ConvertToObservableCollection(Professores.Where(x => x.Contains(search)).ToList());
        OnPropertyChanged("professoresShow");
        Console.WriteLine(professoresShow.Count);
	}
	public ObservableCollection<string> ConvertToObservableCollection(List<string> list) {
	ObservableCollection<string> newlist = new();
		foreach(string i in list)
		{
			newlist.Add(i);
		}
		return newlist;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		Entry en = (Entry)sender;
		if (en.Text!="")
		{
			search = en.Text;
			Console.WriteLine(search);
		searchForText();
		}else
		{
			professoresShow = ConvertToObservableCollection(Professores);
            OnPropertyChanged("professoresShow");

        }
    }
    [RelayCommand]
    async Task IrParaCards()
    {
        await NavigationAux.Instancia.GoToMainAsRoot();

    }
    [RelayCommand]
    async Task IrParaProcurar()
    {
        await NavigationAux.Instancia.GoToSearchAsRoot();
    }
}