using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinFormsApi.Annotations;

namespace XamarinFormsApi.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title = string.Empty;

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _icon;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var chagned = PropertyChanged;

            chagned?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}