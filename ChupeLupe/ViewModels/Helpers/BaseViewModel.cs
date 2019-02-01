
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ChupeLupe.Helpers;
using ChupeLupe.Services;
using Xamarin.Forms;

namespace ChupeLupe.ViewModels.Helpers
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public IWebServicesApi WebApi { get; }
        public IDependencyServices DepedencyServiceWrapper { get; set; } // UNIT TEST


        public BaseViewModel(INavigation navigation, IDependencyServices dependencyServices)
        {

            DepedencyServiceWrapper = dependencyServices;

            Navigation = navigation;
            //WebApi = new WebServicesApi(); 
            WebApi = DepedencyServiceWrapper.Get<IWebServicesApi>();
        }

        protected bool SetValue<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}