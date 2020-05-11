using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels.PaymentMovment
{
	[DebuggerDisplay("Id={Id}")]
	public  class ListPaymentMovmentLightViewModel : BaseViewModel
    {
        public long Id { get; set; }
        public string code { get; set; }
        public String ReciptNumber { get; set; }

        public string Source { get; set; }
        public string Branch { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Currancy { get; set; }

        public string PaymentMethod { get; set; }
        public SourceType SourceType { get; set; }
    }
}
