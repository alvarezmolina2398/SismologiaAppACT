
using Newtonsoft.Json;
using Sismologia.Controls;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lbregistrarmeClick();
            lbrecuperarClick();


            BindingContext = new
            {
               
                //metodo para enviar el correo
                Command = new Command(() =>
                {
                    ingresarAsync();

                })
            };


        }

        //metodo al momento de precionar en el label de registrarme
        void lbregistrarmeClick() {
            lbregistrarme.GestureRecognizers.Add(new TapGestureRecognizer()
            {
               


                Command = new Command(async () => {

                    await Navigation.PushAsync(new Registarme());
                })
            });
        }


        //metodo al momento de precionar en el labe de olvide mi contrase?a 
        void lbrecuperarClick()
        {
            lbrecuperar.GestureRecognizers.Add(new TapGestureRecognizer()
            {



                Command = new Command(() => {
                    ((NavigationPage)this.Parent).PushAsync(new RecuperarClave());
                })
            });
        }

        //accion al momento de ingresa
        private async void  ingresarAsync()

        {
            string usuario = txtcorreo.Text;

            string pass = txtpassword.Text;

            string urlProbar = "http://192.168.10.123/WEBAPI/administrar/v1/api/autenticacion";

          
            var device = DeviceInfo.Model;

            var manufacturer = DeviceInfo.Manufacturer;

            var deviceName = DeviceInfo.Name;

            var version = DeviceInfo.VersionString;

            var platform = DeviceInfo.Platform;

            var idiom = DeviceInfo.Idiom;

            //client.DefaultRequestHeaders.Add("", "");




            //convertimos a Byte
            byte[] bytes = Encoding.ASCII.GetBytes(usuario + "|" + pass);

            //Convertimos a String
            string cadenatxt = System.Convert.ToBase64String(bytes);
           // string cadenatxt = "";


            var Autenticacion = new {cadena = cadenatxt};


            ////envio de data
            //var myContent = JsonConvert.SerializeObject(Autenticacion);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            //var byteContent = new ByteArrayContent(buffer);
            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ////consumimos el ws

            // var response = await client.PostAsync(urlProbar, byteContent).Result;

            var json = JsonConvert.SerializeObject(Autenticacion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                var client = new HttpClient();

                var response = await client.PostAsync(urlProbar, data);

                string result = response.Content.ReadAsStringAsync().Result.ToString();
                Console.WriteLine(result);



                var res = result.Split('|');
                var c = res[0].ToCharArray();
                var estado = true;
                if (c[1] == 'p')
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }

                if (estado)

                {
                    await ((NavigationPage)this.Parent).PushAsync(new Dashboard());
                }

                else
                {

                    await DisplayAlert("Error", res[1], "Cerrar");

                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Error",e.Message , "Cerrar");
            }

        }

    }


    public class Autenticacion{
        public String cadena { get; set; }
    }
}
