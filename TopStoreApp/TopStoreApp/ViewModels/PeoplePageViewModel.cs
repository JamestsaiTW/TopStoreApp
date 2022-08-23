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
            People = new ObservableCollection<Models.Person>()
            {
                new Models.Person {Id = 1, Name = "James Tsai" , Address = "台北市信義區忠孝東路100號" , Tel = "02-22233311" , Email= "Jamestsai@abc.com.tw"},
                new Models.Person {Id = 2, Name = "Andy Kao" , Address = "新北市永和區中和路100號" , Tel = "02-77733311" , Email= "Andykao@abc.com.tw"},
                new Models.Person {Id = 3, Name = "John Chang" , Address = "新竹市東區風城路100號" , Tel = "03-33355511" , Email= "Johnchang@abc.com.tw"},
                new Models.Person {Id = 4, Name = "Da Wang" , Address = "台中市北區松江路100號" , Tel = "04-88833311" , Email= "Dawang@abc.com.tw"},
                new Models.Person {Id = 5, Name = "Mandy Q" , Address = "台南市西區中正路100號" , Tel = "06-66633311" , Email= "Mandyq@abc.com.tw"},
            };
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }


        public ICommand EditCommand
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
