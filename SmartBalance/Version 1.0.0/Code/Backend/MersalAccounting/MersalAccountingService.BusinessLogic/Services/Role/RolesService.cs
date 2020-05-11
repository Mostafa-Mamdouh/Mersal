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
	/// Provides Role service for 
	/// business functionality.
	/// </summary>
	public class RolesService : IRolesService
	{
		#region Data Members
		private readonly IRolesRepository _RolesRepository;
		private readonly IRolePermissionsRepository _rolePermissionsRepository;
		private readonly IUserRolesRepository _userRolesRepository;
		private readonly IGroupPermissionsRepository _groupPermissionsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type RolesService.
		/// </summary>
		/// <param name="RolesRepository"></param>
		/// <param name="unitOfWork"></param>
		public RolesService(
			IRolesRepository RolesRepository,
			IRolePermissionsRepository rolePermissionsRepository,
			IUserRolesRepository userRolesRepository,
			IGroupPermissionsRepository groupPermissionsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._RolesRepository = RolesRepository;
			this._rolePermissionsRepository = rolePermissionsRepository;
			this._userRolesRepository = userRolesRepository;
			this._groupPermissionsRepository = groupPermissionsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Role view model</param>
		public void ThrowExceptionIfExist(RoleViewModel model)
		{
			ConditionFilter<Role, long> condition = new ConditionFilter<Role, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._RolesRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<RoleViewModel> Get(ConditionFilter<Role, long> condition)
		{
			var entityCollection = this._RolesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<RoleViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<RoleViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Role, long> condition = new ConditionFilter<Role, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._RolesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<RoleViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<RoleLightViewModel> GetLightModel(ConditionFilter<Role, long> condition)
		{
			var entityCollection = this._RolesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<RoleLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<RoleLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Role, long> condition = new ConditionFilter<Role, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._RolesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<RoleLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a RoleViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RoleViewModel Get(long id)
		{
			var entity = this._RolesRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public GenericCollectionViewModel<ListRolesLightViewModel> GetByFilter(RoleFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Role, long> condition = new ConditionFilter<Role, long>()
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
			IQueryable<Role> queryableData = this._RolesRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyRole != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyRole.Code == model.Code);

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name != null && x.Name.Contains(model.Name));

			if (model.IsActive.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyRole.IsActive == model.IsActive.Value);

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyRole.Date >= model.DateFrom.Value);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyRole.Date <= model.DateTo.Value);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyRoleId.Value);
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
			var result = new GenericCollectionViewModel<ListRolesLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}


		public IList<RoleLightViewModel> GetAllUnSelectedRolesForUser(long userId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<RoleLightViewModel> result = null;
			var list = this._userRolesRepository.Get(null).Where(x => x.UserId == userId);

			if (list.Count() > 0)
			{
				var entityColection = this._RolesRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyRoleId.HasValue &&
				  x.ParentKeyRole.UserRoles.FirstOrDefault(y => y.UserId == userId) == null
				  //list.Any(item => x.ParentKeyRoleId != item.RoleId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._RolesRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyRoleId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}

		public RolePermissionListViewModel GetRolePermission(long roleId)
		{
			var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._rolePermissionsRepository.Get(null).Where(x => x.RoleId == roleId).ToList();

			RolePermissionListViewModel result = new RolePermissionListViewModel
			{
				RoleId = roleId,
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
		public RolePermissionListViewModel UpdateRolePermission(RolePermissionListViewModel model)
		{
			var entityCollection = this._rolePermissionsRepository.Get(null).Where(x => x.RoleId == model.RoleId);

			if (entityCollection.Count() > 0)
			{
				foreach (var item in entityCollection)
				{
					this._rolePermissionsRepository.Delete(item);
				}
				this._unitOfWork.Commit();
			}

			if (model.List?.Count > 0)
			{
				foreach (var item in model.List)
				{
					RolePermission newEntity = new RolePermission
					{
						RoleId = model.RoleId,
						PermissionId = item.Value
					};
					this._rolePermissionsRepository.Add(newEntity);
				}
				this._unitOfWork.Commit();
			}

			return model;
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


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<RoleViewModel> Add(IEnumerable<RoleViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._RolesRepository.Add(entityCollection).ToList();

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
		public RoleViewModel Add(RoleViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._RolesRepository.Add(entity);

			var entityAr = new Role
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedRoles.Add(entityAr);
			this._RolesRepository.Add(entityAr);

			var entityEn = new Role
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedRoles.Add(entityEn);
			this._RolesRepository.Add(entityEn);

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
		public IList<RoleViewModel> Update(IEnumerable<RoleViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._RolesRepository.Update(entityCollection).ToList();

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
		public RoleViewModel Update(RoleViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._RolesRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.IsActive = model.IsActive;
			entity.Date = model.Date;

			entity = this._RolesRepository.Update(entity);

			ConditionFilter<Role, long> conditionFilter = new ConditionFilter<Role, long>()
			{
				Query = (x =>
						x.ParentKeyRoleId == entity.Id)
			};
			var childs = this._RolesRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._RolesRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._RolesRepository.Update(en);
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
		public void Delete(IEnumerable<RoleViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._RolesRepository.Delete(entityCollection);

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
			this._RolesRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(RoleViewModel model)
		{
			var entity = model.ToEntity();
			this._RolesRepository.Delete(entity);

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
			var result = this._RolesRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
