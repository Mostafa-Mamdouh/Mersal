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
	public class InventoryDifferenceViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryDifferenceViewModel.
        /// </summary>
        public InventoryDifferenceViewModel()
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
		public Nullable<long> InventoryMovementId { get; set; }
		public virtual InventoryMovementViewModel InventoryMovement { get; set; }
		public Nullable<long> ProductId { get; set; }
		public virtual ProductViewModel Product { get; set; }
		public byte Type { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyInventoryDifferenceId { get; set; }
        public InventoryDifferenceViewModel ParentKeyInventoryDifference { get; set; }


        public IList<InventoryDifferenceViewModel> ChildTranslatedInventoryDifferences { get; set; }
        #endregion

        #endregion
    }
}
