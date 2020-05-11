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
	public class GroupPermissionViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupPermissionViewModel.
		/// </summary>
		public GroupPermissionViewModel()
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

		public Nullable<long> GroupId { get; set; }
		public virtual GroupViewModel Group { get; set; }
		public Nullable<long> PermissionId { get; set; }
		public virtual PermissionViewModel Permission { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyGroupPermissionId { get; set; }
		public GroupPermissionViewModel ParentKeyGroupPermission { get; set; }


		public IList<GroupPermissionViewModel> ChildTranslatedGroupPermissions { get; set; }
		#endregion

		#endregion
	}
}
