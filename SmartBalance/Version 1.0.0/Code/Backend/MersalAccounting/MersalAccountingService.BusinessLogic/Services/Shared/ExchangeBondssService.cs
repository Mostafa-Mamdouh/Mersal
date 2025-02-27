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
	/// Provides ExchangeBonds service for 
	/// business functionality.
	/// </summary>
	public class ExchangeBondssService : IExchangeBondssService
	{
		#region Data Members
		private readonly IExchangeBondssRepository _ExchangeBondssRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ExchangeBondssService.
		/// </summary>
		/// <param name="ExchangeBondssRepository"></param>
		/// <param name="unitOfWork"></param>
		public ExchangeBondssService(
			IExchangeBondssRepository ExchangeBondssRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._ExchangeBondssRepository = ExchangeBondssRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">ExchangeBonds view model</param>
		public void ThrowExceptionIfExist(ExchangeBondsViewModel model)
		{
			ConditionFilter<ExchangeBonds, long> condition = new ConditionFilter<ExchangeBonds, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._ExchangeBondssRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ExchangeBondsViewModel> Get(ConditionFilter<ExchangeBonds, long> condition)
		{
			var entityCollection = this._ExchangeBondssRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<ExchangeBondsViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ExchangeBondsViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<ExchangeBonds, long> condition = new ConditionFilter<ExchangeBonds, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._ExchangeBondssRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<ExchangeBondsViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ExchangeBondsLightViewModel> GetLightModel(ConditionFilter<ExchangeBonds, long> condition)
		{
			var entityCollection = this._ExchangeBondssRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<ExchangeBondsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ExchangeBondsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ExchangeBondsLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<ExchangeBonds, long> condition = new ConditionFilter<ExchangeBonds, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._ExchangeBondssRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<ExchangeBondsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a ExchangeBondsViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ExchangeBondsViewModel Get(long id)
		{
			var entity = this._ExchangeBondssRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<ExchangeBondsViewModel> Add(IEnumerable<ExchangeBondsViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._ExchangeBondssRepository.Add(entityCollection).ToList();

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
		public ExchangeBondsViewModel Add(ExchangeBondsViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._ExchangeBondssRepository.Add(entity);

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
		public IList<ExchangeBondsViewModel> Update(IEnumerable<ExchangeBondsViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._ExchangeBondssRepository.Update(entityCollection).ToList();

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
		public ExchangeBondsViewModel Update(ExchangeBondsViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._ExchangeBondssRepository.Update(entity);

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
		public void Delete(IEnumerable<ExchangeBondsViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._ExchangeBondssRepository.Delete(entityCollection);

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
			this._ExchangeBondssRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(ExchangeBondsViewModel model)
		{
			var entity = model.ToEntity();
			this._ExchangeBondssRepository.Delete(entity);

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
			var result = this._ExchangeBondssRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
