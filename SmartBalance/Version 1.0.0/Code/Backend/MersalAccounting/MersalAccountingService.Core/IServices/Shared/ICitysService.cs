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
    public interface ICitysService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(CityViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of CityViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CityViewModel> Get(ConditionFilter<City, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of CityViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CityViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<CityLightViewModel> GetLightModel(ConditionFilter<City, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of CityLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<CityLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a CityViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CityViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CityViewModel> Add(IEnumerable<CityViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CityViewModel Add(CityViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CityViewModel> Update(IEnumerable<CityViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CityViewModel Update(CityViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<CityViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(CityViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
