#region Using ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides PurchaseRebateCostCenter service for 
	/// business functionality.
	/// </summary>
	public class PurchaseRebateCostCentersService : IPurchaseRebateCostCentersService
	{
		#region Data Members
		private readonly IPurchaseRebateCostCentersRepository _PurchaseRebateCostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateCostCentersService.
		/// </summary>
		/// <param name="PurchaseRebateCostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public PurchaseRebateCostCentersService(
			IPurchaseRebateCostCentersRepository PurchaseRebateCostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._PurchaseRebateCostCentersRepository = PurchaseRebateCostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods		

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(ConditionFilter<PurchaseRebateCostCenter, long> condition)
		{
			var entityCollection = this._PurchaseRebateCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<PurchaseRebateCostCenter, long> condition = new ConditionFilter<PurchaseRebateCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._PurchaseRebateCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseRebateCostCenter, long> condition)
		{
			var entityCollection = this._PurchaseRebateCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			ConditionFilter<PurchaseRebateCostCenter, long> condition = new ConditionFilter<PurchaseRebateCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._PurchaseRebateCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a PurchaseRebateCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PurchaseRebateCostCenterViewModel Get(long id)
		{
			var entity = this._PurchaseRebateCostCentersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<PurchaseRebateCostCenterViewModel> Add(IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseRebateCostCentersRepository.Add(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public PurchaseRebateCostCenterViewModel Add(PurchaseRebateCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			entity = this._PurchaseRebateCostCentersRepository.Add(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<PurchaseRebateCostCenterViewModel> Update(IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseRebateCostCentersRepository.Update(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public PurchaseRebateCostCenterViewModel Update(PurchaseRebateCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			entity = this._PurchaseRebateCostCentersRepository.Update(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<PurchaseRebateCostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PurchaseRebateCostCentersRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<long> collection)
		{
			this._PurchaseRebateCostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PurchaseRebateCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			this._PurchaseRebateCostCentersRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		public void Delete(long id)
		{
			var result = this._PurchaseRebateCostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
