#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Interfaces
{
    public interface IPostingSignature
    {
        #region Properties
        bool IsPosted { get; set; }
        DateTime? PostingDate { get; set; }
        long? PostedByUserId { get; set; }
        #endregion
    }
}
