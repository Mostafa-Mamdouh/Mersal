#region using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    [DebuggerDisplay("UserId={UserId}, OldPassword={OldPassword}, NewPassword={NewPassword}")]
    public class ChangePasswordViewModel : BaseViewModel
    {
        public long UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
