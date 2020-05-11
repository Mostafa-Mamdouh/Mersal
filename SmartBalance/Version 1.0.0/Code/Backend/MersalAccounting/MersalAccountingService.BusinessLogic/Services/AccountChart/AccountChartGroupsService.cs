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
	/// Provides AccountChartGroup service for 
	/// business functionality.
	/// </summary>
	public class AccountChartGroupsService : IAccountChartGroupsService
	{
		#region Data Members
		private readonly IAccountChartGroupsRepository _AccountChartGroupRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartGroupService.
		/// </summary>
		/// <param name="AccountChartGroupRepository"></param>
		/// <param name="unitOfWork"></param>
		public AccountChartGroupsService(
			IAccountChartGroupsRepository AccountChartGroupRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._AccountChartGroupRepository = AccountChartGroupRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">AccountChartGroup view model</param>
		public void ThrowExceptionIfExist(AccountChartGroupViewModel model)
		{
			ConditionFilter<AccountChartGroup, long> condition = new ConditionFilter<AccountChartGroup, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._AccountChartGroupRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartGroupViewModel> Get(ConditionFilter<AccountChartGroup, long> condition)
		{
			var entityCollection = this._AccountChartGroupRepository.Get(condition).ToList();
            List<AccountChartGroupViewModel> modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartGroupViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartGroupViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChartGroup, long> condition = new ConditionFilter<AccountChartGroup, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				
			};
			var entityCollection = this._AccountChartGroupRepository.Get(condition).ToList();
            List<AccountChartGroupViewModel> modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartGroupViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartGroupLightViewModel> GetLightModel(int? id)
		{
            var lang = _languageService.CurrentLanguage;
            ConditionFilter<AccountChartGroup, long> condition = new ConditionFilter<AccountChartGroup, long>();
            condition.Query = x => x.Language == lang && x.Id == id;

            var entityCollection = this._AccountChartGroupRepository.Get(condition).ToList();
            List<AccountChartGroupLightViewModel> modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AccountChartGroupLightViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }


        /// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public List<AccountChartGroupLightViewModel> Get()
        {
            var lang = _languageService.CurrentLanguage;
            ConditionFilter<AccountChartGroup, long> condition = new ConditionFilter<AccountChartGroup, long>();
            condition.Query = x => x.Language == lang;

            var entityCollection = this._AccountChartGroupRepository.Get(condition).ToList();
            List<AccountChartGroupLightViewModel> result = entityCollection.Select(entity => entity.ToLightModel()).ToList();
          

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartGroupViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AccountChartGroupLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChartGroup, long> condition = new ConditionFilter<AccountChartGroup, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._AccountChartGroupRepository.Get(condition).ToList();
            List<AccountChartGroupLightViewModel> dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartGroupLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a AccountChartGroupViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AccountChartGroupViewModel Get(long id)
		{
			var entity = this._AccountChartGroupRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AccountChartGroupViewModel> Add(IEnumerable<AccountChartGroupViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartGroupRepository.Add(entityCollection).ToList();

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
		public AccountChartGroupViewModel Add(AccountChartGroupViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartGroupRepository.Add(entity);

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
		public IList<AccountChartGroupViewModel> Update(IEnumerable<AccountChartGroupViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartGroupRepository.Update(entityCollection).ToList();

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
		public AccountChartGroupViewModel Update(AccountChartGroupViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartGroupRepository.Update(entity);

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
		public void Delete(IEnumerable<AccountChartGroupViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._AccountChartGroupRepository.Delete(entityCollection);

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
			this._AccountChartGroupRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(AccountChartGroupViewModel model)
		{
			var entity = model.ToEntity();
			this._AccountChartGroupRepository.Delete(entity);

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
			var result = this._AccountChartGroupRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
