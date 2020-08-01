using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarClave : ContentPage
    {
        public RecuperarClave()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lbIniciarSesionClick();

            BindingContext = new
            {

                //metodo para enviar el correo
                Command = new Command(() => {
                  
                    ((NavigationPage)this.Parent).PushAsync(new CodeRecuperacion());
                })
            };
           
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