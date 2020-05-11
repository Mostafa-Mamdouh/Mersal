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
	/// Provides PurchaseInvoiceCostCenter service for 
	/// business functionality.
	/// </summary>
	public class PurchaseInvoiceCostCentersService : IPurchaseInvoiceCostCentersService
	{
		#region Data Members
		private readonly IPurchaseInvoiceCostCentersRepository _PurchaseInvoiceCostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoiceCostCentersService.
		/// </summary>
		/// <param name="PurchaseInvoiceCostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public PurchaseInvoiceCostCentersService(
			IPurchaseInvoiceCostCentersRepository PurchaseInvoiceCostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._PurchaseInvoiceCostCentersRepository = PurchaseInvoiceCostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods		

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(ConditionFilter<PurchaseInvoiceCostCenter, long> condition)
		{
			var entityCollection = this._PurchaseInvoiceCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<PurchaseInvoiceCostCenter, long> condition = new ConditionFilter<PurchaseInvoiceCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._PurchaseInvoiceCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoiceCostCenter, long> condition)
		{
			var entityCollection = this._PurchaseInvoiceCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<PurchaseInvoiceCostCenter, long> condition = new ConditionFilter<PurchaseInvoiceCostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._PurchaseInvoiceCostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a PurchaseInvoiceCostCenterViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PurchaseInvoiceCostCenterViewModel Get(long id)
		{
			var entity = this._PurchaseInvoiceCostCentersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<PurchaseInvoiceCostCenterViewModel> Add(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseInvoiceCostCentersRepository.Add(entityCollection).ToList();

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
		public PurchaseInvoiceCostCenterViewModel Add(PurchaseInvoiceCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._PurchaseInvoiceCostCentersRepository.Add(entity);

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
		public IList<PurchaseInvoiceCostCenterViewModel> Update(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{			
			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PurchaseInvoiceCostCentersRepository.Update(entityCollection).ToList();

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
		public PurchaseInvoiceCostCenterViewModel Update(PurchaseInvoiceCostCenterViewModel model)
		{			
			var entity = model.ToEntity();
			entity = this._PurchaseInvoiceCostCentersRepository.Update(entity);

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
		public void Delete(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PurchaseInvoiceCostCentersRepository.Delete(entityCollection);

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
			this._PurchaseInvoiceCostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PurchaseInvoiceCostCenterViewModel model)
		{
			var entity = model.ToEntity();
			this._PurchaseInvoiceCostCentersRepository.Delete(entity);

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
			var result = this._PurchaseInvoiceCostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
