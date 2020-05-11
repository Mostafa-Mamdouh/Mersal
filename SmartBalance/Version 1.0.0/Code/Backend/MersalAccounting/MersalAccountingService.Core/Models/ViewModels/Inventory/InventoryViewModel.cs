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
	public class InventoryViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryViewModel.
		/// </summary>
		public InventoryViewModel()
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

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
        public DateTime? Date { get; set; }

        public long? LocationId { get; set; }
        public virtual LocationViewModel Location { get; set; }


        public IList<SalesBillViewModel> SalesBills { get; set; }
		public long? AccountChartId { get; set; }
		public virtual AccountChartViewModel AccountChart { get; set; }

		//public IList<DonationInventory> Inventorys { get; set; }
		//public IList<PaymentMovmentInventory> PaymentMovmentInventorys { get; set; }

		public IList<PurchaseInvoiceViewModel> PurchaseInvoices { get; set; }
		public IList<PurchaseRebateViewModel> PurchaseRebates { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        public string Address { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyInventoryId { get; set; }
		public virtual InventoryViewModel ParentKeyInventory { get; set; }

		public IList<InventoryViewModel> ChildTranslatedInventorys { get; set; }
		#endregion

		#endregion
	}
}
