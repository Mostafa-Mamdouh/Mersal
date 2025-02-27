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
	/// Provides GroupRole service for 
	/// business functionality.
	/// </summary>
	public class GroupRolesService : IGroupRolesService
	{
		#region Data Members
		private readonly IGroupRolesRepository _GroupRolesRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupRolesService.
		/// </summary>
		/// <param name="GroupRolesRepository"></param>
		/// <param name="unitOfWork"></param>
		public GroupRolesService(
			IGroupRolesRepository GroupRolesRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._GroupRolesRepository = GroupRolesRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">GroupRole view model</param>
		public void ThrowExceptionIfExist(GroupRoleViewModel model)
		{
			ConditionFilter<GroupRole, long> condition = new ConditionFilter<GroupRole, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._GroupRolesRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupRoleViewModel> Get(ConditionFilter<GroupRole, long> condition)
		{
			var entityCollection = this._GroupRolesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<GroupRoleViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupRoleViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<GroupRole, long> condition = new ConditionFilter<GroupRole, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._GroupRolesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<GroupRoleViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupRoleLightViewModel> GetLightModel(ConditionFilter<GroupRole, long> condition)
		{
			var entityCollection = this._GroupRolesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<GroupRoleLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupRoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupRoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<GroupRole, long> condition = new ConditionFilter<GroupRole, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._GroupRolesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<GroupRoleLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GroupRoleViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public GroupRoleViewModel Get(long id)
		{
			var entity = this._GroupRolesRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<GroupRoleViewModel> Add(IEnumerable<GroupRoleViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._GroupRolesRepository.Add(entityCollection).ToList();

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
		public GroupRoleViewModel Add(GroupRoleViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._GroupRolesRepository.Add(entity);

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
		public IList<GroupRoleViewModel> Update(IEnumerable<GroupRoleViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._GroupRolesRepository.Update(entityCollection).ToList();

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
		public GroupRoleViewModel Update(GroupRoleViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._GroupRolesRepository.Update(entity);

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
		public void Delete(IEnumerable<GroupRoleViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._GroupRolesRepository.Delete(entityCollection);

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
			this._GroupRolesRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(GroupRoleViewModel model)
		{
			var entity = model.ToEntity();
			this._GroupRolesRepository.Delete(entity);

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
			var result = this._GroupRolesRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
