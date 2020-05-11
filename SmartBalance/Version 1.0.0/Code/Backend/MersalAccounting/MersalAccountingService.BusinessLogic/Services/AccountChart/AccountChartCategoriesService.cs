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
	/// Provides AccountChartCategory service for 
	/// business functionality.
	/// </summary>
	public class AccountChartCategoriesService : IAccountChartCategoriesService
	{
		#region Data Members
		private readonly IAccountChartCategoriesRepository _AccountChartCategorysRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartCategorysService.
		/// </summary>
		/// <param name="AccountChartCategorysRepository"></param>
		/// <param name="unitOfWork"></param>
		public AccountChartCategoriesService(
			IAccountChartCategoriesRepository AccountChartCategorysRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._AccountChartCategorysRepository = AccountChartCategorysRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">AccountChartCategory view model</param>
		public void ThrowExceptionIfExist(AccountChartCategoryViewModel model)
		{
			ConditionFilter<AccountChartCategory, long> condition = new ConditionFilter<AccountChartCategory, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._AccountChartCategorysRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartCategoryViewModel> Get(ConditionFilter<AccountChartCategory, long> condition)
		{
			var entityCollection = this._AccountChartCategorysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartCategoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartCategoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChartCategory, long> condition = new ConditionFilter<AccountChartCategory, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				
			};
			var entityCollection = this._AccountChartCategorysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartCategoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartCategoryLightViewModel> GetLightModel(int? id)
		{
            var lang = _languageService.CurrentLanguage;
            ConditionFilter<AccountChartCategory, long> condition = new ConditionFilter<AccountChartCategory, long>();
            condition.Query = x => x.Language == lang && x.Id == id;

            var entityCollection = this._AccountChartCategorysRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AccountChartCategoryLightViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }


        /// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public List<AccountChartCategoryLightViewModel> Get()
        {
            var lang = _languageService.CurrentLanguage;
            ConditionFilter<AccountChartCategory, long> condition = new ConditionFilter<AccountChartCategory, long>();
            condition.Query = x => x.Language == lang;

            var entityCollection = this._AccountChartCategorysRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return modelCollection;
        }



        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartCategoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AccountChartCategoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChartCategory, long> condition = new ConditionFilter<AccountChartCategory, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._AccountChartCategorysRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartCategoryLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a AccountChartCategoryViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AccountChartCategoryViewModel Get(long id)
		{
			var entity = this._AccountChartCategorysRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AccountChartCategoryViewModel> Add(IEnumerable<AccountChartCategoryViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartCategorysRepository.Add(entityCollection).ToList();

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
		public AccountChartCategoryViewModel Add(AccountChartCategoryViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartCategorysRepository.Add(entity);

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
		public IList<AccountChartCategoryViewModel> Update(IEnumerable<AccountChartCategoryViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartCategorysRepository.Update(entityCollection).ToList();

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
		public AccountChartCategoryViewModel Update(AccountChartCategoryViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartCategorysRepository.Update(entity);

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
		public void Delete(IEnumerable<AccountChartCategoryViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._AccountChartCategorysRepository.Delete(entityCollection);

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
			this._AccountChartCategorysRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(AccountChartCategoryViewModel model)
		{
			var entity = model.ToEntity();
			this._AccountChartCategorysRepository.Delete(entity);

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
			var result = this._AccountChartCategorysRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
