using DataBinding.DataObject.NewFolder;

namespace DataBinding.DataObject
{
    public partial class MainPage : ContentPage
    {
        // conteo lleva el conteo de la aplic git statusacion
        private Contador contador;
        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;
         
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            contador.Contar();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            contador.Reiniciar();
        
        }
    }
}
