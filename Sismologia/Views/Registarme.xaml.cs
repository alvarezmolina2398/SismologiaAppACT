
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
        }
    }
}