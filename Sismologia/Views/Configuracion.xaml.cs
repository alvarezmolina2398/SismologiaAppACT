using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracion : ContentPage
    {
        public Configuracion()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            validarPermisosAsync();

        }



        public async void validarPermisosAsync()
        {

            var permisoLocacion = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (permisoLocacion == PermissionStatus.Granted)
            {
                swubicacion.IsToggled = true;
                
            }
            else
            {
                swubicacion.IsToggled = false;
            }

        }



       public async void PedirAccesoUbicaion()
        {

            
            var permiso =  await Permissions.RequestAsync<Permissions.LocationWhenInUse>().ConfigureAwait(true) ;


            if (permiso == PermissionStatus.Denied)
            {
                await DisplayAlert("Advertencia", "Permiso Denegado, si desea cambiarlo realizar esta accion en la configuracion del sistema.", "Ok");


            }

            swubicacion.IsEnabled = false;
            validarPermisosAsync();
            
        }

        private void swubicacion_Toggled(object sender, ToggledEventArgs e)
        {

            if (e.Value) {
                PedirAccesoUbicaion();
            }

            
        }
    }
}