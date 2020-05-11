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
    public interface IStockAssessmentPolicysService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(StockAssessmentPolicyViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<StockAssessmentPolicyViewModel> Get(ConditionFilter<StockAssessmentPolicy, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of StockAssessmentPolicyViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<StockAssessmentPolicyViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<StockAssessmentPolicyLightViewModel> GetLightModel(ConditionFilter<StockAssessmentPolicy, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of StockAssessmentPolicyLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<StockAssessmentPolicyLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a StockAssessmentPolicyViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StockAssessmentPolicyViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<StockAssessmentPolicyViewModel> Add(IEnumerable<StockAssessmentPolicyViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        StockAssessmentPolicyViewModel Add(StockAssessmentPolicyViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<StockAssessmentPolicyViewModel> Update(IEnumerable<StockAssessmentPolicyViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        StockAssessmentPolicyViewModel Update(StockAssessmentPolicyViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<StockAssessmentPolicyViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(StockAssessmentPolicyViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
