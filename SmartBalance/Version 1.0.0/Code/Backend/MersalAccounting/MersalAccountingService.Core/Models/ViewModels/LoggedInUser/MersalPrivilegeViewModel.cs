#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	[Obsolete]
	[DebuggerDisplay("Id={Id}")]
	public class MersalPrivilegeViewModel
    {
        #region Constructors
        public MersalPrivilegeViewModel()
        {

        }
        #endregion

        #region Properties         
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameOther { get; set; }
        public string Description { get; set; }
        public string DescriptionOther { get; set; }
        public string ControlId { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
