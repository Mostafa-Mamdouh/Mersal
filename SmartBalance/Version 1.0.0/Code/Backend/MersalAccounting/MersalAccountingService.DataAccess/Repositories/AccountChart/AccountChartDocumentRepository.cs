#region using..
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
	public class AccountChartDocumentRepository : BaseServiceRepository<AccountChartDocument, long>, IAccountChartDocumentRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public AccountChartDocumentRepository(MersalAccountingContext context)
			: base(context)
		{

		}
	}
}
