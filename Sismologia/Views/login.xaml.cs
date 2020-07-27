
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
        }
    }
}