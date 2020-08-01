using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
    public partial class Permisos : ContentPage
    {
        public Permisos()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CheckearPermisosAsync();

            BindingContext = new
            {

                //metodo para enviar el correo
                Command = new Command(() =>
                {
                    ((NavigationPage)this.Parent).PushAsync(new Dashboard());

                })
            };

        }


        public async void CheckearPermisosAsync() {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();

            if (status != PermissionStatus.Granted)
            {
                swubicacion.IsToggled = false;
                
            }
            else {
                swubicacion.IsToggled = true;
                swubicacion.IsEnabled = false;
            }


        }



        public  void PedirAccesoUbicaionAsync()
        {

            CrossPermissions.Current.OpenAppSettings();
            CheckearPermisosAsync();

        }

        private void swubicacion_Toggled(object sender, ToggledEventArgs e)
        {
                PedirAccesoUbicaionAsync();
        }

        private void wsnotificaciones_Toggled(object sender, ToggledEventArgs e)
        {
            PedirAccesoUbicaionAsync();
        }

        private void swModoloSilencio_Toggled(object sender, ToggledEventArgs e)
        {
            PedirAccesoUbicaionAsync();
        }

        private void wsdibujado_Toggled(object sender, ToggledEventArgs e)
        {
            PedirAccesoUbicaionAsync();
        }
    }
}