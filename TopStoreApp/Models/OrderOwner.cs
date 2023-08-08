using CommunityToolkit.Mvvm.ComponentModel;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class OrderOwner
{
    public string Owner { get; set; }

    public DateTime OrderDate { get; set; }

}

