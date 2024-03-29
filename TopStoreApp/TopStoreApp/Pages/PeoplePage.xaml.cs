﻿using System;
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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            vm.EditCommand.Execute(e.Item);
            (sender as ListView).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as ViewModels.PeoplePageViewModel;
            if (e.OldTextValue?.Length > 0 && e.NewTextValue?.Length == 0)
            {
                vm.SearchCommand.Execute(string.Empty);
                (sender as SearchBar).Unfocus();
            }
        }
    }
}