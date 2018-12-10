namespace MLTP.Clients.XamarinForms.Models.Common
{
    public class AddUserDeviceRequestModel
    {
        public int UserId { get; set; }

        public string AppId { get; set; }

        public string PhoneModel { get; set; }

        public string PhoneVersion { get; set; }

        public string Platform { get; set; }
    }
}