using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class SummaryOrder
{
    public DateTime Summary { get; set; }

    public int Count { get; set; }
}

[INotifyPropertyChanged]
public partial class OrderOwner
{
    public string Owner { get; set; }
    //public DateTime OrderDate { get; set; }
    public int OrderId { get; set; }
}

public class Order
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public int PersonId { get; set; }
    [NotNull]
    public DateTime OrderDate { get; set; }
}

