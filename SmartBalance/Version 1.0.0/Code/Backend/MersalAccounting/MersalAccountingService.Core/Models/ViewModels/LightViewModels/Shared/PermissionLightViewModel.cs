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
	/// Permission, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PermissionLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PermissionLightViewModel.
		/// </summary>
		public PermissionLightViewModel()
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

        public long Value { get; set; }
		public string Name { get; set; }
		public int? Code { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyPermissionId { get; set; }
		public PermissionLightViewModel ParentKeyPermission { get; set; }		
		#endregion

		#endregion
	}
}
