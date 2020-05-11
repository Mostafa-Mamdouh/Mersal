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
	/// Provides InventoryMovementCostCenter service for 
	/// business functionality.
	/// </summary>
	public class InventoryMovementCostCentersService : IInventoryMovementCostCentersService
    {
		#region Data Members
		private readonly IInventoryMovementCostCenterRepository _InventoryMovementCostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementCostCentersService.
		/// </summary>
		/// <param name="InventoryMovementCostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public InventoryMovementCostCentersService(
            IInventoryMovementCostCenterRepository InventoryMovementCostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._InventoryMovementCostCentersRepository = InventoryMovementCostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods		

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> Get(ConditionFilter<InventoryMovementCostCenter, long> condition)
		{
			var entityCollection = this._InventoryMovementCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<InventoryMovementCostCenter, long> condition = new ConditionFilter<InventoryMovementCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._InventoryMovementCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> GetLightModel(ConditionFilter<InventoryMovementCostCenter, long> condition)
		{
			var entityCollection = this._InventoryMovementCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementCostCenterViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<InventoryMovementCostCenter, long> condition = new ConditionFilter<InventoryMovementCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._InventoryMovementCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementCostCenterViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a InventoryMovementCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public InventoryMovementCostCenterViewModel Get(long id)
		{
			var entity = this._InventoryMovementCostCentersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<InventoryMovementCostCenterViewModel> Add(IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryMovementCostCentersRepository.Add(entityCollection).ToList();

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
		public InventoryMovementCostCenterViewModel Add(InventoryMovementCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._InventoryMovementCostCentersRepository.Add(entity);

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
		public IList<InventoryMovementCostCenterViewModel> Update(IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryMovementCostCentersRepository.Update(entityCollection).ToList();

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
		public InventoryMovementCostCenterViewModel Update(InventoryMovementCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._InventoryMovementCostCentersRepository.Update(entity);

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
		public void Delete(IEnumerable<InventoryMovementCostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._InventoryMovementCostCentersRepository.Delete(entityCollection);

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
			this._InventoryMovementCostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(InventoryMovementCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			this._InventoryMovementCostCentersRepository.Delete(entity);

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
			var result = this._InventoryMovementCostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
