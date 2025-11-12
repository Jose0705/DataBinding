using Databalding.Coleccion.NewFolder;



namespace Databalding.Coleccion.Views;

public partial class MainPage : ContentPage
{
	private List<OrigenDePaquete> _Origenes;
	public MainPage()
	{
		InitializeComponent();
        OrigenDePaquete? origenSelecionado = null;

        _Origenes = new List<OrigenDePaquete>();
		CargarDatos();
        OrigenesListView.ItemsSource = _Origenes;
        if (_Origenes.Count > 0)
        {
            origenSelecionado = _Origenes[0];
        }
        OrigenesListView.ItemsSource = _Origenes;
        OrigenesListView.SelectedItem = origenSelecionado;
    }
	private void CargarDatos()
	{
        _Origenes.Add(new OrigenDePaquete
        {
            Nombre = "nuget.org",
            Origen = "htttps://api.nuget.org/v3/index.json",
            Estahabilitado = false

        });
        _Origenes.Add(new OrigenDePaquete
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
        _Origenes.Add(origen);
        OrigenesListView.ItemsSource = null;
        OrigenesListView.ItemsSource = _Origenes;
        OrigenesListView.SelectedItem = origen;

    }
    private void OnDelateButtonCliked(object sender, EventArgs e)
    {
        OrigenDePaquete Seleccionado = 
            (OrigenDePaquete)OrigenesListView.SelectedItem;

        if (Seleccionado != null)
        {
            var indice = _Origenes.IndexOf(Seleccionado);
            OrigenDePaquete? Nuevoselecionado;
            if ( _Origenes.Count > 1)
            {
                //Hay mas de un elemento
                if ( indice < _Origenes.Count - 1 )
                {
                    // el elemento seleccionado no es el ultimo
                    Nuevoselecionado = _Origenes[indice + 1];  
                }
                else
                {
                    //el elemento seleccionado es el ultimo
                    Nuevoselecionado= _Origenes[indice - 1];
                }

            }
            else
            {
                //solo hay un elemento
                Nuevoselecionado = null;
            }
                _Origenes.Remove(Seleccionado);
                OrigenesListView.ItemsSource = null;
                OrigenesListView.ItemsSource = _Origenes;
            OrigenesListView.SelectedItem = Nuevoselecionado;
        }
    }
    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OrigenDePaquete origenselecionado = (OrigenDePaquete) OrigenesListView.SelectedItem;
        if (origenselecionado != null)
        {
            NombreEntry.Text = origenselecionado.Nombre;
            OrigenEntry.Text = origenselecionado.Origen;
        }
        else
        {
            NombreEntry.Text = string.Empty;
            OrigenEntry.Text = string.Empty;
        }
    }

    private void OnActualizarButton_Cliked(object sender, EventArgs e)
    {
        OrigenDePaquete? origenselecionado = 
            OrigenesListView.SelectedItem as OrigenDePaquete;
        if (origenselecionado != null)
        {
            origenselecionado.Nombre = NombreEntry.Text;
            origenselecionado.Origen = OrigenEntry.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _Origenes;
            OrigenesListView.SelectedItem = origenselecionado;

        }
    }
}