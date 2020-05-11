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
	public class EntrancePermissionViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type EntrancePermissionViewModel.
        /// </summary>
        public EntrancePermissionViewModel()
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

		public string Name { get; set; }
		//public Nullable<long> PurchaseInvoiceId { get; set; }
		//public virtual PurchaseInvoiceViewModel PurchaseInvoice { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public bool IsApproved { get; set; }
		public string Description { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyEntrancePermissionId { get; set; }
        public EntrancePermissionViewModel ParentKeyEntrancePermission { get; set; }


        public IList<EntrancePermissionViewModel> ChildTranslatedEntrancePermissions { get; set; }
        #endregion

        #endregion
    }
}
