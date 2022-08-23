using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TopStoreApp.ViewModels
{
    public class PersonDetailPageViewModel : BasePageViewModel
    {
        private Models.Person _editPerson;

        public Models.Person EditPerson
        {
            get { return _editPerson; }
            set { OnPropertyChanged<Models.Person>(ref _editPerson, value); }
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
                    Utilities.MockData.People.Add(EditPerson);
                    await Shell.Current.DisplayAlert("通知", "儲存成功", "OK");
                    await Shell.Current.GoToAsync("..");
                });
            }
        }
    }
}
