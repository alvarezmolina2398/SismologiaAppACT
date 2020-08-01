using Plugin.LocalNotifications;
using Plugin.SimpleAudioPlayer;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sismologia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertaRoja : ContentPage
    {

        ISimpleAudioPlayer player;
      

        Timer Timer;
        int min = 4, sec = 59,mil = 999,opc = 0;


        


        public AlertaRoja()
        {
            InitializeComponent();

            var stream = GetStreamFromFile("alarma.mp3");
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Load(stream);


            player.Play();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            Vibrar();
            Notificar();
            FlashLightAsync();
            IniciarTimer();
        }

       

        Stream  GetStreamFromFile(String filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Sismologia." + filename);
            return stream;
        }

        private string myStringProperty;
        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }

        public void IniciarTimer() {
            Timer = new Timer();
            Timer.Interval = 1;
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = true;

            // Start the timer
            Timer.Enabled = true;
            Timer.Start();
        }



  
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            mil--;
            if (mil <= 0) {
                sec--;
                mil = 999;
            }
            if (sec <= 0) {
                min--;
                sec = 59;
            } if (min <=0) {
                Vibration.Cancel();
                ApagarFlash();
                Timer.Stop();
                Timer = null;
                player.Play();
            }


            if (opc == 0 && (mil == 100 || mil ==  300 || mil == 500 || mil == 700 || mil == 999 ))
            {
                FlashLightAsync();

                opc =1;
            }
            else if(opc == 1 && (mil == 0 || mil == 200 || mil == 400 || mil == 600 || mil == 800 )) {
                ApagarFlash();
                opc = 0;
            }


           MyStringProperty = "0:" + min + ":" + sec; 
            
            
        }

        public void Notificar() {


            CrossLocalNotifications.Current.Show("ALERTA!", "Sismo Peligro Cerca de ti.");
        }


        public async void FlashLightAsync() {
            // Turn On


            var status = await Permissions.CheckStatusAsync<Permissions.Flashlight>();


            if (status != PermissionStatus.Granted) {
                await Permissions.RequestAsync<Permissions.Flashlight>();
            }


            status = await Permissions.CheckStatusAsync<Permissions.Flashlight>();

            if (status == PermissionStatus.Granted) {
                await Flashlight.TurnOnAsync();
            }

            
        }


        public void Vibrar() {
           


            if (!CrossVibrate.IsSupported) {
                return;
            }

            if (!CrossVibrate.Current.CanVibrate) {
                return;
            }


            CrossVibrate.Current.Vibration( new TimeSpan(0,2,5));


        }



        public async void ApagarFlash()
        {

            await Flashlight.TurnOffAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Vibration.Cancel();
            ApagarFlash();
            Timer.Stop();
            Timer = null;
            player.Stop();

        }
    }
}