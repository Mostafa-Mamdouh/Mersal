#region Using ...
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
	public class ListAssetLocationsLightViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }

		public string Description { get; set; }
		public DateTime? Date { get; set; }
		//public string DisplyedName { get; set; }

		public virtual long? AssetId { get; set; }
		public virtual string Asset { get; set; }


		public long? LocationId { get; set; }
		public virtual string Location { get; set; }
		#endregion
	}
}
