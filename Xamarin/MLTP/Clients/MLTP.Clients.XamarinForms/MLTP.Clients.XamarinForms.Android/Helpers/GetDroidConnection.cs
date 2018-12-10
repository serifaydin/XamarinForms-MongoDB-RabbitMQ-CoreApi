using MLTP.Clients.XamarinForms.Droid.Helpers;
using MLTP.Clients.XamarinForms.Helpers;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(GetDroidConnection))]
namespace MLTP.Clients.XamarinForms.Droid.Helpers
{
    public class GetDroidConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = System.IO.Path.Combine(documentPath, App.SqliteDb);

                var connection = new SQLiteConnection(path, false);

                return connection;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}