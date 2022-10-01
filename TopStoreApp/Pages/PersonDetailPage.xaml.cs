using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace TopStoreApp.Pages;

public partial class PersonDetailPage : ContentPage
{
    private PersonDetailPage()
    {
        InitializeComponent();
    }

    public PersonDetailPage(ViewModels.PersonDetailPageViewModel personDetailPageViewModel) : this()
    {
        BindingContext = personDetailPageViewModel;
    }
}