using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IServices
{
	public interface IBankAccountChartService : IBaseService
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void ThrowExceptionIfExist(BankAccountChartViewModel model);

		GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(ConditionFilter<BankAccountChart, long> condition);
		GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BankAccountChartViewModel> Get(ConditionFilter<BankAccountChart, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BankAccountChartViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a BankViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		List<BankAccountChartViewModel> Get(long bankId);

        List<AccountChartLightViewModel> GetAccountCharts(long bankId);

		BankAccountChartViewModel Get(long bankId, long accountChartId);

		//List<BankLightViewModel> GetLookUp();


		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<BankAccountChartViewModel> Add(IEnumerable<BankAccountChartViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		BankAccountChartViewModel Add(BankAccountChartViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<BankAccountChartViewModel> Update(IEnumerable<BankAccountChartViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		BankAccountChartViewModel Update(BankAccountChartViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<BankAccountChartViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<long> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void Delete(BankAccountChartViewModel model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(long id);
		#endregion
	}
}
