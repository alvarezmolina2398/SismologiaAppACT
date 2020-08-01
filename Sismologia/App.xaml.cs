using Sismologia.Views;
using Xamarin.Forms;


[assembly: ExportFont("FontAwesome5Brands.otf", Alias = "FontAwesomeBrands")]
[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "FontAwesomeSolid")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "MontserratBold")]
[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "MontserratRegular")]
[assembly: ExportFont("OpenSans-Bold.ttf", Alias = "OpenSansBold")]
[assembly: ExportFont("OpenSans-BoldItalic.ttf", Alias = "OpenSansBoldItalic")]
[assembly: ExportFont("OpenSans-ExtraBold.ttf", Alias = "OpenSansExtraBold")]
[assembly: ExportFont("OpenSans-ExtraBoldItalic.ttf", Alias = "OpenSansExtraBoldItalic")]
[assembly: ExportFont("OpenSans-Italic.ttf", Alias = "OpenSansItalic")]
[assembly: ExportFont("OpenSans-Light.ttf", Alias = "OpenSansLight")]
[assembly: ExportFont("OpenSans-LightItalic.ttf", Alias = "OpenSansLightItalic")]
[assembly: ExportFont("OpenSans-Regular.ttf", Alias = "OpenSansRegular")]
[assembly: ExportFont("OpenSans-SemiBold.ttf", Alias = "OpenSansSemiBold")]
[assembly: ExportFont("OpenSans-SemiBoldItalic.ttf", Alias = "OpenSansSemiBoldItalic")]


namespace Sismologia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Current.MainPage = new NavigationPage(new AlertaRoja());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
