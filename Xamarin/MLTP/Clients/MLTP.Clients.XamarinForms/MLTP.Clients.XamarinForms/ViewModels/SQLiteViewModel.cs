using MLTP.Clients.XamarinForms.SQLiteManager.Manager;
using MLTP.Clients.XamarinForms.SQLiteManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MLTP.Clients.XamarinForms.ViewModels
{
    public class SQLiteViewModel : INotifyPropertyChanged
    {
        private readonly SQLiteModelManager sqliteManager;

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SQLiteViewModel()
        {
            sqliteManager = new SQLiteModelManager();
            _insertCommand = new Command(InsertAction);
            _deleteCommand = new Command(DeletetAction);
            _updateCommand = new Command(UpdatetAction);
            LoadData();
        }

        #region Fields
        SQLiteModel _sqliteModel;
        List<SQLiteModel> _liste;
        #endregion

        #region Encapsulation
        public SQLiteModel SqliteModel
        {
            get
            {
                if (_sqliteModel == null)
                    _sqliteModel = new SQLiteModel();
                return _sqliteModel;
            }
            set
            {
                _sqliteModel = value;
                onPropertyChanged();
            }
        }

        public ICommand InsertCommand
        {
            get => _insertCommand;
            set
            {
                if (_insertCommand == null)
                    return;

                _insertCommand = value;
            }
        }

        public ICommand DeleteCommand
        {
            get => _deleteCommand;
            set
            {
                if (_deleteCommand == null)
                    return;

                _deleteCommand = value;
            }
        }

        public ICommand UpdateCommand
        {
            get => _updateCommand;
            set
            {
                if (_updateCommand == null)
                    return;

                _updateCommand = value;
            }
        }

        public List<SQLiteModel> Liste
        {
            get
            {
                if (_liste == null)
                    _liste = new List<SQLiteModel>();
                return _liste;
            }
            set
            {
                _liste = value;
                onPropertyChanged();
            }
        }
        #endregion

        #region Command
        private ICommand _insertCommand;
        private ICommand _deleteCommand;
        private ICommand _updateCommand;
        #endregion

        #region Command Action
        public async void InsertAction()
        {
            await sqliteManager.Insert(SqliteModel);
            LoadData();
        }

        public async void DeletetAction(object param)
        {
            SQLiteModel model = (SQLiteModel)param;
            int result = sqliteManager.Delete(model.ID);
            LoadData();
        }

        public async void UpdatetAction(object param)
        {
            SQLiteModel model = (SQLiteModel)param;
            SqliteModel = model;
        }
        #endregion

        #region Other Function
        private async void LoadData()
        {
            Liste = sqliteManager.GetAll();
        }
        #endregion
    }
}