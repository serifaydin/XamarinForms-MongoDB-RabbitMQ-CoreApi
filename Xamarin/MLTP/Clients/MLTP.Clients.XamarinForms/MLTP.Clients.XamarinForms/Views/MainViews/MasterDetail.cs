using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.Views.MainViews
{
    public class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            Master = new MenuPage();
            Detail = new NavigationPage(new HomePage());
            //IsPresented = false;
        }
    }
}