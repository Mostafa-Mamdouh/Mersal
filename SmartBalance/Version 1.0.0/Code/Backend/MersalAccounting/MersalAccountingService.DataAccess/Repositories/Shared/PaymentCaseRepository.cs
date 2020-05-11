#region Using ...
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
	/// <summary>
	/// 
	/// </summary>
    public class PaymentCaseRepository : BaseServiceRepository<PaymentCase, long>, IPaymentCaseRepository
    {
        #region Constructors
        public PaymentCaseRepository(MersalAccountingContext context) : base(context)
        {
        }
        #endregion
    }
}
