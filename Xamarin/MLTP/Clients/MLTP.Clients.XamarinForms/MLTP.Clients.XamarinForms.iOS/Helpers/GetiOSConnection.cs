using MLTP.Clients.XamarinForms.Helpers;
using MLTP.Clients.XamarinForms.iOS.Helpers;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Xamarin.Forms.Dependency(typeof(GetiOSConnection))]
namespace MLTP.Clients.XamarinForms.iOS.Helpers
{
    public class GetiOSConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, App.SqliteDb);
            var platform = new SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}