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
	/// MenuItem, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class MenuItemLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MenuItemLightViewModel.
		/// </summary>
		public MenuItemLightViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		//public DateTime CreationDate { get; set; }
		//public DateTime? FirstModificationDate { get; set; }
		//public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public string Title { get; set; }
		public string ResourceKey { get; set; }
		public string Code { get; set; }
		//public string Description { get; set; }
		public bool? IsActive { get; set; }
		public string AreaName { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public string URL { get; set; }
		public string RootUrl { get; set; }
		public string OnErrorGoToURL { get; set; }
		public Nullable<long> ApplicationId { get; set; }
		public string Icon { get; set; }
		public int? ItemOrder { get; set; }
		public bool? AllowAnonymous { get; set; }

		public Nullable<long> ParentMenuItemId { get; set; }
		public MenuItemLightViewModel ParentMenuItem { get; set; }

		public string DisplyedName { get; set; }
		public long Value { get; set; }




		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyMenuItemId { get; set; }
		//public virtual MenuItemLightViewModel ParentKeyMenuItem { get; set; }
		#endregion

		#endregion
	}
}
