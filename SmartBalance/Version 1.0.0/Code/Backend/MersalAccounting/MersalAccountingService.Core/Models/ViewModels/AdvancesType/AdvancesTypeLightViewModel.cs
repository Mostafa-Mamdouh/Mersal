using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class AdvancesTypeLightViewModel : BaseViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
