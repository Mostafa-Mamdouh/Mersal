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
	/// Provides FiscalYear service for 
	/// business functionality.
	/// </summary>
	public class FiscalYearsService : IFiscalYearsService
	{
		#region Data Members
		private readonly IFiscalYearsRepository _FiscalYearsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type FiscalYearsService.
		/// </summary>
		/// <param name="FiscalYearsRepository"></param>
		/// <param name="unitOfWork"></param>
		public FiscalYearsService(
			IFiscalYearsRepository FiscalYearsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._FiscalYearsRepository = FiscalYearsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">FiscalYear view model</param>
		public void ThrowExceptionIfExist(FiscalYearViewModel model)
		{
			ConditionFilter<FiscalYear, long> condition = new ConditionFilter<FiscalYear, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._FiscalYearsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<FiscalYearViewModel> Get(ConditionFilter<FiscalYear, long> condition)
		{
			var entityCollection = this._FiscalYearsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<FiscalYearViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<FiscalYearViewModel> Get(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<FiscalYear, long> condition = new ConditionFilter<FiscalYear, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._FiscalYearsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<FiscalYearViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<FiscalYearLightViewModel> GetLightModel(ConditionFilter<FiscalYear, long> condition)
		{
			var entityCollection = this._FiscalYearsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<FiscalYearLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of FiscalYearViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<FiscalYearLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<FiscalYear, long> condition = new ConditionFilter<FiscalYear, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._FiscalYearsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<FiscalYearLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a FiscalYearViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public FiscalYearViewModel Get(long id)
		{
			var entity = this._FiscalYearsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<FiscalYearViewModel> Add(IEnumerable<FiscalYearViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._FiscalYearsRepository.Add(entityCollection).ToList();

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
		public FiscalYearViewModel Add(FiscalYearViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._FiscalYearsRepository.Add(entity);

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
		public IList<FiscalYearViewModel> Update(IEnumerable<FiscalYearViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._FiscalYearsRepository.Update(entityCollection).ToList();

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
		public FiscalYearViewModel Update(FiscalYearViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._FiscalYearsRepository.Update(entity);

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
		public void Delete(IEnumerable<FiscalYearViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._FiscalYearsRepository.Delete(entityCollection);

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
			this._FiscalYearsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(FiscalYearViewModel model)
		{
			var entity = model.ToEntity();
			this._FiscalYearsRepository.Delete(entity);

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
			var result = this._FiscalYearsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
