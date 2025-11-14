using Databalding.Coleccion.NewFolder;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Databalding.Coleccion.Views;

public partial class MainPage : ContentPage ,INotifyPropertyChanged
{
	public ObservableCollection<OrigenDePaquete> Origenes { get; }
    private OrigenDePaquete? _origenselecionado = null;
    private string _nombredelorigen = string.Empty;
    private string _rutadelorigen = string.Empty;

    public OrigenDePaquete Origenselecionado
    {
        get => _origenselecionado;
        set
        {
            if ( _origenselecionado != value) 
                {
                    _origenselecionado = value;
                OnPropertyChanged(nameof(Origenselecionado));
                }
        }
    }
    public string Nombredelorigen
    {
        get => _nombredelorigen;
            set
            {
            if (_nombredelorigen != value)
            {
            _nombredelorigen = value;
                OnPropertyChanged(nameof(Nombredelorigen));
            }
            }
    }
    public string Rutadelorigen
    {
        get => _rutadelorigen;
        set
        {
            if (_rutadelorigen != value)
            {
                _rutadelorigen = value;
                OnPropertyChanged(nameof(Rutadelorigen));
            }
        }
    }


    public MainPage()
    {
        InitializeComponent();
        Origenselecionado = null;
        Origenes = new ObservableCollection<OrigenDePaquete>();
        CargarDatos();
        BindingContext = this;

        OrigenesListView.ItemsSource = Origenes;
        if (Origenes.Count > 0)
        {
            Origenselecionado = Origenes[0];

        }
        //////OrigenesListView.ItemsSource = _origenes;
        //////OrigenesListView.SelectedItem = origenSeleccionado;
    }
    private void CargarDatos()
	{
        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "nuget.org",
            Origen = "htttps://api.nuget.org/v3/index.json",
            Estahabilitado = true

        });
        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = @"C:\Program Files(x86)\Microsoft SDKs\NugetPackages",
            Estahabilitado = false

        });
    }

    private void OnAgregarButtonCliked(object sender, EventArgs e)
    {
        var origen = new OrigenDePaquete
        {
            Nombre = "Origen del paquete",
            Origen = "Url o Ruta",
            Estahabilitado = false

        };
        Origenes.Add(origen);
        Origenselecionado = origen;
        

    }
    private void OnDelateButtonCliked(object sender, EventArgs e)
    {

        if (Origenselecionado != null)
        {
            var indice = Origenes.IndexOf(Origenselecionado);
            OrigenDePaquete? nuevoSeleccionado;
            if (Origenes.Count > 1)
            {
                //Hat mas de un elemento
                if (indice < Origenes.Count - 1)
                {//El elemento seleccionado no es el ultimo
                    nuevoSeleccionado = Origenes[indice + 1];
                }
                else
                {//El elemento seleccionadp es el ultimo
                    nuevoSeleccionado = Origenes[indice - 1];

                }
            }
            else
            {//Solo hay un elemento
                nuevoSeleccionado = null;
            }
            Origenes.Remove(Origenselecionado);
            Origenselecionado = nuevoSeleccionado;
        }
    }
    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {


    if (Origenselecionado != null)
    {
        Nombredelorigen = Origenselecionado.Nombre;
       Rutadelorigen = Origenselecionado.Origen;
    }
    else
    {
       Nombredelorigen = string.Empty;
        Rutadelorigen = string.Empty;
    }
    }

    private void OnActualizarButton_Cliked(object sender, EventArgs e)
    {

        if (Origenselecionado != null)
        {
            Origenselecionado.Nombre = Nombredelorigen;
            Origenselecionado.Origen = Rutadelorigen;
        }
    }
}