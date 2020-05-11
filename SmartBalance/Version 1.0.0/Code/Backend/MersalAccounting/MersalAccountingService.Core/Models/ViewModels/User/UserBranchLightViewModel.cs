using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class UserBranchLightViewModel : BaseViewModel
    {
        public long UserId { get; set; }
        public IList<NmaeValueViewModel> List { get; set; }
    }
}
