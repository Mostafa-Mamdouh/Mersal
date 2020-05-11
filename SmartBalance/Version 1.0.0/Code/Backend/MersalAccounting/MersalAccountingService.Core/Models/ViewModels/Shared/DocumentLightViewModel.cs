#region using...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class DocumentLightViewModel : BaseViewModel
    {
        public long Id { get; set; }
        public int DocumentNumber { get; set; }

        public int CountReceipts { get; set; }
    }
}
