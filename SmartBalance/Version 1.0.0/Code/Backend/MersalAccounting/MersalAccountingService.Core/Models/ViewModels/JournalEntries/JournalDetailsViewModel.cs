#region Using ..
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
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
	public class JournalDetailsViewModel
	{
		#region Properties
		public long Id { get; set; }
		public bool IsCreditor { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public decimal? Amount { get; set; }
		public decimal? CreditorValue { get; set; }
		public decimal? DebtorValue { get; set; }
		public string AccountFullCode { get; set; }

		public ObjectType? ObjectType { get; set; }
		public long? ObjectId { get; set; }


		public long AccountId { get; set; }
		public virtual AccountChartViewModel Account { get; set; }

		public long? CostCenterId { get; set; }
		public virtual CostCenterViewModel CostCenter { get; set; }
		#endregion
	}
}
