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
	public class UserGroupViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserGroupViewModel.
        /// </summary>
        public UserGroupViewModel()
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
		public Nullable<long> UserId { get; set; }
		public virtual UserViewModel User { get; set; }
		public Nullable<long> GroupId { get; set; }
		public virtual GroupViewModel Group { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyUserGroupId { get; set; }
        public UserGroupViewModel ParentKeyUserGroup { get; set; }


        public IList<UserGroupViewModel> ChildTranslatedUserGroups { get; set; }
        #endregion

        #endregion
    }
}
