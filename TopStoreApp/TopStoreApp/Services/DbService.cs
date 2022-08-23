using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Collections.ObjectModel;

namespace TopStoreApp.Services
{
    public class DbService
    {
        private static DbService _instance;
        public static DbService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DbService();
                return _instance;
            }
        }

        private DbService()
        {
            var appRootDir = Xamarin.Essentials.FileSystem.AppDataDirectory;
            var sqliteDbFullPath = System.IO.Path.Combine(appRootDir, "TopStoreDB.db");
            var sqliteConnection = new SQLiteConnection(sqliteDbFullPath);

            sqliteConnection.CreateTable<Models.Person>();
        }

        internal ObservableCollection<Models.Person> GetPeople(string keyword = "")
        {
            return new ObservableCollection<Models.Person>();
        }
    }
}
