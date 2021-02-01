using System;
using System.Collections.Generic;
using System.Text;
using WPFLibrary.Commands;

namespace MVVMLibrary.ViewModels
{
    public class BaseExpandableViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand ToggleExpandCommand { get; private set; }
        #endregion

        #region Properties
        private bool isExpanded;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set { isExpanded = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region Constructors
        public BaseExpandableViewModel (bool startExpanded = false, bool autoRefershCommands = false) : base(autoRefershCommands)
	    {
            IsExpanded = startExpanded;
	    }
	    #endregion

        #region Methods
        protected override void AddCommands()
        {
            base.AddCommands();
            ToggleExpandCommand = new RelayCommand(o => IsExpanded = !IsExpanded);
        }
        #endregion
    }
}
