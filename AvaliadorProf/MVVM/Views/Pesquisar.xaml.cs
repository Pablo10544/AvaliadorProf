using AvaliadorProf.MVVM.Models;
using AvaliadorProf.Services;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AvaliadorProf.MVVM.Views;

public partial class Pesquisar : ContentPage
{
	List<SearchProfessor> _professores = new();
	public List<SearchProfessor> Professores { get { return _professores; } set { professoresShow = new ObservableCollection<SearchProfessor>(value); _professores = value; } }
	public ObservableCollection<SearchProfessor> professoresShow { get; set; } = new();
	
    public string search { get; set; }
	private PesquisarViewService _pesquisarViewService;
    private Page _page;

    public Pesquisar(PesquisarViewService pesquisarViewService,string searchquery="")
	{
		_pesquisarViewService = pesquisarViewService;
        BindingContext = this;
        _page = this;
        search = searchquery;
        OnPropertyChanged(nameof(search));
        InitializeComponent();
	}
    protected override async void OnAppearing()
	{
		var lista_pesquisar =await _pesquisarViewService.GetPesquisarLista();
        Professores = lista_pesquisar;
        MakeSearch();
		OnPropertyChanged(nameof(professoresShow));
    }
	public void searchForText()
	{
		professoresShow = new ObservableCollection<SearchProfessor>(Professores.Where(x => x.Nome.ToLower().Contains(search.ToLower())).ToList());
        OnPropertyChanged("professoresShow");
        Console.WriteLine(professoresShow.Count);
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
			professoresShow = new ObservableCollection<SearchProfessor>(Professores);
            OnPropertyChanged("professoresShow");

        }
    }
    private void MakeSearch()
    {
        Entry en = Entrada;
        if (en.Text != "")
        {
            search = en.Text;
            Console.WriteLine(search);
            searchForText();
        }
        else
        {
            professoresShow = new ObservableCollection<SearchProfessor>(Professores);
            OnPropertyChanged("professoresShow");

        }
        OnPropertyChanged(nameof(professoresShow));
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
    [RelayCommand]
    public async Task PopUpAvaliacao(SearchProfessor search)
    {
        CardProfessor Professor = new() { Id = search.Id, Nome = search.Nome };
        var popup = new AvaliacaoView(Professor);
        Console.WriteLine("show popup");
        _page.ShowPopup(popup, PopupOptions.Empty);
    }
}