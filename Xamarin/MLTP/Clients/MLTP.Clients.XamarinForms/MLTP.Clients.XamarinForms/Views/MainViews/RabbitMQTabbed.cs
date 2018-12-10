using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.Views.MainViews
{
    public class RabbitMQTabbed : TabbedPage
    {
        public RabbitMQTabbed()
        {
            Children.Add(new EmailProducerPage());
            Children.Add(new SmsProducerPage());
        }
    }
}