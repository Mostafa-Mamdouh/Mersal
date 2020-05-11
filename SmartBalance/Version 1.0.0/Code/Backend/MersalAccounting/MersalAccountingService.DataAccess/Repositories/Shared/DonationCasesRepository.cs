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
    public class DonationCasesRepository : BaseServiceRepository<DonationCase, long>, IDonationCasesRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DonationCasesRepository.
        /// </summary>
        /// <param name="context"></param>
        public DonationCasesRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
