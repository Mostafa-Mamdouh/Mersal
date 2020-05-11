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
    public interface IBranchsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(BranchViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BranchViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<BranchViewModel> Get(ConditionFilter<Branch, int> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of BranchViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<BranchViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BranchLightViewModel> GetLightModel(ConditionFilter<Branch, int> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BranchLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a BranchViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BranchViewModel Get(int id);

        List<BranchLightViewModel> GetLookUp();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListBranchsLightViewModel> GetByFilter(BranchFilterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<BranchLightViewModel> GetAllUnSelectedBranchForUser(long userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<BranchViewModel> Add(IEnumerable<BranchViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BranchViewModel Add(BranchViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<BranchViewModel> Update(IEnumerable<BranchViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BranchViewModel Update(BranchViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<BranchViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<int> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(BranchViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        #endregion
    }
}
