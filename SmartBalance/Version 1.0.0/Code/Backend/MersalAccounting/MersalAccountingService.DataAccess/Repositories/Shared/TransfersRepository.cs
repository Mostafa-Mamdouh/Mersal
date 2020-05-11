#region Using ...
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
    /// <summary>
    /// 
    /// </summary>
    public class TransfersRepository : BaseServiceRepository<Transfer, long>, ITransfersRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransfersRepository.
		/// </summary>
		/// <param name="context"></param>
		public TransfersRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
