#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
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
	/// Provides Safe service for 
	/// business functionality.
	/// </summary>
	public class SafesService : ISafesService
	{
		#region Data Members
		private readonly ISafesRepository _SafesRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ISafeAccountChartsRepository _safeAccountChartsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SafesService.
        /// </summary>
        /// <param name="SafesRepository"></param>
        /// <param name="unitOfWork"></param>
        public SafesService(
            ISafesRepository SafesRepository,
            IAccountChartsRepository accountChartsRepository,
            ISafeAccountChartsRepository safeAccountChartsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._SafesRepository = SafesRepository;
            this._accountChartsRepository = accountChartsRepository;
            this._safeAccountChartsRepository = safeAccountChartsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Safe view model</param>
		public void ThrowExceptionIfExist(SafeViewModel model)
		{
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._SafesRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<SafeViewModel> Get(ConditionFilter<Safe, long> condition)
		{
			var entityCollection = this._SafesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<SafeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<SafeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._SafesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<SafeViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<SafeLightViewModel> GetLightModel(ConditionFilter<Safe, long> condition)
		{
			var entityCollection = this._SafesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<SafeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<SafeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._SafesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<SafeLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a SafeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public SafeViewModel Get(long id)
		{
			var entity = this._SafesRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Gets a SafeViewModel by branch id.
		/// </summary>
		/// <param name="branchId"></param>
		/// <returns></returns>
		public SafeViewModel GetByBranchId(long branchId)
        {
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
			{
				Query = x =>
					x.Language == lang &&
					x.ParentKeySafe.BranchId == branchId
			};
            var entity = this._SafesRepository.Get(condition).FirstOrDefault();
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Gets a SafeLightViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of SafeLightViewModel </returns>
        public List<SafeLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
			{
				Query = (item => item.Language == lang)
			};

			var entityCollection = this._SafesRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return lookup;
        }

        public List<AccountChartLightViewModel> GetAccountCharts(long safeId, long currencyId)
        {
            IEnumerable<AccountChart> accountCharts;
            List<AccountChartLightViewModel> accountChartViewModels = new List<AccountChartLightViewModel>();
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>
            {
                Query = (item => item.Language == lang)
            };
            var safe = this._SafesRepository.Get().Where(x => x.Id == safeId && x.SafeAccountCharts.Any(s => s.AccountChart.CurrencyId == currencyId));
            if (safe.Count() > 0)
            {
                accountCharts = safe.Select(x => x.SafeAccountCharts).FirstOrDefault().Select(c => c.AccountChart);

                accountChartViewModels = accountCharts.Select(x => x.ToLightModel()).ToList();
                foreach (var item in accountChartViewModels)
                {
                    item.DisplyedName = $"{item.DisplyedName}{accountCharts.FirstOrDefault(x => x.Id == item.Id).ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name}";
                }
            }
            return accountChartViewModels;

        }


        public GenericCollectionViewModel<ListSafesLightViewModel> GetByFilter(SafeFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Safe, long> condition = new ConditionFilter<Safe, long>()
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
			IQueryable<Safe> queryableData = this._SafesRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeySafe != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeySafe.Code.Contains(model.Code));

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

			if (model.OpeningCreditFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeySafe.OpeningCredit >= model.OpeningCreditFrom);

			if (model.OpeningCreditTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeySafe.OpeningCredit <= model.OpeningCreditTo);

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeySafe.Date >= model.DateFrom);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeySafe.Date <= model.DateTo);

			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeySafeId);
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
			var result = new GenericCollectionViewModel<ListSafesLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

        public SafeAccountChartListViewModel GetSafeAccountChart(long safeId)
        {
            var lang = this._languageService.CurrentLanguage;
            var entityCollection = this._safeAccountChartsRepository.Get(null).Where(x => x.SafeId == safeId).ToList();

            SafeAccountChartListViewModel result = new SafeAccountChartListViewModel
            {
                safeId = safeId,
                List = new List<NmaeValueViewModel>()
            };

            foreach (var item in entityCollection)
            {
                result.List.Add(new NmaeValueViewModel
                {
                    Value = item.AccountChartId,
                    Name = item.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name
                });
            }
            return result;
        }
        public SafeAccountChartListViewModel UpdateSafeAccountChart(SafeAccountChartListViewModel model)
        {

            var entityCollection = this._safeAccountChartsRepository.Get(null).Where(x => x.SafeId == model.safeId);

            if (entityCollection.Count() > 0)
            {
                foreach (var item in entityCollection)
                {
                    this._safeAccountChartsRepository.Delete(item);
                }
                this._unitOfWork.Commit();
            }

            if (model.List?.Count > 0)
            {
                foreach (var item in model.List)
                {
                    SafeAccountChart newEntity = new SafeAccountChart
                    {
                        SafeId = model.safeId,
                        AccountChartId = item.Value
                    };
                    this._safeAccountChartsRepository.Add(newEntity);
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
        public IList<SafeViewModel> Add(IEnumerable<SafeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._SafesRepository.Add(entityCollection).ToList();

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
		public SafeViewModel Add(SafeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._SafesRepository.Add(entity);

			var entityAr = new Safe
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedSafes.Add(entityAr);
			this._SafesRepository.Add(entityAr);

			var entityEn = new Safe
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedSafes.Add(entityEn);
			this._SafesRepository.Add(entityEn);

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
		public IList<SafeViewModel> Update(IEnumerable<SafeViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._SafesRepository.Update(entityCollection).ToList();

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
		public SafeViewModel Update(SafeViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._SafesRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.Date = model.Date;
			//entity.AccountChartId = model.AccountChartId;
			entity.BranchId = model.BranchId;

			entity = this._SafesRepository.Update(entity);

			ConditionFilter<Safe, long> conditionFilter = new ConditionFilter<Safe, long>()
			{
				Query = (x =>
						x.ParentKeySafeId == entity.Id)
			};
			var childs = this._SafesRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._SafesRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._SafesRepository.Update(en);
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
		public void Delete(IEnumerable<SafeViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._SafesRepository.Delete(entityCollection);

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
			this._SafesRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(SafeViewModel model)
		{
			var entity = model.ToEntity();
			this._SafesRepository.Delete(entity);

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
			var result = this._SafesRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
