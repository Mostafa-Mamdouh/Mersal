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
    public interface ITestamentExtractionService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(TestamentExtractionViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentExtractionViewModel> GetByFilter(TestamentExtractionFilterViewModel model);


        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(ConditionFilter<TestamentExtraction, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(int? pageIndex, int? pageSize);
        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentExtractionViewModel> Get(ConditionFilter<TestamentExtraction, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentExtractionViewModel> Get(int? pageIndex, int? pageSize);


        TestamentExtractionViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<TestamentExtractionViewModel> Add(IEnumerable<TestamentExtractionViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TestamentExtractionViewModel Add(TestamentExtractionViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<TestamentExtractionViewModel> Update(IEnumerable<TestamentExtractionViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TestamentExtractionViewModel Update(TestamentExtractionViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<TestamentExtractionViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(TestamentExtractionViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
