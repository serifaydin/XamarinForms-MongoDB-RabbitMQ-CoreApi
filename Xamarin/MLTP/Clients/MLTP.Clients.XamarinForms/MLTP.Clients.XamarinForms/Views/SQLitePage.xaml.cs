using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MLTP.Clients.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLitePage : ContentPage
    {
        public SQLitePage()
        {
            InitializeComponent();

            #region Hard Coded
            //List<string> deneme = new List<string>
            //{
            //    "","",
            //};

            //gridView.ItemsSource = deneme; 
            #endregion
        }
    }
}