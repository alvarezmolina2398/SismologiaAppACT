using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class inicio : ContentPage
    {
        public inicio()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Localizar();


        }



        

        private async void Localizar()
        {
            var locator = CrossGeolocator.Current; //Acceso a la API
            locator.DesiredAccuracy = 50; //Precisión (en metros)
            if (locator.IsGeolocationAvailable) //Servicio existente en el dispositivo
            {
                if (locator.IsGeolocationEnabled) //GPS activado en el dispositivo
                {
                    if (!locator.IsListening) //Comprueba si el dispositivo escucha al servicio
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); //Inicio de la escucha
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;



                        Mymap.MoveToRegion(
                            MapSpan.FromCenterAndRadius(
                                new Position(loc.Latitude, loc.Longitude),
                                Distance.FromKilometers(100)

                                ));


                    };
                }
            }
            else {
                var permiso = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (permiso == PermissionStatus.Granted)
                {
                    if (locator.IsGeolocationEnabled) //GPS activado en el dispositivo
                    {
                        if (!locator.IsListening) //Comprueba si el dispositivo escucha al servicio
                        {
                            await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); //Inicio de la escucha
                        }
                        locator.PositionChanged += (cambio, args) =>
                        {
                            var loc = args.Position;



                            Mymap.MoveToRegion(
                                MapSpan.FromCenterAndRadius(
                                    new Position(loc.Latitude, loc.Longitude),
                                    Distance.FromKilometers(150)

                                    ));


                        };
                    }
                }
                else {
                    await DisplayAlert("Error","Ubicacion actual no obtenida por falta de permisos", "Cerrar");
                }
              

            }
        }


    }


}