#region Using ...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Entities.Entity;
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PurchaseInvoiceLookupLightViewModel : BaseViewModel
	{
		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		public string Code { get; set; }
		public string FullCode { get; set; }
		public string DisplyedName { get; set; }
		public DateTime Date { get; set; }

		public decimal TaxAmount { get; set; }
		public decimal NetAmount { get; set; }


		public List<BrandLightViewModel> Brands { get; set; }

		public Nullable<long> VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }
		#endregion
	}
}
