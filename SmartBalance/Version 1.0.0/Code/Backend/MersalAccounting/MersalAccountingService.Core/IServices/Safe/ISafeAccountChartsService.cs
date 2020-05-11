#region uing ...
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
#endregion

namespace MersalAccountingService.Core.IServices
{
    public interface ISafeAccountChartsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(SafeAccountChartViewModel model);

        GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(ConditionFilter<SafeAccountChart, long> condition);
        GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<SafeAccountChartViewModel> Get(ConditionFilter<SafeAccountChart, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<SafeAccountChartViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a BankViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<SafeAccountChartViewModel> Get(long bankId);

        List<AccountChartLightViewModel> GetAccountCharts(long bankId);

        SafeAccountChartViewModel Get(long bankId, long accountChartId);

        //List<BankLightViewModel> GetLookUp();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<SafeAccountChartViewModel> Add(IEnumerable<SafeAccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SafeAccountChartViewModel Add(SafeAccountChartViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<SafeAccountChartViewModel> Update(IEnumerable<SafeAccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SafeAccountChartViewModel Update(SafeAccountChartViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<SafeAccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(SafeAccountChartViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
