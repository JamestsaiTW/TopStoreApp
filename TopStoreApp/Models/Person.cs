using System.ComponentModel.DataAnnotations;
using SQLite;

namespace TopStoreApp.Models
{
    public class Person : Maui.Plugin.BaseBindingLibrary.BaseNotifyProperty
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;
        [Required(ErrorMessage = "名稱是聯絡人必填資料")]
        [NotNull]
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged<string>(ref _name, value); }
        }

        private string _tel;
        [Required(ErrorMessage = "電話是聯絡人必填資料"), MinLength(4, ErrorMessage = "電話字數至少為 4 碼以上")]
        [NotNull]
        public string Tel
        {
            get { return _tel; }
            set { OnPropertyChanged<string>(ref _tel, value); }
        }

        private string _email;
        [EmailAddress(ErrorMessage = "Email 格式錯誤")]
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged<string>(ref _email, value); }
        }

        private string _address;
        [System.ComponentModel.DataAnnotations.MaxLength(100, ErrorMessage = "地址文字不可超過 100 個字")]
        public string Address
        {
            get { return _address; }
            set { OnPropertyChanged<string>(ref _address, value); }
        }
    }
}