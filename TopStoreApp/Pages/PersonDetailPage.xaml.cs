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
    public partial class PersonDetailPage : ContentPage
    {
        private PersonDetailPage()
        {
            InitializeComponent();
        }

        public PersonDetailPage(ViewModels.PersonDetailPageViewModel personDetailPageViewModel) : this()
        {
            BindingContext = personDetailPageViewModel;
        }
    }
}