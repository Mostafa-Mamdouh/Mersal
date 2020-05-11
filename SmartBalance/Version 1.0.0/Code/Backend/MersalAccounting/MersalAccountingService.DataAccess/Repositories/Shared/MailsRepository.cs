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
    public class MailsRepository : BaseServiceRepository<Mail, long>, IMailsRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MailsRepository.
		/// </summary>
		/// <param name="context"></param>
		public MailsRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
