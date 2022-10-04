using SQLite;
using System.Collections.ObjectModel;
using TopStoreApp.Models;

namespace TopStoreApp.Services;

public class DbService : IDataService
{
    readonly SQLiteConnection sqliteDbConnection;
    public DbService()
    {
        var appRootDir = FileSystem.AppDataDirectory;
        var sqliteDbFullPath = System.IO.Path.Combine(appRootDir, "TopStoreDB.db");
        sqliteDbConnection = new SQLiteConnection(sqliteDbFullPath);

        sqliteDbConnection.CreateTable<Models.Person>();
    }

    public ObservableCollection<Models.Person> GetPeople(string keyword = "")
    {
        var people = sqliteDbConnection.Table<Models.Person>()
                                       .Where( person => person.Name.ToLower().Contains(keyword.ToLower()));
        return new ObservableCollection<Models.Person>(people);
    }

    public Models.Person GetPerson(int id)
    {
        return sqliteDbConnection.Table<Models.Person>()
                        .Where(p => p.Id == id)
                        .FirstOrDefault();
    }

    public int SavePerson(Models.Person person)
    {
        if (person.Id != 0)
            return sqliteDbConnection.Update(person);
        else
            return sqliteDbConnection.Insert(person);
    }

    public int DeletePerson(Models.Person person)
    {
        return sqliteDbConnection.Delete(person);
    }

    public Models.Person NewPerson() 
    {
        return new Models.Person();
    }

    public ObservableCollection<Product> GetGoods(string keyword = "")
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public int SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public int DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Product NewProduct()
    {
        throw new NotImplementedException();
    }
}
