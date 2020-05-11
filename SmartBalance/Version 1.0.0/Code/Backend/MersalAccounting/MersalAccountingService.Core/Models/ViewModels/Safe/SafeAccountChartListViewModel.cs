using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class SafeAccountChartListViewModel : BaseViewModel
    {
        public long safeId { get; set; }
        public IList<NmaeValueViewModel> List { get; set; }
    }
}
