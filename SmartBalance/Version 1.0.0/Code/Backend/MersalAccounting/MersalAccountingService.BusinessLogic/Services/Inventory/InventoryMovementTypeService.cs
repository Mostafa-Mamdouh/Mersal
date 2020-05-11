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
	/// Provides InventoryMovementType service for 
	/// business functionality.
	/// </summary>
	public class InventoryMovementTypeService : IInventoryMovementTypeService
	{
		#region Data Members
		private readonly IInventoryMovementTypeRepository _InventoryMovementTypeRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementTypeService.
		/// </summary>
		/// <param name="InventoryMovementTypeRepository"></param>
		/// <param name="unitOfWork"></param>
		public InventoryMovementTypeService(
			IInventoryMovementTypeRepository InventoryMovementTypeRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._InventoryMovementTypeRepository = InventoryMovementTypeRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">InventoryMovementType view model</param>
		public void ThrowExceptionIfExist(InventoryMovementTypeViewModel model)
		{
			ConditionFilter<InventoryMovementType, long> condition = new ConditionFilter<InventoryMovementType, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._InventoryMovementTypeRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(ConditionFilter<InventoryMovementType, long> condition)
		{
			var entityCollection = this._InventoryMovementTypeRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementTypeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<InventoryMovementType, long> condition = new ConditionFilter<InventoryMovementType, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventoryMovementTypeRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementTypeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(ConditionFilter<InventoryMovementType, long> condition)
		{
			var entityCollection = this._InventoryMovementTypeRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementTypeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

        /// <summary>
        /// Gets a ProductLookUpViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of ProductLookUpViewModel </returns>
        public List<InventoryMovementTypeLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            ConditionFilter < InventoryMovementType, long> condition = new ConditionFilter< InventoryMovementType, long>
            {
                Query = (item =>
                item.Language == lang)
            };
            var entityCollection = this._InventoryMovementTypeRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryMovementTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<InventoryMovementType, long> condition = new ConditionFilter<InventoryMovementType, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventoryMovementTypeRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryMovementTypeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a InventoryMovementTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public InventoryMovementTypeViewModel Get(long id)
		{
			var entity = this._InventoryMovementTypeRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<InventoryMovementTypeViewModel> Add(IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryMovementTypeRepository.Add(entityCollection).ToList();

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
		public InventoryMovementTypeViewModel Add(InventoryMovementTypeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._InventoryMovementTypeRepository.Add(entity);

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
		public IList<InventoryMovementTypeViewModel> Update(IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryMovementTypeRepository.Update(entityCollection).ToList();

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
		public InventoryMovementTypeViewModel Update(InventoryMovementTypeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._InventoryMovementTypeRepository.Update(entity);

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
		public void Delete(IEnumerable<InventoryMovementTypeViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._InventoryMovementTypeRepository.Delete(entityCollection);

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
			this._InventoryMovementTypeRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(InventoryMovementTypeViewModel model)
		{
			var entity = model.ToEntity();
			this._InventoryMovementTypeRepository.Delete(entity);

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
			var result = this._InventoryMovementTypeRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
