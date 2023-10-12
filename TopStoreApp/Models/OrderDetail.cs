using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class OrderDetailDisplay
{
    public string ProductName { get; set; }
    public decimal Quantity { get; set; }
    public int OrderDetailId { get; set; }
    public string Note { get; set; }
}

[INotifyPropertyChanged]
public partial class OrderDetailShow
{
    public int OrderDetailId { get; set; }
    public string ProductName { get; set; }
    public string ProductSn { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
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
    [Required(ErrorMessage = "數量為訂單明細必填資料")]
    [Range(1, double.MaxValue, ErrorMessage = "必須為 1 以上個數")]
    [NotNull]
    public decimal Quantity { get; set; }
    [Required(ErrorMessage = "價格為訂單明細必填資料")]
    [Range(0, double.MaxValue, ErrorMessage = "必須為 0 元以上數值")]
    [NotNull]
    public decimal Price { get; set; }
    public string Note { get; set; }
}