#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
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
	[DebuggerDisplay("Id={Id}, Name={Name}, Type={Type}")]
	public class InventoryMovementTypeViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryMovementTypeViewModel.
        /// </summary>
        public InventoryMovementTypeViewModel()
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
		public string Description { get; set; }
        public InventoryMovementTypeEnum? Type { get; set; }


        public virtual IList<InventoryMovementViewModel> InventoryMovement { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyInventoryMovementTypeId { get; set; }
        public InventoryMovementTypeViewModel ParentKeyInventoryMovementType { get; set; }


        public IList<InventoryMovementTypeViewModel> ChildTranslatedInventoryMovementTypes { get; set; }
        #endregion

        #endregion
    }
}
