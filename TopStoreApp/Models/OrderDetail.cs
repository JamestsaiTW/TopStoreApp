using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class OrderDetailDisplay
{
    public string ProductName { get; set; }
    public decimal Quantity { get; set; }
    public int OrderDetailId { get; set; }
    public string Note { get; set; }
}
public class OrderDetail
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public int OrderId { get; set; }
    [NotNull]
    public int ProductId { get; set; }
    [NotNull]
    public decimal Quantity { get; set; }
    [NotNull]
    public decimal Price { get; set; }
    public string Note { get; set; }
}