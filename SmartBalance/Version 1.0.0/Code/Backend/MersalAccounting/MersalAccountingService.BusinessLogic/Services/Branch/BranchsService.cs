#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.BusinessLogic.Common;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
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
	/// Provides Branch service for 
	/// business functionality.
	/// </summary>
	public class BranchsService : IBranchsService
	{
		#region Data Members
		private readonly IBranchsRepository _BranchsRepository;
        private readonly IUserBranchsRepository _userBranchsRepository;
        private readonly ICurrentUserService _currentUserService;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BranchsService.
		/// </summary>
		/// <param name="BranchsRepository"></param>
		/// <param name="unitOfWork"></param>
		public BranchsService(
			IBranchsRepository BranchsRepository,
            IUserBranchsRepository userBranchsRepository,
            ICurrentUserService currentUserService,
            ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._BranchsRepository = BranchsRepository;
            this._userBranchsRepository = userBranchsRepository;
            this._currentUserService = currentUserService;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Branch view model</param>
		public void ThrowExceptionIfExist(BranchViewModel model)
		{
			ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._BranchsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BranchViewModel> Get(ConditionFilter<Branch, int> condition)
		{
			var entityCollection = this._BranchsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BranchViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BranchViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
			};
			var entityCollection = this._BranchsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BranchViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BranchLightViewModel> GetLightModel(ConditionFilter<Branch, int> condition)
		{			
			var entityCollection = this._BranchsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BranchLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BranchLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (x => 
					x.Language == lang)
			};
			var entityCollection = this._BranchsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BranchLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a BranchViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public BranchViewModel Get(int id)
		{
			var entity = this._BranchsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public List<BranchLightViewModel> GetLookUp()
        {
			var lang = this._languageService.CurrentLanguage;
            var userBranchs = this._userBranchsRepository.Get().Where(x => x.UserId == this._currentUserService.CurrentUserId).Select(x => x.Branch);
   //         ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>
			//{
			//	Query = (x => 
			//		x.Language == lang)
			//};
            var entityCollection = userBranchs.ToList(); // this._BranchsRepository.Get(condition).ToList();
            for (int i = 0; i < entityCollection.Count; i++)
            {
                entityCollection[i] = entityCollection[i].ChildTranslatedBranchs.FirstOrDefault(x => x.Language == lang);
            }
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return lookup;
        }

		public GenericCollectionViewModel<ListBranchsLightViewModel> GetByFilter(BranchFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			//if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

			// The IQueryable data to query.  
			IQueryable<Branch> queryableData = this._BranchsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBranch != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyBranch.Code.Contains(model.Code));

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBranch.Date >= model.DateFrom);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBranch.Date <= model.DateTo);

			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBranchId);
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
			var result = new GenericCollectionViewModel<ListBranchsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}


        public IList<BranchLightViewModel> GetAllUnSelectedBranchForUser(long userId)
        {
            var lang = this._languageService.CurrentLanguage;
            IList<BranchLightViewModel> result = null;
            var list = this._userBranchsRepository.Get(null).Where(x => x.UserId == userId);

            if (list.Count() > 0)
            {
                var entityColection = this._BranchsRepository.Get().Where(x =>
                  x.Language == lang &&
                  x.ParentKeyBranchId.HasValue &&
                  x.ParentKeyBranch.UserBranches.FirstOrDefault(y => y.UserId == userId) == null
                  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
                  ).ToList();

                var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
                result = modelCollection;
            }
            else
            {
                var entityColection = this._BranchsRepository.Get().Where(x =>
                    x.Language == lang &&
                    x.ParentKeyBranchId.HasValue).ToList();

                var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
                result = modelCollection;
            }

            return result;
        }


        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<BranchViewModel> Add(IEnumerable<BranchViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BranchsRepository.Add(entityCollection).ToList();

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
		public BranchViewModel Add(BranchViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._BranchsRepository.Add(entity);

			var entityAr = new Branch
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedBranchs.Add(entityAr);
			this._BranchsRepository.Add(entityAr);

			var entityEn = new Branch
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedBranchs.Add(entityEn);
			this._BranchsRepository.Add(entityEn);

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
		public IList<BranchViewModel> Update(IEnumerable<BranchViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BranchsRepository.Update(entityCollection).ToList();

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
		public BranchViewModel Update(BranchViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = this._BranchsRepository.Get(model.Id); //model.ToEntity();

			entity.Code = model.Code;
			entity.Date = model.Date;

			entity = this._BranchsRepository.Update(entity);

			ConditionFilter<Branch, int> conditionFilter = new ConditionFilter<Branch, int>()
			{
				Query = (x =>
						x.ParentKeyBranchId == entity.Id)
			};
			var childs = this._BranchsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._BranchsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._BranchsRepository.Update(en);
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
		public void Delete(IEnumerable<BranchViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._BranchsRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<int> collection)
		{
			this._BranchsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(BranchViewModel model)
		{
			var entity = model.ToEntity();
			this._BranchsRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var result = this._BranchsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
