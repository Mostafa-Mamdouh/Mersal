using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class TestamentViewModel : BaseViewModel
    {
        public long Id { get; set; }
        
        public string Code { get; set; }

        public decimal TotalValue { get; set; }

        public DateTime? Date { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public int AdvancesTypeId { get; set; }

        public long? VendorId { get; set; }

        public List<AdvanceViewModel> Advances { get; set; }

        public AddJournalEntriesViewModel Journal { get; set; }
    }
}
