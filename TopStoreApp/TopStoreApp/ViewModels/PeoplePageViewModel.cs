using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using TopStoreApp.Models;

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
                    await Shell.Current.GoToAsync($"//{Shell.Current.CurrentState.Location}/PersonDetailPage?isEdit=true");
                });
            }
        }
        public ICommand EditCommand
        {
            get
            {
                return new Command<Models.Person>(async (person) =>
                {
                    await Shell.Current.GoToAsync($"//{Shell.Current.CurrentState.Location}/PersonDetailPage?isEdit=false&personId={person.Id}");
                });
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command<string>((arg) =>
                {

                });
            }
        }

    }
}
