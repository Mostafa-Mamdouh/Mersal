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
    public class InventoryOpeningBalanceCostCenterRepository : BaseServiceRepository<InventoryOpeningBalanceCostCenter, long>, IInventoryOpeningBalanceCostCenterRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventorysRepository.
		/// </summary>
		/// <param name="context"></param>
		public InventoryOpeningBalanceCostCenterRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
