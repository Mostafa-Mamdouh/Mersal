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
	/// Provides InventoryOpeningBalanceCostCenter service for 
	/// business functionality.
	/// </summary>
	public class InventoryOpeningBalanceCostCentersService : IInventoryOpeningBalanceCostCentersService
    {
		#region Data Members
		private readonly IInventoryOpeningBalanceCostCenterRepository _InventoryOpeningBalanceCostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryOpeningBalanceCostCentersService.
		/// </summary>
		/// <param name="InventoryOpeningBalanceCostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public InventoryOpeningBalanceCostCentersService(
            IInventoryOpeningBalanceCostCenterRepository InventoryOpeningBalanceCostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._InventoryOpeningBalanceCostCentersRepository = InventoryOpeningBalanceCostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods		

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> Get(ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition)
		{
			var entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition = new ConditionFilter<InventoryOpeningBalanceCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> GetLightModel(ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition)
		{
			var entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<InventoryOpeningBalanceCostCenter, long> condition = new ConditionFilter<InventoryOpeningBalanceCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryOpeningBalanceCostCenterViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a InventoryOpeningBalanceCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public InventoryOpeningBalanceCostCenterViewModel Get(long id)
		{
			var entity = this._InventoryOpeningBalanceCostCentersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<InventoryOpeningBalanceCostCenterViewModel> Add(IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Add(entityCollection).ToList();

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
		public InventoryOpeningBalanceCostCenterViewModel Add(InventoryOpeningBalanceCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._InventoryOpeningBalanceCostCentersRepository.Add(entity);

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
		public IList<InventoryOpeningBalanceCostCenterViewModel> Update(IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryOpeningBalanceCostCentersRepository.Update(entityCollection).ToList();

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
		public InventoryOpeningBalanceCostCenterViewModel Update(InventoryOpeningBalanceCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._InventoryOpeningBalanceCostCentersRepository.Update(entity);

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
		public void Delete(IEnumerable<InventoryOpeningBalanceCostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._InventoryOpeningBalanceCostCentersRepository.Delete(entityCollection);

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
			this._InventoryOpeningBalanceCostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(InventoryOpeningBalanceCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			this._InventoryOpeningBalanceCostCentersRepository.Delete(entity);

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
			var result = this._InventoryOpeningBalanceCostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
