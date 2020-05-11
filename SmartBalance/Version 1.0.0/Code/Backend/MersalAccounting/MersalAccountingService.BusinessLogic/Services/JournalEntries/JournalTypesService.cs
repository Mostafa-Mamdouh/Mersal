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
	/// Provides JournalType service for 
	/// business functionality.
	/// </summary>
	public class JournalTypesService : IJournalTypesService
	{
		#region Data Members
		private readonly IJournalTypesRepository _JournalTypesRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalTypesService.
		/// </summary>
		/// <param name="JournalTypesRepository"></param>
		/// <param name="unitOfWork"></param>
		public JournalTypesService(
			IJournalTypesRepository JournalTypesRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._JournalTypesRepository = JournalTypesRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">JournalType view model</param>
		public void ThrowExceptionIfExist(JournalTypeViewModel model)
		{
			ConditionFilter<JournalType, long> condition = new ConditionFilter<JournalType, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._JournalTypesRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalTypeViewModel> Get(ConditionFilter<JournalType, long> condition)
		{
			var entityCollection = this._JournalTypesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalTypeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<JournalType, long> condition = new ConditionFilter<JournalType, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._JournalTypesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalTypeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalTypeLightViewModel> GetLightModel(ConditionFilter<JournalType, long> condition)
		{
			var entityCollection = this._JournalTypesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalTypeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<JournalType, long> condition = new ConditionFilter<JournalType, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._JournalTypesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalTypeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a JournalTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public JournalTypeViewModel Get(long id)
		{
			var entity = this._JournalTypesRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<JournalTypeViewModel> Add(IEnumerable<JournalTypeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalTypesRepository.Add(entityCollection).ToList();

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
		public JournalTypeViewModel Add(JournalTypeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._JournalTypesRepository.Add(entity);

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
		public IList<JournalTypeViewModel> Update(IEnumerable<JournalTypeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalTypesRepository.Update(entityCollection).ToList();

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
		public JournalTypeViewModel Update(JournalTypeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._JournalTypesRepository.Update(entity);

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
		public void Delete(IEnumerable<JournalTypeViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._JournalTypesRepository.Delete(entityCollection);

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
			this._JournalTypesRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(JournalTypeViewModel model)
		{
			var entity = model.ToEntity();
			this._JournalTypesRepository.Delete(entity);

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
			var result = this._JournalTypesRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
