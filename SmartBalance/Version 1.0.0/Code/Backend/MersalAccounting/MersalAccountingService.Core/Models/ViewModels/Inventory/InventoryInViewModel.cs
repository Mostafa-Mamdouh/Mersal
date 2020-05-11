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
	public class InventoryInViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryInViewModel.
        /// </summary>
        public InventoryInViewModel()
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
		public Nullable<long> EntrancePermissionId { get; set; }
		public virtual EntrancePermissionViewModel EntrancePermission { get; set; }
		public string Description { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyInventoryInId { get; set; }
        public InventoryInViewModel ParentKeyInventoryIn { get; set; }


        public IList<InventoryInViewModel> ChildTranslatedInventoryIns { get; set; }
        #endregion

        #endregion
    }
}
