#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
	/// Provides Group service for 
	/// business functionality.
	/// </summary>
	public class GroupsService : IGroupsService
	{
		#region Data Members
		private readonly IGroupsRepository _GroupsRepository;
		private readonly IGroupPermissionsRepository _groupPermissionsRepository;
		private readonly IGroupRolesRepository _groupRolesRepository;
		private readonly IUserGroupsRepository _userGroupsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GroupsService.
		/// </summary>
		/// <param name="GroupsRepository"></param>
		/// <param name="unitOfWork"></param>
		public GroupsService(
			IGroupsRepository GroupsRepository,
			IGroupPermissionsRepository groupPermissionsRepository,
			IGroupRolesRepository groupRolesRepository,
			IUserGroupsRepository userGroupsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._GroupsRepository = GroupsRepository;
			this._groupPermissionsRepository = groupPermissionsRepository;
			this._groupRolesRepository = groupRolesRepository;
			this._userGroupsRepository = userGroupsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Group view model</param>
		public void ThrowExceptionIfExist(GroupViewModel model)
		{
			ConditionFilter<Group, long> condition = new ConditionFilter<Group, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._GroupsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupViewModel> Get(ConditionFilter<Group, long> condition)
		{
			var entityCollection = this._GroupsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<GroupViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Group, long> condition = new ConditionFilter<Group, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._GroupsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<GroupViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupLightViewModel> GetLightModel(ConditionFilter<Group, long> condition)
		{
			var entityCollection = this._GroupsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<GroupLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of GroupViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<GroupLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Group, long> condition = new ConditionFilter<Group, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._GroupsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<GroupLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GroupViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public GroupViewModel Get(long id)
		{
			var entity = this._GroupsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public GenericCollectionViewModel<ListGroupsLightViewModel> GetByFilter(GroupFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Group, long> condition = new ConditionFilter<Group, long>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			////if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			//if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToNow();

			// The IQueryable data to query.  
			IQueryable<Group> queryableData = this._GroupsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyGroup != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyGroup.Code == model.Code);

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name != null && x.Name.Contains(model.Name));

			if (model.IsActive.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyGroup.IsActive == model.IsActive.Value);

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyGroup.Date >= model.DateFrom.Value);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyGroup.Date <= model.DateTo.Value);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyGroupId);
			//	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
			//	//if (item.ParentKeyBankMovement.Bank != null)
			//	//{
			//	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
			//	//}
			//	//if (item.ParentKeyBankMovement.JournalType != null)
			//	//{
			//	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
			//	//}
			//}

			var total = dtoCollection.Count();
			dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
			var result = new GenericCollectionViewModel<ListGroupsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}






		public IList<GroupLightViewModel> GetAllUnSelectedGroupsForUser(long userId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<GroupLightViewModel> result = null;
			var list = this._userGroupsRepository.Get(null).Where(x => x.UserId == userId);

			if (list.Count() > 0)
			{
				var entityColection = this._GroupsRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyGroupId.HasValue &&
				  x.ParentKeyGroup.UserGroups.FirstOrDefault(y => y.UserId == userId) == null
				  //list.Any(item => x.ParentKeyGroupId != item.GroupId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._GroupsRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyGroupId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}

		public GroupPermissionListViewModel GetGroupPermission(long groupId)
		{
			var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._groupPermissionsRepository.Get(null).Where(x => x.GroupId == groupId).ToList();

			GroupPermissionListViewModel result = new GroupPermissionListViewModel
			{
				GroupId = groupId,
				List = new List<NmaeValueViewModel>()
			};

			foreach (var item in entityCollection)
			{
				result.List.Add(new NmaeValueViewModel
				{
					Value = item.PermissionId.Value,
					Name = item.Permission.ChildTranslatedPermissions.FirstOrDefault(x => x.Language == lang).Name
				});
			}
			return result;
		}
		public GroupPermissionListViewModel UpdateGroupPermission(GroupPermissionListViewModel model)
		{
			var entityCollection = this._groupPermissionsRepository.Get(null).Where(x => x.GroupId == model.GroupId);

			if (entityCollection.Count() > 0)
			{
				foreach (var item in entityCollection)
				{
					this._groupPermissionsRepository.Delete(item);
				}
				this._unitOfWork.Commit();
			}

			if (model.List?.Count > 0)
			{
				foreach (var item in model.List)
				{
					GroupPermission newEntity = new GroupPermission
					{
						GroupId = model.GroupId,
						PermissionId = item.Value
					};
					this._groupPermissionsRepository.Add(newEntity);
				}
				this._unitOfWork.Commit();
			}

			return model;
		}


		public GroupRoleListViewModel GetGroupRole(long groupId)
		{
			var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._groupRolesRepository.Get(null).Where(x => x.GroupId == groupId).ToList();

			GroupRoleListViewModel result = new GroupRoleListViewModel
			{
				GroupId = groupId,
				List = new List<NmaeValueViewModel>()
			};

			foreach (var item in entityCollection)
			{
				result.List.Add(new NmaeValueViewModel
				{
					Value = item.RoleId.Value,
					Name = item.Role.ChildTranslatedRoles.FirstOrDefault(x => x.Language == lang).Name
				});
			}
			return result;
		}
		public GroupRoleListViewModel UpdateGroupRole(GroupRoleListViewModel model)
		{
			var entityCollection = this._groupRolesRepository.Get(null).Where(x => x.GroupId == model.GroupId);

			if (entityCollection.Count() > 0)
			{
				foreach (var item in entityCollection)
				{
					this._groupRolesRepository.Delete(item);
				}
				this._unitOfWork.Commit();
			}

			if (model.List?.Count > 0)
			{
				foreach (var item in model.List)
				{
					GroupRole newEntity = new GroupRole
					{
						GroupId = model.GroupId,
						RoleId = item.Value
					};
					this._groupRolesRepository.Add(newEntity);
				}
				this._unitOfWork.Commit();
			}

			return model;
		}



		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<GroupViewModel> Add(IEnumerable<GroupViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._GroupsRepository.Add(entityCollection).ToList();

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
		public GroupViewModel Add(GroupViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._GroupsRepository.Add(entity);

			var entityAr = new Group
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedGroups.Add(entityAr);
			this._GroupsRepository.Add(entityAr);

			var entityEn = new Group
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedGroups.Add(entityEn);
			this._GroupsRepository.Add(entityEn);

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
		public IList<GroupViewModel> Update(IEnumerable<GroupViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._GroupsRepository.Update(entityCollection).ToList();

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
		public GroupViewModel Update(GroupViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._GroupsRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.IsActive = model.IsActive;
			entity.Date = model.Date;

			entity = this._GroupsRepository.Update(entity);

			ConditionFilter<Group, long> conditionFilter = new ConditionFilter<Group, long>()
			{
				Query = (x =>
						x.ParentKeyGroupId == entity.Id)
			};
			var childs = this._GroupsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._GroupsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._GroupsRepository.Update(en);
			}

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
		public void Delete(IEnumerable<GroupViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._GroupsRepository.Delete(entityCollection);

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
			this._GroupsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(GroupViewModel model)
		{
			var entity = model.ToEntity();
			this._GroupsRepository.Delete(entity);

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
			var result = this._GroupsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
