using Microsoft.Maui;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TopStoreApp.ViewModels
{
    [QueryProperty(nameof(IsEditQueryString), "isEdit")]
    [QueryProperty(nameof(PersonId), "personId")]
    public partial class PersonDetailPageViewModel : BasePageViewModel
    {
        [ObservableProperty]
        private Models.Person _editPerson;

        [ObservableProperty]
        private bool _isEdit;

        public string IsEditQueryString
        {
            set
            {
                IsEdit = bool.Parse(value);
            }
        }

        public int PersonId
        {
            set
            {
                int personId = value;
                if (personId > 0)
                    EditPerson = App.DataService.GetPerson(personId);
            }
        }

        public PersonDetailPageViewModel()
        {
            EditPerson = App.DataService.NewPerson();
        }

        [RelayCommand]
        private async void Save()
        {
            if (IsEdit)
            {
                var isValid = Utilities.ValidationHelper.IsValid(EditPerson, Shell.Current.CurrentPage);
                if (!isValid)
                    return;

                App.DataService.SavePerson(EditPerson);

                var isBack = await Shell.Current.DisplayAlert("通知", "儲存成功!",
                                                                    "返回聯絡人列表", "再檢視此筆資料");
                if (isBack)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
            IsEdit = !IsEdit;
        }
    }
}
