#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class InventoryOpeningBalanceLookupViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryOpeningBalanceLookupViewModel.
        /// </summary>
        public InventoryOpeningBalanceLookupViewModel()
        {

        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        public string Code { get; set; }
        public string BillNumber { get; set; }
        public long? InventoryId { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public IList<ProductViewModel> Products { get; set; }
        #endregion
    }
}
