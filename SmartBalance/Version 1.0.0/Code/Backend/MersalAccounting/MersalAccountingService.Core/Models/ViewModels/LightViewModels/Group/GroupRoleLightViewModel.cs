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
 
namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// GroupRole, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class GroupRoleLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupRoleLightViewModel.
		/// </summary>
		public GroupRoleLightViewModel()
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
		public virtual RoleLightViewModel Role { get; set; }
		public Nullable<long> GroupId { get; set; }
		public virtual GroupLightViewModel Group { get; set; }


		
		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyGroupRoleId { get; set; }
		public GroupRoleLightViewModel ParentKeyGroupRole { get; set; }		
		#endregion

		#endregion
	}
}
