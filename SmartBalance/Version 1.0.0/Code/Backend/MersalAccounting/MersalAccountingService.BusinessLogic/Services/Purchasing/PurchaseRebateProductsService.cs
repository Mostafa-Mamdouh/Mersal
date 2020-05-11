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
	/// Provides PurchaseRebateProduct service for 
	/// business functionality.
	/// </summary>
	public class PurchaseRebateProductsService : IPurchaseRebateProductsService
	{
		#region Data Members
		private readonly IPurchaseRebateProductsRepository _PurchaseRebateProductsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateProductsService.
		/// </summary>
		/// <param name="PurchaseRebateProductsRepository"></param>
		/// <param name="unitOfWork"></param>
		public PurchaseRebateProductsService(
			IPurchaseRebateProductsRepository PurchaseRebateProductsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._PurchaseRebateProductsRepository = PurchaseRebateProductsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateProductViewModel> Get(ConditionFilter<PurchaseRebateProduct, long> condition)
		{
			var entityCollection = this._PurchaseRebateProductsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateProductViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateProductViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<PurchaseRebateProduct, long> condition = new ConditionFilter<PurchaseRebateProduct, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize				
			};
			var entityCollection = this._PurchaseRebateProductsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateProductViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateProductLightViewModel> GetLightModel(ConditionFilter<PurchaseRebateProduct, long> condition)
		{
			var entityCollection = this._PurchaseRebateProductsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateProductLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseRebateProductLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			ConditionFilter<PurchaseRebateProduct, long> condition = new ConditionFilter<PurchaseRebateProduct, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._PurchaseRebateProductsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseRebateProductLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a PurchaseRebateProductViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PurchaseRebateProductViewModel Get(long id)
		{
			var entity = this._PurchaseRebateProductsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<PurchaseRebateProductViewModel> Add(IEnumerable<PurchaseRebateProductViewModel> collection)
		{		
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseRebateProductsRepository.Add(entityCollection).ToList();

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
		public PurchaseRebateProductViewModel Add(PurchaseRebateProductViewModel model)
		{	
			var entity = model.ToEntity();
			entity = this._PurchaseRebateProductsRepository.Add(entity);

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
		public IList<PurchaseRebateProductViewModel> Update(IEnumerable<PurchaseRebateProductViewModel> collection)
		{		
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseRebateProductsRepository.Update(entityCollection).ToList();

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
		public PurchaseRebateProductViewModel Update(PurchaseRebateProductViewModel model)
		{
			var entity = model.ToEntity();
			entity = this._PurchaseRebateProductsRepository.Update(entity);

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
		public void Delete(IEnumerable<PurchaseRebateProductViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PurchaseRebateProductsRepository.Delete(entityCollection);

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
			this._PurchaseRebateProductsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PurchaseRebateProductViewModel model)
		{
			var entity = model.ToEntity();
			this._PurchaseRebateProductsRepository.Delete(entity);

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
			var result = this._PurchaseRebateProductsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
