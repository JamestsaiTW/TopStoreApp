using System.Collections.ObjectModel;

namespace TopStoreApp.Services;

public interface IDataService
{
    ObservableCollection<Models.Person> GetPeople(string keyword = "");
    Models.Person GetPerson(int id);
    int SavePerson(Models.Person person);
    int DeletePerson(Models.Person person);
    Models.Person NewPerson();

    ObservableCollection<Models.Product> GetGoods(string keyword = "");
    Models.Product GetProduct(int id);
    int SaveProduct(Models.Product product);
    int DeleteProduct(Models.Product product);
    Models.Product NewProduct();

    ObservableCollection<Models.SummaryOrder> GetSummaryOrders(DateTime? dateTime = null);
    ObservableCollection<Models.OrderOwner> GetOrderOwners(DateTime orderDate);
    ObservableCollection<Models.OrderDetailDisplay> GetOrderDetailDisplays(int orderId);
    Models.OrderDetailShow GetOrderDetailShow(int orderDetilId);
}
