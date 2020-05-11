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
	public class ExitPermissionViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExitPermissionViewModel.
        /// </summary>
        public ExitPermissionViewModel()
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
		public virtual IList<InventoryOutViewModel> InventoryOuts { get; set; }
		public string Description { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public bool IsApproved { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyExitPermissionId { get; set; }
        public ExitPermissionViewModel ParentKeyExitPermission { get; set; }


        public IList<ExitPermissionViewModel> ChildTranslatedExitPermissions { get; set; }
        #endregion

        #endregion
    }
}
