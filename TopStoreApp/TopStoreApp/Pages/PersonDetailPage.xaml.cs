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
    public partial class PersonDetailPage : ContentPage
    {
        public PersonDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ViewModels.PersonDetailPageViewModel;
            if (vm.PersonId > 0)
                vm.EditPerson = (from person in Utilities.MockData.People
                                 where vm.PersonId == person.Id
                                 select person).FirstOrDefault();
        }
    }
}