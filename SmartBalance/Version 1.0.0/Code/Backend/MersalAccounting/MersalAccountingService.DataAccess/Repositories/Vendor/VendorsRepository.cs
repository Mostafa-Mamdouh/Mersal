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
    public class VendorsRepository : BaseServiceRepository<Vendor, long>, IVendorsRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type VendorsRepository.
		/// </summary>
		/// <param name="context"></param>
		public VendorsRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
