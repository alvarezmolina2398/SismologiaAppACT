
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registarme : ContentPage
    {
        public Registarme()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lbIniciarSesionClick();
        }



        //metodo al momento de precionar en el label de iniciar sesion
        void lbIniciarSesionClick()
        {
            lbIniciarSesion.GestureRecognizers.Add(new TapGestureRecognizer()
            {



                Command = new Command(() => {
                    ((NavigationPage)this.Parent).PushAsync(new login());
                })
            });
        }
    }
}