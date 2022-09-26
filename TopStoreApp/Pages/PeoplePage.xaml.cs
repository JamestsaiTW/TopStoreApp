using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace TopStoreApp.Pages
{
    public partial class PeoplePage : ContentPage
    {
        private PeoplePage()
        {
            InitializeComponent();
        }

        public PeoplePage(ViewModels.PeoplePageViewModel peoplePageViewModel) : this()
        {
           BindingContext = peoplePageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            vm.People = App.DataService.GetPeople();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            vm.EditCommand.Execute(e.Item);
            (sender as ListView).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            if (e.NewTextValue?.Length == 0 && e.OldTextValue?.Length > 0)
            {
                vm.SearchCommand.Execute(string.Empty);
            }
        }
    }
}