#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
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
	/// Provides Permission service for 
	/// business functionality.
	/// </summary>
	public class PermissionsService : IPermissionsService
	{
		#region Data Members
		private readonly IPermissionsRepository _PermissionsRepository;
		private readonly IRolePermissionsRepository _rolePermissionsRepository;
		private readonly IUserPermissionsRepository _userPermissionsRepository;
		private readonly IGroupPermissionsRepository _groupPermissionsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PermissionsService.
		/// </summary>
		/// <param name="PermissionsRepository"></param>
		/// <param name="unitOfWork"></param>
		public PermissionsService(
			IPermissionsRepository PermissionsRepository,
			IRolePermissionsRepository rolePermissionsRepository,
			IUserPermissionsRepository userPermissionsRepository,
			IGroupPermissionsRepository groupPermissionsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._PermissionsRepository = PermissionsRepository;
			this._rolePermissionsRepository = rolePermissionsRepository;
			this._userPermissionsRepository = userPermissionsRepository;
			this._groupPermissionsRepository = groupPermissionsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Permission view model</param>
		public void ThrowExceptionIfExist(PermissionViewModel model)
		{
			ConditionFilter<Permission, long> condition = new ConditionFilter<Permission, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._PermissionsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PermissionViewModel> Get(ConditionFilter<Permission, long> condition)
		{
			var entityCollection = this._PermissionsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PermissionViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PermissionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Permission, long> condition = new ConditionFilter<Permission, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._PermissionsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PermissionViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PermissionLightViewModel> GetLightModel(ConditionFilter<Permission, long> condition)
		{
			var entityCollection = this._PermissionsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PermissionLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PermissionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Permission, long> condition = new ConditionFilter<Permission, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._PermissionsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PermissionLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a PermissionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PermissionViewModel Get(long id)
		{
			var entity = this._PermissionsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public IList<PermissionLightViewModel> GetAllUnSelectedPermissions(long roleId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<PermissionLightViewModel> result = null;
			var list = this._rolePermissionsRepository.Get(null).Where(x => x.RoleId == roleId);

			if (list.Count() > 0)
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyPermissionId.HasValue &&
				  x.ParentKeyPermission.RolePermissions.FirstOrDefault(y => y.RoleId == roleId) == null
				  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyPermissionId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}

		public IList<PermissionLightViewModel> GetAllUnSelectedPermissionsForUser(long userId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<PermissionLightViewModel> result = null;
			var list = this._userPermissionsRepository.Get(null).Where(x => x.UserId == userId);
			
			if (list.Count() > 0)
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyPermissionId.HasValue &&
				  x.ParentKeyPermission.UserPermissions.FirstOrDefault(y => y.UserId == userId) == null
				  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyPermissionId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}

		public IList<PermissionLightViewModel> GetAllUnSelectedPermissionsForGroup(long groupId)
		{
			var lang = this._languageService.CurrentLanguage;
			IList<PermissionLightViewModel> result = null;
			var list = this._groupPermissionsRepository.Get(null).Where(x => x.GroupId == groupId);

			if (list.Count() > 0)
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
				  x.Language == lang &&
				  x.ParentKeyPermissionId.HasValue &&
				  x.ParentKeyPermission.GroupPermissions.FirstOrDefault(y => y.GroupId == groupId) == null
				  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
				  ).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}
			else
			{
				var entityColection = this._PermissionsRepository.Get().Where(x =>
					x.Language == lang &&
					x.ParentKeyPermissionId.HasValue).ToList();

				var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
				result = modelCollection;
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ListPermissionsLightViewModel> GetByFilter(PermissionFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Permission, long> condition = new ConditionFilter<Permission, long>()
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
			IQueryable<Permission> queryableData = this._PermissionsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyPermission != null);

			if (model.Code.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyPermission.Code == model.Code);

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name != null && x.Name.Contains(model.Name));

			if (model.IsActive.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyPermission.IsActive == model.IsActive.Value);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyPermissionId);
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
			var result = new GenericCollectionViewModel<ListPermissionsLightViewModel>
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
		public IList<PermissionViewModel> Add(IEnumerable<PermissionViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PermissionsRepository.Add(entityCollection).ToList();

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
		public PermissionViewModel Add(PermissionViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._PermissionsRepository.Add(entity);

			var entityAr = new Permission
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedPermissions.Add(entityAr);
			this._PermissionsRepository.Add(entityAr);

			var entityEn = new Permission
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedPermissions.Add(entityEn);
			this._PermissionsRepository.Add(entityEn);

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
		public IList<PermissionViewModel> Update(IEnumerable<PermissionViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PermissionsRepository.Update(entityCollection).ToList();

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
		public PermissionViewModel Update(PermissionViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._PermissionsRepository.Get(model.Id);
			//entity.Code = model.Code;
			//entity.IsActive = model.IsActive;

			entity = this._PermissionsRepository.Update(entity);

			ConditionFilter<Permission, long> conditionFilter = new ConditionFilter<Permission, long>()
			{
				Query = (x =>
						x.ParentKeyPermissionId == entity.Id)
			};
			var childs = this._PermissionsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._PermissionsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._PermissionsRepository.Update(en);
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
		public void Delete(IEnumerable<PermissionViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PermissionsRepository.Delete(entityCollection);

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
			this._PermissionsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PermissionViewModel model)
		{
			var entity = model.ToEntity();
			this._PermissionsRepository.Delete(entity);

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
			var result = this._PermissionsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
