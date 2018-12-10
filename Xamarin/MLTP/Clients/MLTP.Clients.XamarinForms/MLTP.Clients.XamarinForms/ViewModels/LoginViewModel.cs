using MLTP.Clients.XamarinForms.Models;
using MLTP.Clients.XamarinForms.Models.Common;
using MLTP.Clients.XamarinForms.Service;
using Plugin.DeviceInfo;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        CommonService _commonService;

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel()
        {
            _commonService = new CommonService();
            UserName = "admin";
            Password = "123";
            IsBusy = false;

            _loginCommand = new Command(LoginAction);
        }

        #region Fields
        private bool _isBusy;
        private string _username;
        private string _password;
        private AuthenticateModel _model;
        #endregion

        #region Command
        private ICommand _loginCommand;
        #endregion

        #region Encapsulation
        public ICommand LoginCommand
        {
            get => _loginCommand;
            set
            {
                if (_loginCommand == null)
                    return;

                _loginCommand = value;
            }
        }

        public AuthenticateModel Model
        {
            get => _model;

            set
            {
                _model = value;
                onPropertyChanged();
            }
        }


        public bool IsBusy
        {
            get => _isBusy;

            set
            {
                _isBusy = value;
                onPropertyChanged();
            }
        }
        public string UserName

        {
            get => _username;

            set
            {
                _username = value;
                onPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;

            set
            {
                _password = value;
                onPropertyChanged();
            }
        }
        #endregion

        #region Command Action
        public async void LoginAction()
        {
            this.IsBusy = true;

            ResponseItem result = await _commonService.UserLogin(UserName, Password);
            if (!result.Result)
            {
                await App.Current.MainPage.DisplayAlert("Giriş Başarısız .", "Yanlış Kullanıcı Adı veya Şifre", "Tamam");
                this.IsBusy = false;
                return;
            }

            AuthenticateModel _auth = (AuthenticateModel)result.Data;
            Utility.MltpUser.Id = _auth.Id;
            Utility.MltpUser.Name = _auth.Name;
            Utility.MltpUser.Surname = _auth.Surname;

            UserDeviceAdded(_auth.Id);
            Helpers.Settings.GeneralSettings = _auth.Id.ToString();

            this.IsBusy = false;

            await App.Current.MainPage.Navigation.PushModalAsync(new Views.MainViews.MasterDetail());
        }
        #endregion

        #region Other Function
        public async void UserDeviceAdded(int UserId)
        {
            string AppID = CrossDeviceInfo.Current.Id;
            string PhoneModel = CrossDeviceInfo.Current.Model;
            string Platform = CrossDeviceInfo.Current.Platform.ToString();
            string Version = CrossDeviceInfo.Current.Version;

            AddUserDeviceRequestModel model = new AddUserDeviceRequestModel
            {
                AppId = AppID,
                PhoneModel = PhoneModel,
                PhoneVersion = Version,
                Platform = Platform,
                UserId = UserId
            };

            await _commonService.AddUserDevice(model);
        }
        #endregion
    }
}