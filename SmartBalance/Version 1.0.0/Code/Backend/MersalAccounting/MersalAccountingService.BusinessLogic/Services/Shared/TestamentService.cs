#region using...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class TestamentService : ITestamentService
    {

        #region Data Members
        private readonly ITestamentRepository _testamentRepository;
        private readonly IAdvancesRepository _advancesRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJournalsService _journalsService;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public TestamentService(
            ITestamentRepository testamentRepository,
            IAdvancesRepository advancesRepository,
            IJournalPostingsService journalPostingsService,
            IAccountChartsRepository accountChartsRepository,
            ICurrentUserService currentUserService,
            IJournalsService journalsService,
            ILanguageService languageService,
            IUnitOfWork unitOfWork
            )
        {
            this._testamentRepository = testamentRepository;
            this._advancesRepository = advancesRepository;
            this._journalPostingsService = journalPostingsService;
            this._accountChartsRepository = accountChartsRepository;
            this._currentUserService = currentUserService;
            this._journalsService = journalsService;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public void ThrowExceptionIfExist(TestamentViewModel model)
        {
            ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._testamentRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public GenericCollectionViewModel<ListTestamentLightViewModel> GetByFilter(TestamentFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>()
            {
                Order = Framework.Common.Enums.Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();

            // The IQueryable data to query.  
            IQueryable<Testament> queryableData = this._testamentRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyTestament != null);
            //queryableData = queryableData.Where(x => x.ParentKeyTestament == null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.Code.Contains(model.Code));

            if (model.AdvancesTypeId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.AdvancesTypeId == model.AdvancesTypeId);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.Date <= model.DateTo);

            if (model.TotalValueFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.TotalValue >= model.TotalValueFrom.Value);

            if (model.TotalValueTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyTestament.TotalValue <= model.TotalValueTo.Value);

            if (model.IsClosed.HasValue)
                queryableData = queryableData.Where(x => (x.ParentKeyTestament.Advances.Count > 0) == model.IsClosed.Value);

            if (string.IsNullOrEmpty(model.Description) == false)
                queryableData = queryableData.Where(x => x.Description.Contains(model.Description));


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyTestamentId);

                var advance = item.ParentKeyTestament.Advances.Where(x => x.IsClosed == false).ToList();

                ViewModel.IsClosed = !(advance.Count > 0); 

                //ViewModel.Testament = item.Testament.ChildTranslatedTestaments.FirstOrDefault(x => x.Language == lang).Name;

                //ViewModel.ExchangeTestament = item.ExchangeTestament.ChildTranslatedTestaments.FirstOrDefault(x => x.Language == lang).Name;

                //if (item.ParentKeyBank != null)
                //{
                //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                //}              
            }
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListTestamentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentViewModel> Get(ConditionFilter<Testament, long> condition)
        {
            var entityCollection = this._testamentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._testamentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(ConditionFilter<Testament, long> condition)
        {
            var entityCollection = this._testamentRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._testamentRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a TestamentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestamentViewModel Get(long id)
        {
            var entity = this._testamentRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        public List<string> GetCodes(int advancesTypeId)
        {
            return this._testamentRepository.Get().Where(x => x.AdvancesTypeId == advancesTypeId).Select(x => x.Code).ToList();
        }

        public string GenerateNewCode()
        {
            long newCode = 0;
            try
            {
                ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
                {
                    Query = x =>
                        x.ParentKeyTestamentId == null &&
                        string.IsNullOrEmpty(x.Code) == false
                        ,
                    Order = Order.Descending
                };

                var z = this._testamentRepository.Get(condition);
                var lastEntity = z.FirstOrDefault();
                newCode = 1;

                if (lastEntity != null)
                {
                    try
                    {
                        newCode = long.Parse(lastEntity.Code) + 1;
                    }
                    catch
                    {
                        newCode = lastEntity.Id;
                    }
                }
                
                //entity.Code = newCode.ToString();
            }
            catch
            {
                //entity.Code = entity.Id.ToString();
                newCode = 0;
            }
            return newCode.ToString();
        }

        public List<TestamentLightViewModel> GetLookUp()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
			{
				Query = (item => item.Language == lang)
			};
			var entityCollection = this._testamentRepository.Get(condition).ToList();
			List<TestamentLightViewModel> lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			return lookup;
		}
		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<TestamentViewModel> Add(IEnumerable<TestamentViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._testamentRepository.Add(entityCollection).ToList();

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
		public TestamentViewModel Add(TestamentViewModel model)
		{

            if (model.Journal == null)
            {
                this.ThrowExceptionIfExist(model);
                var entity = model.ToEntity();
                entity = this._testamentRepository.Add(entity);

                foreach (var advance in model.Advances)
                {
                    var advanceEntity = advance.ToEntity();
                    advanceEntity.Testament = entity;
                    advanceEntity.CurrentAmount = advanceEntity.Amount;
                    advanceEntity.IsClosed = false;
                    entity.Advances.Add(advanceEntity);
                    advanceEntity = this._advancesRepository.Add(advanceEntity);

                    var advanceEntityAr = new Advance
                    {
                        Description = advance.DescriptionAr,
                        Language = Language.Arabic,
                        ParentKeyAdvance = advanceEntity
                    };
                    advanceEntity.ChildTranslatedAdvances.Add(advanceEntityAr);
                    this._advancesRepository.Add(advanceEntityAr);

                    var advanceEntityEn = new Advance
                    {
                        Description = advance.DescriptionEn,
                        Language = Language.English,
                        ParentKeyAdvance = advanceEntity
                    };
                    advanceEntity.ChildTranslatedAdvances.Add(advanceEntityEn);
                    this._advancesRepository.Add(advanceEntityEn);
                }
                var entityAr = new Testament
                {
                    //Id = entity.Id,
                    Description = model.DescriptionAr,
                    Language = Language.Arabic
                };
                entity.ChildTranslatedCustodies.Add(entityAr);
                this._testamentRepository.Add(entityAr);

                var entityEn = new Testament
                {
                    //Id = entity.Id,
                    Description = model.DescriptionEn,
                    Language = Language.English
                };
                entity.ChildTranslatedCustodies.Add(entityEn);
                this._testamentRepository.Add(entityEn);

                #region Commit Changes
                this._unitOfWork.Commit();
                #endregion

                model.Id = entity.Id;

                //this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.PaymentMovement);
                model.Journal = this._journalPostingsService.Post(model.Id, MovementType.Testament);

                model.Journal.Date = model.Date.Value;

                foreach (var Journal in model.Journal.journalDetails)
                {
                    Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
                }
            }
            else if(model.Journal.PostingStatus == PostingStatus.Approved)
            {
                this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);
                var entity = this._testamentRepository.Get(model.Id);
                if (entity != null)
                {
                    entity.IsPosted = false;
                    entity.PostingDate = DateTime.Now;
                    entity.PostedByUserId = this._currentUserService.CurrentUserId;
                    entity = this._testamentRepository.Update(entity);
                }

                this._unitOfWork.Commit();
            }
            else if(model.Journal.PostingStatus == PostingStatus.Rejected)
            {

            }
				return model;

		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<TestamentViewModel> Update(IEnumerable<TestamentViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._testamentRepository.Update(entityCollection).ToList();

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
		public TestamentViewModel Update(TestamentViewModel model)
		{
			//this.ThrowExceptionIfExist(model);

			var entity = this._testamentRepository.Get(model.Id); //model.ToEntity();
			entity = this._testamentRepository.Update(entity);

			Testament entityAr = entity.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.Arabic);
			entityAr.Description = model.DescriptionAr;
			this._testamentRepository.Update(entityAr);
			Testament entityEn = entity.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.English);
			entityEn.Description = model.DescriptionEn;
			this._testamentRepository.Update(entityEn);

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
		public void Delete(IEnumerable<TestamentViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._testamentRepository.Delete(entityCollection);

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
			this._testamentRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(TestamentViewModel model)
		{
			var entity = model.ToEntity();
			this._testamentRepository.Delete(entity);

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
			var result = this._testamentRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
