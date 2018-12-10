using SQLite;

namespace MLTP.Clients.XamarinForms.SQLiteManager.Models
{
    public class SQLiteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}