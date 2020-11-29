using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MagicAccount.PageModels.Base
{
    public  class PageModelBase : BindableObject
    {
        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isloading;
        public bool IsLoading { get => _isloading; set => SetProperty(ref _isloading, value); }





        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyname = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyname);
            return true;
        }

        public virtual Task InitializeAsync(object navigationdata)
        {
            return Task.CompletedTask;
        }
    }
}
