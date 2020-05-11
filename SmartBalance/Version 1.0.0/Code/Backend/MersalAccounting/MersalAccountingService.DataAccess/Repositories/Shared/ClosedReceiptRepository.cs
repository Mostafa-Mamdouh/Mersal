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
    public class ClosedReceiptRepository : BaseServiceRepository<ClosedReceipt, long>, IClosedReceiptRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedReceiptRepository.
        /// </summary>
        /// <param name="context"></param>
        public ClosedReceiptRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
