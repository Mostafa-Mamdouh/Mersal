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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class SalesBill : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesBill.
		/// </summary>
		public SalesBill()
		{
			this.SalesBillProducts = new HashSet<SalesBillProduct>();
			this.CostCenterBills = new HashSet<CostCenterBill>();
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

		public string Code { get; set; }

		public DateTime Date { get; set; }

		public bool HasCostCenter { get; set; }

		//1 =>sale 0=>offer
		//check if bill is sales(true) or offer(false) 
		public bool SaleOrOffer { get; set; }

		public bool IsCash { get; set; }

		public bool? HasPercentage { get; set; }

		public decimal? Discount { get; set; }

		public decimal? ExtraExpenses { get; set; }

		public decimal BillPrice { get; set; }

		#region Relations

		public long DonatorId { get; set; }

		public Donator Donator { get; set; }

		public long DelegateManId { get; set; }

		public DelegateMan DelegateMan { get; set; }

		public long InventoryId { get; set; }

		public Inventory Inventory { get; set; }

		public long SalesBillTypeId { get; set; }

		public SalesBillType SalesBillType { get; set; }


		public virtual ICollection<SalesBillProduct> SalesBillProducts { get; set; }
		public virtual ICollection<CostCenterBill> CostCenterBills { get; set; }
		#endregion

		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeySalesBillId { get; set; }
		//public virtual SalesBill ParentKeySalesBill { get; set; }


		//public virtual ICollection<Asset> ChildTranslatedSalesBills { get; set; }
		//#endregion

		#endregion
	}
}
