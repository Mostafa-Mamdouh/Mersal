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
    public interface IInventoryMovementsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(InventoryMovementViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryMovementViewModel> Get(ConditionFilter<InventoryMovement, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryMovementViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(ConditionFilter<InventoryMovement, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a InventoryMovementViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryMovementViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryMovementViewModel> Add(IEnumerable<InventoryMovementViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryMovementViewModel Add(InventoryMovementViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryMovementViewModel> Update(IEnumerable<InventoryMovementViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryMovementViewModel Update(InventoryMovementViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<InventoryMovementViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(InventoryMovementViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);



        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        GenericCollectionViewModel<InventoryMovementLightViewModel> GetByFilter(InventoryMovementFilterViewModel model);

        /// <summary>
        /// 
        /// </s
        /// <param name=""></param>
        InventoryMovementAddViewModel GetInventoryMovement(long id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        InventoryMovementAddViewModel AddInventoryMovement(InventoryMovementAddViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        InventoryMovementAddViewModel UpdateInventoryMovement(InventoryMovementAddViewModel model);
        #endregion
    }
}
