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
	public class MersalMenuItemViewModel
    {
        #region Constructors
        public MersalMenuItemViewModel()
        {

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameOther { get; set; }
        public bool IsActive { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string URL { get; set; }
        public Nullable<int> ApplicationId { get; set; }
        public string Icon { get; set; }
        public int ItemOrder { get; set; }
        public Nullable<int> ParentId { get; set; }
        public MersalMenuItemViewModel Parent { get; set; }
        public bool allowAnonymous { get; set; }
        #endregion
    }
}
