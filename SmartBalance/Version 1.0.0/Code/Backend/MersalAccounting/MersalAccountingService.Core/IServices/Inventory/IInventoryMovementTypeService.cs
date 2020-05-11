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
    public interface IInventoryMovementTypeService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(InventoryMovementTypeViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(ConditionFilter<InventoryMovementType, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(ConditionFilter<InventoryMovementType, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a InventoryMovementTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryMovementTypeViewModel Get(long id);

        /// <summary>
        /// Gets a InventoryMovementTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<InventoryMovementTypeLightViewModel> GetLookUp();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryMovementTypeViewModel> Add(IEnumerable<InventoryMovementTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryMovementTypeViewModel Add(InventoryMovementTypeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryMovementTypeViewModel> Update(IEnumerable<InventoryMovementTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryMovementTypeViewModel Update(InventoryMovementTypeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<InventoryMovementTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(InventoryMovementTypeViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
