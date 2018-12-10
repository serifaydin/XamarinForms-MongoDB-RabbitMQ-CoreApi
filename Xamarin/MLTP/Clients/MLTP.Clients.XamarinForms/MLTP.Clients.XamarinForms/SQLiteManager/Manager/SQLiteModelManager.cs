using MLTP.Clients.XamarinForms.Helpers;
using MLTP.Clients.XamarinForms.SQLiteManager.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.SQLiteManager.Manager
{
    public class SQLiteModelManager
    {
        SQLiteConnection _sqliteConnection;

        public SQLiteModelManager()
        {
            _sqliteConnection = DependencyService.Get<ISQLiteConnection>().GetConnection();
            _sqliteConnection.CreateTable<SQLiteModel>();
        }

        public async Task<int> Insert(SQLiteModel model)
        {
            return _sqliteConnection.Insert(model);
        }

        public int Update(SQLiteModel model)
        {
            return _sqliteConnection.Update(model);
        }

        public int Delete(int Id)
        {
            return _sqliteConnection.Delete<SQLiteModel>(Id);
        }

        public List<SQLiteModel> GetAll()
        {
            return _sqliteConnection.Table<SQLiteModel>().ToList();
        }

        public SQLiteModel Get(int Id)
        {
            return _sqliteConnection.Table<SQLiteModel>().FirstOrDefault(f => f.ID == Id);
        }

        public void Dispose()
        {
            _sqliteConnection.Dispose();
        }
    }
}