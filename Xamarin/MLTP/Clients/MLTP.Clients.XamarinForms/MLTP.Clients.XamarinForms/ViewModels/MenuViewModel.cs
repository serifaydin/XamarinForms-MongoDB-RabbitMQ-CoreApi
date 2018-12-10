using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.ViewModels
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuViewModel()
        {
            _redirectCommand = new Command(MenuRedirectPage);
        }

        #region Command
        private ICommand _redirectCommand;
        #endregion

        #region Encapsulation
        public ICommand RedirectCommand
        {
            get => _redirectCommand;
            set
            {
                if (_redirectCommand == null)
                    return;

                _redirectCommand = value;
            }
        }
        #endregion

        private void MenuRedirectPage(object sender)
        {
            var mainpage = Application.Current.MainPage as MasterDetailPage;
            var pg = new Page();

            if (sender == "rabbitmq")
            {
                pg = (Page)Activator.CreateInstance(typeof(Views.MainViews.RabbitMQTabbed));
            }
            else if (sender == "home")
            {
                pg = (Page)Activator.CreateInstance(typeof(Views.HomePage));
            }
            else if (sender == "sqlite")
            {
                pg = (Page)Activator.CreateInstance(typeof(Views.SQLitePage));
            }
            mainpage.Detail = new NavigationPage(pg);
        }
    }
}