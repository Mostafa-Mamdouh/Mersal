#region Using ...
using Framework.Core.IRepositories.Base;
using MersalAccountingService.Core.IRepositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IRepositories
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICurrencyRatesRepository : IBaseServiceRepository<CurrencyRate, long>
	{

	}
}
