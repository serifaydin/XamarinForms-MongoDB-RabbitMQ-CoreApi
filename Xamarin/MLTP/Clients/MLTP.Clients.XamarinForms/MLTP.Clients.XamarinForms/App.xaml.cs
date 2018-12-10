using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MLTP.Clients.XamarinForms
{
    public partial class App : Application
    {
        public static string SqliteDb { get; set; } = "mltp.db3";

        public App()
        {
            InitializeComponent();

            if (Helpers.Settings.GeneralSettings == "")
                MainPage = new Views.LoginPage();
            else
                MainPage = new Views.MainViews.MasterDetail();

            //MainPage = new Views.SQLitePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}