namespace MLTP.Clients.XamarinForms.Models.Common
{
    public class AuthenticateModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RolId { get; set; }
    }
}