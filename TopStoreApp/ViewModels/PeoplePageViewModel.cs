using System.Collections.ObjectModel;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

using TopStoreApp.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TopStoreApp.ViewModels;

public partial class PeoplePageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Person> _people;

    [RelayCommand]
    private async void Add()
    {
        await Shell.Current.GoToAsync("//People/PersonDetail?isEdit=true");
    }

    [RelayCommand]
    private async void Edit(Person person)
    {
        await Shell.Current.GoToAsync($"//People/PersonDetail?isEdit=false&personId={person.Id}");
    }

    [RelayCommand]
    private async void Delete(Person person)
    {
        var isOk = await Shell.Current.DisplayAlert("警告", $"確定\"{person.Name}\"刪除?", "確定", "取消");
        if (isOk)
        {
            App.DataService.DeletePerson(person);
            People = App.DataService.GetPeople();
        }
    }

    [RelayCommand]
    private void CallTel(Person person)
    {
        PhoneDialer.Open(person.Tel);
    }

    [RelayCommand]
    private async void Search(string keyword)
    {
        var results = App.DataService.GetPeople(keyword);
        if (results.Count != 0)
        {
            People = results;
            return;
        }
        await Shell.Current.DisplayAlert("通知", "查無相關聯絡人", "OK");
    }
}
