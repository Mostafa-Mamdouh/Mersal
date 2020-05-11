#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
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
	public class ChecksUnderCollectionViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public DateTime Date { get; set; }
		public string code { get; set; }


		//public long? DonatorId { get; set; }
		//public virtual DonatorLightViewModel Donator { get; set; }



		// public long? AccountChartId { get; set; }
		// public virtual AccountChartLightViewModel AccountChart { get; set; }


		public long? CurrencyId { get; set; }
		public virtual CurrencyLightViewModel Currency { get; set; }

		#region Receiving Method Of Payment

		public int? ReceivingMethodId { get; set; }
		public virtual ReceivingMethodLightViewModel ReceivingMethod { get; set; }

		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }
		public long? ChequeToBankId { get; set; }
		public BankLightViewModel ChequeToBank { get; set; }
		public bool Exchangeable { get; set; }
		//prop if visa
		public string VisaNumber { get; set; }


		//in case of Visa or Chique you need to set Bank Id
		public long? BankId { get; set; }
		public string Bank { get; set; }

		//المبلغ المدفوع
		public decimal Amount { get; set; }
		#endregion

		#endregion
	}
}
