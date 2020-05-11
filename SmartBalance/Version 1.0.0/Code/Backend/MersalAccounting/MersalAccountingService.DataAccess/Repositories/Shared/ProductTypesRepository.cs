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
    public class ProductTypesRepository : BaseServiceRepository<ProductType, long>, IProductTypesRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ProductTypesRepository.
		/// </summary>
		/// <param name="context"></param>
		public ProductTypesRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
