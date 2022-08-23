using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using TopStoreApp.Models;
using System.Linq;

namespace TopStoreApp.ViewModels
{
    public class PeoplePageViewModel : BasePageViewModel
    {
        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { OnPropertyChanged<ObservableCollection<Person>>(ref _people, value); }
        }

        public PeoplePageViewModel()
        {
            People = Utilities.MockData.People;
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.GoToAsync("PersonDetailPage?isEdit=true");
                });
            }
        }


        public ICommand EditCommand
        {
            get
            {
                return new Command<Models.Person>(async (person) =>
                {
                    await Shell.Current.GoToAsync($"PersonDetailPage?isEdit=true&personId={person.Id}");
                });
            }
        }
        public ICommand CallTelCommand
        {
            get
            {
                return new Command<Person>((person) =>
                {
                    Xamarin.Essentials.PhoneDialer.Open(person.Tel);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command<Person>(async (person) =>
                {
                    var isOk = await Shell.Current.DisplayAlert("警告", $"確定\"{person.Name}\"刪除?", "確定", "取消");
                    if (isOk)
                    {
                        Utilities.MockData.People.Remove(person);
                    }
                });
            }
        }
    }
}
