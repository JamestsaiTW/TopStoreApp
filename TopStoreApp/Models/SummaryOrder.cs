using CommunityToolkit.Mvvm.ComponentModel;

namespace TopStoreApp.Models;

[INotifyPropertyChanged]
public partial class SummaryOrder
{
    public string Summary { get; set; }

    public int Count { get; set; }
}

