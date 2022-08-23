using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopStoreApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplePage : ContentPage
    {
        public PeoplePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            vm.People = Services.DbService.Instance.GetPeople();
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