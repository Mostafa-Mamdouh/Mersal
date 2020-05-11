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
    public interface IBankMovementBankMovementCostCentersService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(BankMovementCostCentersViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankMovementCostCentersViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<BankMovementCostCentersViewModel> Get(ConditionFilter<BankMovementCostCenters, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of BankMovementCostCentersViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<BankMovementCostCentersViewModel> Get(int? pageIndex, int? pageSize);


        /// <summary>
        /// Gets a BankMovementCostCentersViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BankMovementCostCentersViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<BankMovementCostCentersViewModel> Add(IEnumerable<BankMovementCostCentersViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BankMovementCostCentersViewModel Add(BankMovementCostCentersViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<BankMovementCostCentersViewModel> Update(IEnumerable<BankMovementCostCentersViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BankMovementCostCentersViewModel Update(BankMovementCostCentersViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<BankMovementCostCentersViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(BankMovementCostCentersViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
