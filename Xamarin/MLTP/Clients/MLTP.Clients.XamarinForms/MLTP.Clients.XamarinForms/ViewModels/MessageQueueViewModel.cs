using MLTP.Clients.XamarinForms.Models;
using MLTP.Clients.XamarinForms.Models.MessageDelivery;
using MLTP.Clients.XamarinForms.Service;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.ViewModels
{
    public class MessageQueueViewModel : INotifyPropertyChanged
    {
        private MessageDeliveryService _queue;

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MessageQueueViewModel()
        {
            _queue = new MessageDeliveryService();

            _smsQueueCommand = new Command(SmsQueueFunction);
            _mailQueueCommand = new Command(EmailQueueFunction);
        }

        #region Command
        private ICommand _smsQueueCommand;
        private ICommand _mailQueueCommand;

        private EmailModel _emailModel;
        private SmsModel _smsModel;
        #endregion

        #region Encapsulation
        public ICommand SmsQueueCommand
        {
            get => _smsQueueCommand;
            set
            {
                if (_smsQueueCommand == null)
                    return;

                _smsQueueCommand = value;
            }
        }

        public ICommand MailQueueCommand
        {
            get => _mailQueueCommand;
            set
            {
                if (_mailQueueCommand == null)
                    return;

                _mailQueueCommand = value;
            }
        }

        public EmailModel EmailModel
        {
            get
            {
                if (_emailModel == null)
                    _emailModel = new EmailModel();
                return _emailModel;
            }
            set
            {
                _emailModel = value;
            }
        }

        public SmsModel SmsModel
        {
            get
            {
                if (_smsModel == null)
                    _smsModel = new SmsModel();
                return _smsModel;
            }
            set
            {
                _smsModel = value;
            }
        }
        #endregion

        #region Command Action
        public async void SmsQueueFunction()
        {

        }

        public async void EmailQueueFunction()
        {
            ResponseItem result = await _queue.EMailQueue(EmailModel);
            if (!result.Result)
            {
                await App.Current.MainPage.DisplayAlert("Giriş Başarısız .", "Yanlış Kullanıcı Adı veya Şifre", "Tamam");
                return;
            }
        }
        #endregion
    }
}