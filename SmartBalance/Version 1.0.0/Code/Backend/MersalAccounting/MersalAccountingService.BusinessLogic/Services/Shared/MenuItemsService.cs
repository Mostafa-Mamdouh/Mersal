#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides MenuItem service for 
	/// business functionality.
	/// </summary>
	public class MenuItemsService : IMenuItemsService
	{
		#region Data Members
		private readonly IMenuItemsRepository _MenuItemsRepository;
		private readonly IUsersRepository _usersRepository;
		private readonly IUserMenuItemsRepository _UserMenuItemsRepository;
		private readonly ILanguageService _languageService;
		private readonly ICurrentUserService _currentUserService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MenuItemsService.
		/// </summary>
		/// <param name="MenuItemsRepository"></param>
		/// <param name="unitOfWork"></param>
		public MenuItemsService(
			IMenuItemsRepository MenuItemsRepository,
			IUsersRepository usersRepository,
			IUserMenuItemsRepository UserMenuItemsRepository,
			ILanguageService languageService,
			ICurrentUserService currentUserService,
			IUnitOfWork unitOfWork)
		{
			this._MenuItemsRepository = MenuItemsRepository;
			this._usersRepository = usersRepository;
			this._UserMenuItemsRepository = UserMenuItemsRepository;
			this._languageService = languageService;
			this._currentUserService = currentUserService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods

		public IList<UserLightViewModel> GetAllUnSelectedUsersForMenuItem(long menuItemId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<UserLightViewModel> result = null;
			var list = this._UserMenuItemsRepository.Get(null).Where(x => x.MenuItemId == menuItemId);

			if (list.Count() > 0)
			{
				var entityColection = this._usersRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyUserId.HasValue &&
				  x.ParentKeyUser.UserMenuItems.FirstOrDefault(y => y.MenuItemId == menuItemId) == null
				  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._usersRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyUserId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}
		public MenuItemUsersListViewModel GetMenuItemUsers(long MenuItemId)
		{
			var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._UserMenuItemsRepository.Get(null).Where(x => x.MenuItemId == MenuItemId).ToList();

			MenuItemUsersListViewModel result = new MenuItemUsersListViewModel
			{
				MenuItemId = MenuItemId,
				List = new List<NmaeValueViewModel>()
			};

			foreach (var item in entityCollection)
			{
				result.List.Add(new NmaeValueViewModel
				{
					Value = item.UserId.Value,
					Name = item.User.ChildTranslatedUsers.FirstOrDefault(x => x.Language == lang).Name
				});
			}
			return result;
		}
		public MenuItemUsersListViewModel UpdateMenuItemUsers(MenuItemUsersListViewModel model)
		{
			var entityCollection = this._UserMenuItemsRepository.Get(null).Where(x => x.MenuItemId == model.MenuItemId);

			if (entityCollection.Count() > 0)
			{
				foreach (var item in entityCollection)
				{
					this._UserMenuItemsRepository.Delete(item);
				}
				this._unitOfWork.Commit();
			}

			if (model.List?.Count > 0)
			{
				foreach (var item in model.List)
				{
					UserMenuItem newEntity = new UserMenuItem
					{
						MenuItemId = model.MenuItemId,
						UserId = item.Value
					};
					this._UserMenuItemsRepository.Add(newEntity);
				}
				this._unitOfWork.Commit();
			}

			return model;
		}





		public IList<MenuItemLightViewModel> GetAllUnSelectedMenuItemsForUser(long userId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<MenuItemLightViewModel> result = null;
			var list = this._UserMenuItemsRepository.Get(null).Where(x => x.UserId == userId);

			if (list.Count() > 0)
			{
				var entityColection = this._MenuItemsRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyMenuItemId.HasValue &&
				  x.ParentKeyMenuItem.UserMenuItems.FirstOrDefault(y => y.UserId == userId) == null
				  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._MenuItemsRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyMenuItemId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}
		public UserMenuItemsListViewModel GetUserMenuItems(long userId)
		{
			var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._UserMenuItemsRepository.Get(null).Where(x => x.UserId == userId).ToList();

			UserMenuItemsListViewModel result = new UserMenuItemsListViewModel
			{
				UserId = userId,
				List = new List<NmaeValueViewModel>()
			};

			foreach (var item in entityCollection)
			{
				result.List.Add(new NmaeValueViewModel
				{
					Value = item.MenuItemId.Value,
					Name = item.MenuItem.ChildTranslatedMenuItems.FirstOrDefault(x => x.Language == lang).Name
				});
			}
			return result;
		}
		public UserMenuItemsListViewModel UpdateUserMenuItems(UserMenuItemsListViewModel model)
		{
			//var currentUserId = this._currentUserService.CurrentUserId;
			//if (currentUserId == model.UserId)
			//{
			//	throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotChangeHisMenuItems);
			//}

			var entityCollection = this._UserMenuItemsRepository.Get(null).Where(x => x.UserId == model.UserId);

			if (entityCollection.Count() > 0)
			{
				foreach (var item in entityCollection)
				{
					this._UserMenuItemsRepository.Delete(item);
				}
				this._unitOfWork.Commit();
			}

			if (model.List?.Count > 0)
			{
				foreach (var item in model.List)
				{
					UserMenuItem newEntity = new UserMenuItem
					{
						UserId = model.UserId,
						MenuItemId = item.Value
					};
					this._UserMenuItemsRepository.Add(newEntity);
				}
				this._unitOfWork.Commit();
			}

			return model;
		}






		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">MenuItem view model</param>
		public void ThrowExceptionIfExist(MenuItemViewModel model)
		{
			ConditionFilter<MenuItem, long> condition = new ConditionFilter<MenuItem, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._MenuItemsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MenuItemViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<MenuItemViewModel> Get(ConditionFilter<MenuItem, long> condition)
		{
			var entityCollection = this._MenuItemsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<MenuItemViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MenuItemViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<MenuItemViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<MenuItem, long> condition = new ConditionFilter<MenuItem, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._MenuItemsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<MenuItemViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MenuItemViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(ConditionFilter<MenuItem, long> condition)
		{
			var entityCollection = this._MenuItemsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<MenuItemLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MenuItemViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<MenuItem, long> condition = new ConditionFilter<MenuItem, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._MenuItemsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<MenuItemLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a MenuItemViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public MenuItemViewModel Get(long id)
		{
			var entity = this._MenuItemsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public GenericCollectionViewModel<ListMenuItemsLightViewModel> GetByFilter(MenuItemFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<MenuItem, long> condition = new ConditionFilter<MenuItem, long>()
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
			IQueryable<MenuItem> queryableData = this._MenuItemsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyMenuItem != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.Code == model.Code);

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name != null && x.Name.Contains(model.Name));

			if (model.IsActive.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.IsActive == model.IsActive.Value);

			if (string.IsNullOrEmpty(model.Url) == false)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.URL.Contains(model.Url));

			if (model.ItemOrder.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.ItemOrder == model.ItemOrder.Value);

			if (model.HasParent.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.ParentMenuItemId.HasValue == model.HasParent.Value);

			if (model.ParentMenuItemId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyMenuItem.ParentMenuItemId == model.ParentMenuItemId.Value);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyMenuItemId.Value);
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
			var result = new GenericCollectionViewModel<ListMenuItemsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<MenuItemViewModel> Add(IEnumerable<MenuItemViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._MenuItemsRepository.Add(entityCollection).ToList();

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
		public MenuItemViewModel Add(MenuItemViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._MenuItemsRepository.Add(entity);

			var entityAr = new MenuItem
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Title = model.TitleAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedMenuItems.Add(entityAr);
			this._MenuItemsRepository.Add(entityAr);

			var entityEn = new MenuItem
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Title = model.TitleEn,
				Language = Language.English
			};
			entity.ChildTranslatedMenuItems.Add(entityEn);
			this._MenuItemsRepository.Add(entityEn);

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
		public IList<MenuItemViewModel> Update(IEnumerable<MenuItemViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._MenuItemsRepository.Update(entityCollection).ToList();

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
		public MenuItemViewModel Update(MenuItemViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._MenuItemsRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.IsActive = model.IsActive;
			//entity.Date = model.Date;
			entity.ItemOrder = model.ItemOrder;
			entity.RootUrl = model.RootUrl;
            entity.ParentMenuItemId = model.ParentMenuItemId;
            entity.AllowAnonymous = model.AllowAnonymous;
            entity.URL = model.URL;
            entity.OnErrorGoToURL = model.OnErrorGoToURL;

			entity = this._MenuItemsRepository.Update(entity);

			ConditionFilter<MenuItem, long> conditionFilter = new ConditionFilter<MenuItem, long>()
			{
				Query = (x =>
						x.ParentKeyMenuItemId == entity.Id)
			};
			var childs = this._MenuItemsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				ar.Title = model.TitleAr;
				this._MenuItemsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				en.Title = model.TitleEn;
				this._MenuItemsRepository.Update(en);
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
		public void Delete(IEnumerable<MenuItemViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._MenuItemsRepository.Delete(entityCollection);

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
			this._MenuItemsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(MenuItemViewModel model)
		{
			var entity = model.ToEntity();
			this._MenuItemsRepository.Delete(entity);

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
			var result = this._MenuItemsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
