using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace TopStoreApp.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        dataChoiceSwitch.IsToggled = Preferences.Get("UserSwitchToDataService", false);
    }

    private async void DataSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        var dataChoice = e.Value;

        var IsDbService = Preferences.Get("UserSwitchToDataService", false);
        if (IsDbService != dataChoice)
        {
            var isOk = await Shell.Current.DisplayAlert("警告", "此開關切換後，App 將會在 \"內建展示資料\" 與 \"實際真實資料\" 之間切換。", "確定", "取消");
            if (isOk)
            {
                Preferences.Set("UserSwitchToDataService", dataChoice);
                await Shell.Current.DisplayAlert("通知", "在關閉此通知之後，需立即手動重新啟動 App(包含從背景關閉)，以確保內建展示資料與真實紀錄資料之間切換能順利完成。", "OK");
            }
            else
            {
                dataChoiceSwitch.IsToggled = !dataChoice;
            }
        }
    }
}