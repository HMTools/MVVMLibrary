using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMLibrary.Models
{
    public class BaseChildModel : BaseModel
    {
        #region Properties
        public int ParentId { get; set; }
        #endregion

        #region Fields
        private bool isChanged = false;
        #endregion

        #region Methods
        public void Changed()
        {
            isChanged = true;
        }
        public bool GetChangedStatus()
        {
            return isChanged;
        }
        #endregion
    }
}
