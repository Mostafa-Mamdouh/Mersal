using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("Id={Id}")]
	public class SalesBillViewModel : BaseViewModel
	{
		#region Constructors

		public SalesBillViewModel()
		{

		}

		#endregion

		#region Properties

		#region IPostingSignature
		public bool IsPosted { get; set; }
		public DateTime? PostingDate { get; set; }
		public long? PostedByUserId { get; set; }
		#endregion

		//public string Code { get; set; }

		public DateTime Date { get; set; }

		public bool HasCostCenter { get; set; }

		public List<long> CostCenterId { get; set; }

		//1 =>sale 0=>offer
		//check if bill is sales(true) or offer(false) 
		public bool SaleOrOffer { get; set; }

		public bool IsCash { get; set; }

		public bool? HasPercentage { get; set; }

		public decimal? Discount { get; set; }

		public decimal? ExtraExpenses { get; set; }

		public decimal BillPrice { get; set; }
		#region Relations

		public virtual ICollection<SalesBillProductViewModel> SalesBillProducts { get; set; }
		public long SalesBillTypeId { get; set; }
		public long InventoryId { get; set; }
		public long DelegateManId { get; set; }
		public long DonatorId { get; set; }
		#endregion

		#endregion
	}
}
