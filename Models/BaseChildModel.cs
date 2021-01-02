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
    }
}
