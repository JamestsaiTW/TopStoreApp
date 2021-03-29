namespace TopStoreApp.Models
{
    public class Person: Xam.Plugin.BaseBindingLibrary.BaseNotifyProperty
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged<string>(ref _name, value); }
        }

        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { OnPropertyChanged<string>(ref _tel, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged<string>(ref _email, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { OnPropertyChanged<string>(ref _address, value); }
        }

        public System.Windows.Input.ICommand DeleteCommand
        {
            get
            {
                return new Xamarin.Forms.Command(async () =>
                {
                    var isOk = await Xamarin.Forms.Shell.Current.DisplayAlert("警告", $"確定\"{Name}\"刪除?", "確定", "取消");
                    if (isOk)
                        Utilities.MockData.People.Remove(this);
                });
            }
        }
    }
}