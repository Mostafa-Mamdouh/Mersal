using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IServices
{
    public interface ITestamentService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(TestamentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListTestamentLightViewModel> GetByFilter(TestamentFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModelViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentViewModel> Get(ConditionFilter<Testament, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModelViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModelLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(ConditionFilter<Testament, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModelLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(int? pageIndex, int? pageSize);


        List<TestamentLightViewModel> GetLookUp();

        List<string> GetCodes(int advancesTypeId);

        string GenerateNewCode();

        /// <summary>
        /// Gets a TestamentViewModelViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestamentViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<TestamentViewModel> Add(IEnumerable<TestamentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TestamentViewModel Add(TestamentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<TestamentViewModel> Update(IEnumerable<TestamentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TestamentViewModel Update(TestamentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<TestamentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(TestamentViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
