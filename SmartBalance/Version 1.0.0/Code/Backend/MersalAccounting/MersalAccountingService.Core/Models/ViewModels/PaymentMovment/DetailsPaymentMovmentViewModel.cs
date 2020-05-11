using Framework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels.PaymentMovment
{
	[DebuggerDisplay("Id={Id}")]
	public class DetailsPaymentMovmentViewModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Branch { get; set; }
        public string DelegateManReceiptNumber { get; set; }
        public string DelegateManName { get; set; }
        //Source
        public SourceType SourceType { get; set; }
        public String ReciptNumber { get; set; }


        public string  VendorName { get; set; }
        public string VenderAccountNumber { get; set; }

        public string AccountNumber { get; set; }
        //destination


        public decimal TotalAmount { get; set; }    
        public List<DetailsPaymentMovmentInventoryViewModel> Inventorys { get; set; }
        public List<DetailsPaymentMovmentCostCenterViewModel> CostCenters { get; set; }
        //payment 
        public int ReceivingMethodId { get; set; }     

        //props if cheque
        public string ChequeNumber { get; set; }
        //تاريخ الاستحقاق
        public DateTime? ChequeDuedate { get; set; }

        //prop if visa
        public string VisaNumber { get; set; }


        //in case of cash you need to set safe Id
        public  string SafeName { get; set; }
        public string SafeCode { get; set; }

        //in case of Visa or Chique you need to set Bank Id
        public string BankName { get; set; }
        public string BankCode { get; set; }

        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }

    }
}
