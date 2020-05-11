#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICurrencyRatesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyId"></param>
        /// <param name="exchangeCurrencyId"></param>
        /// <returns></returns>
        CurrencyRateLightViewModel GetLatestCurrencyRate(long? currencyId, long? exchangeCurrencyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origenalAmount"></param>
        /// <param name="currency"></param>
        /// <param name="systemCurrency"></param>
        /// <returns></returns>
        LatestCurrencyRate GetLatestCurrencyRate(decimal origenalAmount, Currency currency,
            SystemCurrencySettingViewModel systemCurrency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(CurrencyRateViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListCurrencyRateLightViewModel> GetByFilter(CurrencyRateFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CurrencyRateViewModel> Get(ConditionFilter<CurrencyRate, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CurrencyRateViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyRateLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(ConditionFilter<CurrencyRate, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyRateLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a CurrencyRateViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CurrencyRateViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CurrencyRateViewModel> Add(IEnumerable<CurrencyRateViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CurrencyRateViewModel Add(CurrencyRateViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CurrencyRateViewModel> Update(IEnumerable<CurrencyRateViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CurrencyRateViewModel Update(CurrencyRateViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<CurrencyRateViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(CurrencyRateViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
