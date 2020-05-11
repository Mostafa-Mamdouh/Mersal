#region using...
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
    public class ClosedChequeRepository : BaseServiceRepository<ClosedCheque, long>, IClosedChequeRepository
    {
        #region Constructors
        public ClosedChequeRepository(MersalAccountingContext context)
            :base(context)
        {

        }
        #endregion
    }
}
