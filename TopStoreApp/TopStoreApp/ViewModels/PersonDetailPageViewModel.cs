using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TopStoreApp.ViewModels
{
    [QueryProperty("IsEditQueryString", "isEdit")]
    [QueryProperty("PersonId", "personId")]
    public class PersonDetailPageViewModel : BasePageViewModel
    {
        private Models.Person _editPerson;

        public Models.Person EditPerson
        {
            get { return _editPerson; }
            set { OnPropertyChanged<Models.Person>(ref _editPerson, value); }
        }

        private int _personId;

        public int PersonId
        {
            get { return _personId; }
            set { _personId = (int)value; }
        }

        public string IsEditQueryString
        {
            set
            {
                IsEdit = bool.Parse(value);
            }
        }

        private bool _isEdit;

        public bool IsEdit
        {
            get { return _isEdit; }
            set { OnPropertyChanged<bool>(ref _isEdit, value); }
        }


        public PersonDetailPageViewModel()
        {
            EditPerson = new Models.Person();
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsEdit)
                    {
                        Utilities.MockData.People.Add(EditPerson);
                        await Shell.Current.DisplayAlert("通知", "新增成功!", "OK");
                    }
                    IsEdit = !IsEdit;
                });
            }
        }
    }
}
