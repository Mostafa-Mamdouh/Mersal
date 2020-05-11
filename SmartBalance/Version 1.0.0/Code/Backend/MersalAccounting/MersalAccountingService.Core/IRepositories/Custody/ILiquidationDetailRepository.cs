#region using...
using MersalAccountingService.Core.IRepositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IRepositories
{
    public interface ILiquidationDetailRepository : IBaseServiceRepository<LiquidationDetail, long>
    {
    }
}
