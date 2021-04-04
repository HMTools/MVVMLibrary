using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMLibrary.Wrappers
{
    public class StringWrapper
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Properties
        private string val;

	    public string Value
	    {
		    get { return val;}
		    set { val = value; NotifyPropertyChanged();}
	    }

        #endregion

        #region Constructors
        public StringWrapper(string val = "")
        {
            Value = val;
        }
        #endregion
    }
}
