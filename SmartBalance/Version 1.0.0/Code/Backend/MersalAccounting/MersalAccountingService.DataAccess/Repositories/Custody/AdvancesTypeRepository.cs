using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Repositories
{
    public class AdvancesTypeRepository : BaseServiceRepository<AdvancesType, int>, IAdvancesTypeRepository
    {
        public AdvancesTypeRepository(MersalAccountingContext context)
            :base(context)
        {

        }
    }
}
