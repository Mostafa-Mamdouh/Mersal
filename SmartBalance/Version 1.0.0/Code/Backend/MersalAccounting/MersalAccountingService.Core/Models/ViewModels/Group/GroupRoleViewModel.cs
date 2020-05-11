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
	public class GroupRoleViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type GroupRoleViewModel.
        /// </summary>
        public GroupRoleViewModel()
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
		public Nullable<long> GroupId { get; set; }
		public virtual GroupViewModel Group { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyGroupRoleId { get; set; }
        public GroupRoleViewModel ParentKeyGroupRole { get; set; }


        public IList<GroupRoleViewModel> ChildTranslatedGroupRoles { get; set; }
        #endregion

        #endregion
    }
}
