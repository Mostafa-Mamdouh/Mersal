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
    public interface IMeasurementUnitsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(MeasurementUnitViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MeasurementUnitViewModel> Get(ConditionFilter<MeasurementUnit, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MeasurementUnitViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MeasurementUnitViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MeasurementUnitLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MeasurementUnitLightViewModel> GetLightModel(ConditionFilter<MeasurementUnit, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of MeasurementUnitLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<MeasurementUnitLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        List<MeasurementUnitLightViewModel> GetLookUp();

        /// <summary>
        /// Gets a MeasurementUnitViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MeasurementUnitViewModel Get(long id);

		GenericCollectionViewModel<ListMeasurementUnitsLightViewModel> GetByFilter(MeasurementUnitFilterViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<MeasurementUnitViewModel> Add(IEnumerable<MeasurementUnitViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MeasurementUnitViewModel Add(MeasurementUnitViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<MeasurementUnitViewModel> Update(IEnumerable<MeasurementUnitViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MeasurementUnitViewModel Update(MeasurementUnitViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<MeasurementUnitViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(MeasurementUnitViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
