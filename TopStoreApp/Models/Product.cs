using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class Product
{
    /// <summary>
    /// 資料序號
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 商品編號
    /// </summary>
    private string _sn;

    [Required(ErrorMessage = "商品編號是必填資料"), StringLength(50, ErrorMessage = "商品編號為 2 字以上",
              ErrorMessageResourceName = "商品編號不得超過 50 字", MinimumLength = 2)]
    public string Sn
    {
        get { return _sn; }
        set { SetProperty<string>(ref _sn, value); }
    }

    /// <summary>
    /// 商品名稱
    /// </summary>
    private string _name;

    [Required(ErrorMessage = "商品名稱必填資料"), StringLength(100, ErrorMessage = "商品名稱至少為 2 字以上" , 
              ErrorMessageResourceName = "商品名稱不得超過 100 字", MinimumLength = 2)]
    public string Name
    {
        get { return _name; }
        set { SetProperty<string>(ref _name, value); }
    }

    /// <summary>
    /// 商品照片(預設值為 tmp.jpg)
    /// </summary>
    private string _images;
    public string Images
    {
        get { return _images; }
        set { SetProperty<string>(ref _images, value); }
    }

    /// <summary>
    /// 商品售價
    /// </summary>
    private decimal _price;

    [Required(ErrorMessage = "商品售價必填資料"), Range(0, double.MaxValue, ErrorMessage = "必須為 0 元以上數值" )]
    public decimal Price
    {
        get { return _price; }
        set { SetProperty<decimal>(ref _price, value); }
    }

    /// <summary>
    /// 商品建議售價 "Manufacturer's Suggested Retail Price" 之縮寫 
    /// </summary>
    private decimal _msrp;

    [Range(0, double.MaxValue, ErrorMessage = "必須為 0 元以上數值")]
    public decimal Msrp
    {
        get { return _msrp; }
        set { SetProperty<decimal>(ref _msrp, value); }
    }

    /// <summary>
    /// 商品單位，範例: 罐、包、帶、袋、克、公克、台斤、公斤、磅、條...等
    /// </summary>
    private string _unit;
    [Required(ErrorMessage = "商品單位為必填資料"), StringLength(40, ErrorMessage = "商品單位至少為 1 字以上", 
              ErrorMessageResourceName = "商品單位不得超過 40 字", MinimumLength = 1)]
    public string Unit
    {
        get { return _unit; }
        set { SetProperty<string>(ref _unit, value); }
    }


    /// <summary>
    /// 包裝個數
    /// </summary>
    private int _package;
    [Range(1, int.MaxValue, ErrorMessage = "必須為 1 為單位以上數值")]
    public int Package
    {
        get { return _package; }
        set { SetProperty<int>(ref _package, value); }
    }

    /// <summary>
    /// 商品備註
    /// </summary>
    private string _note;

    [StringLength(500, ErrorMessage = "商品備註不得超過 500 字")]
    public string Note
    {
        get { return _note; }
        set { SetProperty<string>(ref _note, value); }
    }
}
