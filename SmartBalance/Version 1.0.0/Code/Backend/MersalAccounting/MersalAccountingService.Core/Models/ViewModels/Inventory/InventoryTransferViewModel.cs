#region Using ...
using Framework.Common.Enums;
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
	public class InventoryTransferViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryTransferViewModel.
        /// </summary>
        public InventoryTransferViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModificationDate { get; set; }
		#endregion


        public string Code { get; set; }
        public string Description { get; set; }

        public virtual Nullable<long> InventoryFromId { get; set; }
        public virtual InventoryViewModel InventoryFrom { get; set; }

        public virtual Nullable<long> InventoryToId { get; set; }
        public virtual InventoryViewModel InventoryTo { get; set; }


        public virtual ICollection<InventoryTransferCostCenterViewModel> InventoryTransferCostCenter { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyInventoryTransferId { get; set; }
        public InventoryTransferViewModel ParentKeyInventoryTransfer { get; set; }


        public IList<InventoryTransferViewModel> ChildTranslatedInventoryTransfers { get; set; }
        #endregion

        #endregion
    }
}
