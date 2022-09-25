using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TopStoreApp.Services
{
    public interface IDataService
    {
        ObservableCollection<Models.Person> GetPeople(string keyword = "");
        Models.Person GetPerson(int id);
        int SavePerson(Models.Person person);
        int DeletePerson(Models.Person person);
        Models.Person NewPerson();
    }
}
