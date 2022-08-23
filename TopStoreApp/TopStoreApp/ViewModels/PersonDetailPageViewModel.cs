using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TopStoreApp.ViewModels
{
    [QueryProperty(nameof(IsEditQueryString), "isEdit")]
    [QueryProperty(nameof(PersonId), "personId")]
    public class PersonDetailPageViewModel : BasePageViewModel
    {
        private Models.Person _editPerson;

        public Models.Person EditPerson
        {
            get { return _editPerson; }
            set { OnPropertyChanged<Models.Person>(ref _editPerson, value); }
        }

        private bool _isEdit;

        public bool IsEdit
        {
            get { return _isEdit; }
            set { OnPropertyChanged<bool>(ref _isEdit, value); }
        }

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
                    EditPerson = Utilities.MockData.GetPerson(personId);
            }
        }

        public PersonDetailPageViewModel()
        {
            EditPerson = Utilities.MockData.NewPerson();
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsEdit)
                    {
                        Utilities.MockData.EditPeople(EditPerson);
                        var isBack = await Shell.Current.DisplayAlert("通知", "儲存成功!",
                                                                            "返回聯絡人列表", "再檢視此筆資料");
                        if (isBack)
                            await Shell.Current.Navigation.PopAsync();
                    }
                    IsEdit = !IsEdit;
                });
            }
        }
    }
}
