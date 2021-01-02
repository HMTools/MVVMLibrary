using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMLibrary.Models
{
    public class BaseMultiChildModel : BaseChildModel
    {
        #region Properties
        public string ParentType { get; set; }
        #endregion
    }
}
