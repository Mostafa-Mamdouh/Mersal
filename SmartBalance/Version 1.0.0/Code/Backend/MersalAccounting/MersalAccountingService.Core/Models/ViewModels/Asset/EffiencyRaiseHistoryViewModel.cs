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
	public class EffiencyRaiseHistoryViewModel : BaseViewModel
	{
		#region Data Members

		#endregion

		#region Constructors
		public EffiencyRaiseHistoryViewModel()
		{

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

		public decimal? RaiseAmount { get; set; }
		public DateTime? RaiseDate { get; set; }

		#region Relations
		public long? AssetId { get; set; }
		public virtual AssetViewModel Asset { get; set; }
		#endregion

		#endregion
	}
}
