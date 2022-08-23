using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TopStoreApp.ViewModels
{
    [QueryProperty(nameof(PersonId), "personId")]
    public class PersonDetailPageViewModel : BasePageViewModel
    {
        private Models.Person _editPerson;

        public Models.Person EditPerson
        {
            get { return _editPerson; }
            set { OnPropertyChanged<Models.Person>(ref _editPerson, value); }
        }

        public int PersonId
        {
            set
            {
                int personId = value;
                if (personId > 0)
                    EditPerson = Utilities.MockData.People.FirstOrDefault((person) => { return person.Id == personId; });
            }
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
