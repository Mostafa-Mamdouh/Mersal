using Framework.Core.Filters;
using Framework.Core.IServices.Base;
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
    public interface ILiquidationService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(LiquidationViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<LiquidationViewModel> Get(ConditionFilter<Liquidation, long> condition);

        //GenericCollectionViewModel<ListDiscountPercentegesLightViewModel> GetByFilter(LiquidationFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<LiquidationViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(ConditionFilter<Liquidation, int> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       // GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a LiquidationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LiquidationViewModel Get(long id);

        List<LiquidationDetailViewModel> GetUnliquidation(long costCenterId, long? liquidationType, bool? isClosed);

        string GenerateNewCode(string lastCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<LiquidationViewModel> Add(IEnumerable<LiquidationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LiquidationViewModel Add(LiquidationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<LiquidationViewModel> Update(IEnumerable<LiquidationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LiquidationViewModel Update(LiquidationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<LiquidationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(LiquidationViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
