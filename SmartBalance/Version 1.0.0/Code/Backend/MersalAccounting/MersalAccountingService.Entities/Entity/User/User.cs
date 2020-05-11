#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a User entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المستخدمين
	 */
	public class User : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type User.
		/// </summary>
		public User()
		{
			this.ChildTranslatedUsers = new HashSet<User>();
            this.UserMenuItems = new HashSet<UserMenuItem>();
			this.UserGroups = new HashSet<UserGroup>();
			this.UserPermissions = new HashSet<UserPermission>();
            this.UserBranches = new HashSet<UserBranch>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

        
		public string Name { get; set; }
		public string UserName { get; set; }
		public bool IsActive { get; set; }
		public string Password { get; set; }
		public GenderEnum? Gender { get; set; }
		public Nullable<DateTime> BirthDate { get; set; }
        public bool IsTopAdmin { get; set; }
        public decimal? MaxPaymentLimit { get; set; }
        public string DefaultPageUrl { get; set; }

		//public int? BranchId { get; set; }
		//public virtual Branch Branch { get; set; }


		public virtual ICollection<UserMenuItem> UserMenuItems { get; set; }
		public virtual ICollection<UserGroup> UserGroups { get; set; }
		public virtual ICollection<UserPermission> UserPermissions { get; set; }
        public virtual ICollection<UserBranch> UserBranches { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyUserId { get; set; }
		public virtual User ParentKeyUser { get; set; }

 
		public virtual ICollection<User> ChildTranslatedUsers { get; set; }
		#endregion

		#endregion
	}
}
