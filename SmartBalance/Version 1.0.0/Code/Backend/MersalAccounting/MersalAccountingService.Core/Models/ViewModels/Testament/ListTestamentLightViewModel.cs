using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class ListTestamentLightViewModel : BaseViewModel
    {
        public long? Id { get; set; }

        public string Code { get; set; }

        public string AdvancesTypeName { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalValue { get; set; }
        public bool? IsClosed { get; set; }

        public string Description { get; set; }
    }
}
