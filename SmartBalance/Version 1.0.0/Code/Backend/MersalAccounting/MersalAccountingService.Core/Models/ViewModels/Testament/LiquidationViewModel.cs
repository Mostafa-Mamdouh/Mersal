using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using MersalAccountingService.Core.Models.ViewModels.PaymentMovment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class LiquidationViewModel : BaseViewModel
    {
        public LiquidationViewModel()
        {
            this.LiquidationDetails = new List<LiquidationDetailViewModel>();
        }
        public long Id { get; set; }

        public List<LiquidationDetailViewModel> LiquidationDetails { get; set; }

        public string Code { get; set; }

        public decimal TotalAmount { get; set; }

        public LiquidationTypeEnum? LiquidationType { get; set; }

        public List<AddPaymentMovmentViewModel> PaymentMovements { get; set; }

        public AddJournalEntriesViewModel Journal { get; set; }
    }
}
