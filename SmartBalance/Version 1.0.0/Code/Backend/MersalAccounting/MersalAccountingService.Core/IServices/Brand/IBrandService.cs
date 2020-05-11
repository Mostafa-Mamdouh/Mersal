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
	public interface IBrandsService : IBaseService
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void ThrowExceptionIfExist(BrandViewModel model);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BrandViewModel> Get(ConditionFilter<Brand, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BrandViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BrandLightViewModel> GetLightModel(ConditionFilter<Brand, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<BrandLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a BrandViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		BrandViewModel Get(long id);

        IList<BrandLightViewModel> GetLookup();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListBrandsLightViewModel> GetByFilter(BrandFilterViewModel model);


        List<BrandLightViewModel> GetChildren(long brandId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<BrandViewModel> Add(IEnumerable<BrandViewModel> collection);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		BrandViewModel Add(BrandViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<BrandViewModel> Update(IEnumerable<BrandViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		BrandViewModel Update(BrandViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<BrandViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<long> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void Delete(BrandViewModel model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(long id);
		#endregion
	}
}
