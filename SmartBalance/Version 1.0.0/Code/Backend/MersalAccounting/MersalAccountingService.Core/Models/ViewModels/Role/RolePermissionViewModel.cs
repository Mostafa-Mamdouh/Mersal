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
	public class RolePermissionViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type RolePermissionViewModel.
        /// </summary>
        public RolePermissionViewModel()
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
		public Nullable<long> RoleId { get; set; }
		public virtual RoleViewModel Role { get; set; }
		public Nullable<long> PermissionId { get; set; }
		public virtual PermissionViewModel Permission { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyRolePermissionId { get; set; }
        public RolePermissionViewModel ParentKeyRolePermission { get; set; }


        public IList<RolePermissionViewModel> ChildTranslatedRolePermissions { get; set; }
        #endregion

        #endregion
    }
}
