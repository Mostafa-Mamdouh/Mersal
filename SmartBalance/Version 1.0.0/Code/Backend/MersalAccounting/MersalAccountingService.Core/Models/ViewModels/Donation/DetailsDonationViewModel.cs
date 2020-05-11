#region Using ...
using Framework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Donation
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class DetailsDonationViewModel
	{
		#region Properties
		public long Id { get; set; }
		public DateTime Date { get; set; }
		public string Branch { get; set; }

		//Source
		public SourceType SourceType { get; set; }
		public string DonatorName { get; set; }
		public string DonatorAccountNumber { get; set; }

		public string VendorName { get; set; }
		public string VenderAccountNumber { get; set; }

		public string AccountNumber { get; set; }
		//destination

		public decimal GeneralAccountAmount { get; set; }

		public decimal TotalAmount { get; set; }
		public List<DetailsDonationInventoryViewModel> Inventorys { get; set; }
		public List<DetailsDonationProductViewModel> Products { get; set; }
		public List<DetailsDonationCostCenterViewModel> CostCenters { get; set; }
		public List<DetailsDonationCaseViewModel> Cases { get; set; }
		//payment 
		public int ReceivingMethodId { get; set; }

		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? ChequeDuedate { get; set; }

		//prop if visa
		public string VisaNumber { get; set; }


		//in case of cash you need to set safe Id
		public string SafeName { get; set; }
		public string SafeCode { get; set; }

		//in case of Visa or Chique you need to set Bank Id
		public string BankName { get; set; }
		public string BankCode { get; set; }

		public string DescriptionAR { get; set; }
		public string DescriptionEN { get; set; }
		#endregion
	}
}
