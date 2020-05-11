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
	public interface IDonationTypesService : IBaseService
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void ThrowExceptionIfExist(DonationTypeViewModel model);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonationTypeViewModel> Get(ConditionFilter<DonationType, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonationTypeViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonationTypeLightViewModel> GetLightModel(int? id);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationTypeLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonationTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a DonationTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		DonationTypeViewModel Get(long id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<DonationTypeViewModel> Add(IEnumerable<DonationTypeViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		DonationTypeViewModel Add(DonationTypeViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<DonationTypeViewModel> Update(IEnumerable<DonationTypeViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		DonationTypeViewModel Update(DonationTypeViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<DonationTypeViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<long> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void Delete(DonationTypeViewModel model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(long id);
		#endregion
	}
}
