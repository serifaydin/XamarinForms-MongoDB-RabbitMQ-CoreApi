using SQLite;

namespace MLTP.Clients.XamarinForms.Helpers
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}