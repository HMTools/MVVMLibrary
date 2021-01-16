using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPFLibrary.Commands;

namespace MVVMLibrary.ViewModels
{
    public class BaseGridColumnViewModel : BaseViewModel
    {
        #region Commands
        public RelayCommand ToggleShowCommand { get; private set; }
        #endregion

        #region Properties

        private bool isShown = false;
        public bool IsShown
        {
            get { return isShown; }
            set { isShown = value; NotifyPropertyChanged(); NotifyPropertyChanged("ColMinWidth"); NotifyPropertyChanged("ColWidth"); }
        }

        public int ColMinWidth
        {
            get { return IsShown ? colMinWidth : 0; }
        }


        private GridLength colWidth = new GridLength(1, GridUnitType.Star);

        public GridLength ColWidth
        {
            get { return IsShown ? colWidth : new GridLength(0); }
            set
            {
                if (IsShown)
                {
                    colWidth = value; NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Fields
        private int colMinWidth;
        #endregion

        #region Constructors
        public BaseGridColumnViewModel(int columnMinWidth, GridLength columnWidth)
        {
            colMinWidth = columnMinWidth;
            ColWidth = columnWidth;
        }
        #endregion

        #region Methods
        protected override void AddCommands()
        {
            base.AddCommands();
            ToggleShowCommand = new RelayCommand(o => IsShown = !IsShown);
        }
        #endregion
    }
}
