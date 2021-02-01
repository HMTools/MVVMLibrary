using MVVMLibrary.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMLibrary.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            if (autoRefreshCommands)
                RefreshCommands();
        }
        #endregion

        #region Fields
        private readonly bool autoRefreshCommands = false;
        #endregion

        #region Constructors
        public BaseViewModel(bool autoRefreshCommands = false)
        {
            this.autoRefreshCommands = autoRefreshCommands;
            AddCommands();
        }
        #endregion

        #region Methods
        protected virtual void AddCommands() { }
        protected virtual void AddDelegates() { }
        protected virtual void SetPropertyAnnotation()
        {
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                foreach (var attribute in property.GetCustomAttributes<NotifyAttribute>())
                {

                    AddAnnotation(property.GetValue(this) as INotifyPropertyChanged, attribute.NotifyNames);
                }
            }
        }
        protected void AddAnnotation(INotifyPropertyChanged changer, string[] notifieNames, string propertyName = "")
        {
            AddAnnotation(changer, notifieNames, new string[] { propertyName });
        }

        protected void AddAnnotation(INotifyPropertyChanged changer, string[] notifieNames, string[] propertiesNames)
        {
            if (changer != null && notifieNames != null)
            {
                changer.PropertyChanged += (s, e) =>
                {

                    if (propertiesNames[0] == "" || propertiesNames.Any(name => name.Equals(e.PropertyName)))
                        foreach (var name in notifieNames)
                            NotifyPropertyChanged(name);
                };
            }
        }
        protected void RefreshCommands()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() => 
            {
                System.Windows.Input.CommandManager.InvalidateRequerySuggested();
            });
        }
        #endregion
    }
}
