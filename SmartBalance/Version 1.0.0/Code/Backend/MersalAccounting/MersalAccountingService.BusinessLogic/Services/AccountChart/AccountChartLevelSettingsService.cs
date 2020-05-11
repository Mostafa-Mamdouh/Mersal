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
	/// Provides AccountChartLevelSetting service for 
	/// business functionality.
	/// </summary>
	public class AccountChartLevelSettingsService : IAccountChartLevelSettingsService
	{
		#region Data Members
		private readonly IAccountChartLevelSettingsRepository _AccountChartLevelSettingsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartLevelSettingsService.
		/// </summary>
		/// <param name="AccountChartLevelSettingsRepository"></param>
		/// <param name="unitOfWork"></param>
		public AccountChartLevelSettingsService(
			IAccountChartLevelSettingsRepository AccountChartLevelSettingsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._AccountChartLevelSettingsRepository = AccountChartLevelSettingsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">AccountChartLevelSetting view model</param>
		public void ThrowExceptionIfExist(AccountChartLevelSettingViewModel model)
		{
			ConditionFilter<AccountChartLevelSetting, long> condition = new ConditionFilter<AccountChartLevelSetting, long>
			{
				Query = (entity =>
					entity.Level == model.Level &&
					entity.Id != model.Id)
			};
			var existEntity = this._AccountChartLevelSettingsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(ConditionFilter<AccountChartLevelSetting, long> condition)
		{
			var entityCollection = this._AccountChartLevelSettingsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLevelSettingViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<AccountChartLevelSetting, long> condition = new ConditionFilter<AccountChartLevelSetting, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._AccountChartLevelSettingsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLevelSettingViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<AccountChartLevelSettingLightViewModel> GetLightModel()
        {
            var entityCollection = this._AccountChartLevelSettingsRepository.Get().ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return modelCollection;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(ConditionFilter<AccountChartLevelSetting, long> condition)
		{
			var entityCollection = this._AccountChartLevelSettingsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLevelSettingLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			
			ConditionFilter<AccountChartLevelSetting, long> condition = new ConditionFilter<AccountChartLevelSetting, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._AccountChartLevelSettingsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLevelSettingLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a AccountChartLevelSettingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AccountChartLevelSettingViewModel Get(long id)
		{
			var entity = this._AccountChartLevelSettingsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AccountChartLevelSettingViewModel> Add(IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartLevelSettingsRepository.Add(entityCollection).ToList();

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
		public AccountChartLevelSettingViewModel Add(AccountChartLevelSettingViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartLevelSettingsRepository.Add(entity);

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
		public IList<AccountChartLevelSettingViewModel> Update(IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartLevelSettingsRepository.Update(entityCollection).ToList();

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
		public AccountChartLevelSettingViewModel Update(AccountChartLevelSettingViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._AccountChartLevelSettingsRepository.Update(entity);

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
		public void Delete(IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._AccountChartLevelSettingsRepository.Delete(entityCollection);

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
			this._AccountChartLevelSettingsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(AccountChartLevelSettingViewModel model)
		{
			var entity = model.ToEntity();
			this._AccountChartLevelSettingsRepository.Delete(entity);

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
			var result = this._AccountChartLevelSettingsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
