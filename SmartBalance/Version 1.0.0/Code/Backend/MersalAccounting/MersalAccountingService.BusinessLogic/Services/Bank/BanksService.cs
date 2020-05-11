#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
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
    /// Provides Bank service for 
    /// business functionality.
    /// </summary>
    public class BanksService : IBanksService
    {
        #region Data Members
        private readonly IBanksRepository _BanksRepository;
        private readonly IBankAccountChartRepository _bankAccountChartRepository;
        private readonly IAccountChartDocumentRepository _accountChartDocumentRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type BanksService.
        /// </summary>
        /// <param name="BanksRepository"></param>
        /// <param name="unitOfWork"></param>
        public BanksService(
            IBanksRepository BanksRepository,
            IBankAccountChartRepository bankAccountChartRepository,
            IAccountChartDocumentRepository accountChartDocumentRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._BanksRepository = BanksRepository;
            this._bankAccountChartRepository = bankAccountChartRepository;
            this._accountChartDocumentRepository = accountChartDocumentRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Bank view model</param>
        public void ThrowExceptionIfExist(BankViewModel model)
        {
            ConditionFilter<Bank, long> condition = new ConditionFilter<Bank, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._BanksRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }


        public GenericCollectionViewModel<ListBankLightViewModel> GetByFilter(BankFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Bank, long> condition = new ConditionFilter<Bank, long>()
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
            IQueryable<Bank> queryableData = this._BanksRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBank != null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyBank.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (model.OpeningCreditFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyBank.OpeningCredit >= model.OpeningCreditFrom);

            if (model.OpeningCreditTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyBank.OpeningCredit <= model.OpeningCreditTo);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyBank.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyBank.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBankId);

            //    //if (item.ParentKeyBank != null)
            //    //{
            //    //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
            //    //}    

            //}
            //if (model.Filters != null)
            //{
            //    foreach (var item in model.Filters)
            //    {
            //        switch (item.Field)
            //        {
            //            case "source":
            //                dtoCollection = dtoCollection.Where(x => x.Source.Contains(item.Value)).ToList();
            //                break;
            //            case "amount":
            //                dtoCollection = dtoCollection.Where(x => x.Amount.Equals(Convert.ToDecimal(item.Value))).ToList();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            foreach (var item in dtoCollection)
            {
                var bankAccountChart = this._bankAccountChartRepository.Get().Where(x => x.BankId == item.Id);
                item.AccountChartCount = bankAccountChart.Count();
                ConditionFilter<AccountChartDocument, long> conditionCount = new ConditionFilter<AccountChartDocument, long>()
                {
                    Query = (i => bankAccountChart.Any(x => x.AccountChartId == i.AccountChartId))
                };
                item.AccountChartDocumentsCount = this._accountChartDocumentRepository.Get(conditionCount).Count();
            }
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListBankLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<BankViewModel> Get(ConditionFilter<Bank, long> condition)
        {
            var entityCollection = this._BanksRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<BankViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<BankViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Bank, long> condition = new ConditionFilter<Bank, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._BanksRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<BankViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<BankLightViewModel> GetLightModel(ConditionFilter<Bank, long> condition)
        {
            var entityCollection = this._BanksRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<BankLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<BankLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Bank, long> condition = new ConditionFilter<Bank, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._BanksRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<BankLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a BankViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankViewModel Get(long id)
        {
            var entity = this._BanksRepository.Get(id);
            var model = entity.ToModel();

            //model.NameAr = entity.ChildTranslatedBanks.FirstOrDefault(x => x.Language == Language.Arabic).Name;
            //model.NameEn = entity.ChildTranslatedBanks.FirstOrDefault(x => x.Language == Language.English).Name;
            //model.DescriptionAr = entity.ChildTranslatedBanks.FirstOrDefault(x => x.Language == Language.Arabic).Description;
            //model.DescriptionEn = entity.ChildTranslatedBanks.FirstOrDefault(x => x.Language == Language.English).Description;

            return model;
        }
        /// <summary>
		/// Gets a BankViewModel Lookup.
		/// </summary>
		/// <param></param>
		/// <returns> List<BankLightViewModel> </returns>
        public List<BankLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            ConditionFilter<Bank, long> condition = new ConditionFilter<Bank, long>
            {
                Query = (item =>
                item.Language == lang)
            };
            var entityCollection = this._BanksRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }

        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<BankViewModel> Add(IEnumerable<BankViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._BanksRepository.Add(entityCollection).ToList();

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
        public BankViewModel Add(BankViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._BanksRepository.Add(entity);

            var entityAr = new Bank
            {
                Id = entity.Id,
                Description = model.DescriptionAr,
                Name = model.NameAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedBanks.Add(entityAr);
            this._BanksRepository.Add(entityAr);

            var entityEn = new Bank
            {
                Id = entity.Id,
                Description = model.DescriptionEn,
                Name = model.NameEn,
                Language = Language.English
            };
            entity.ChildTranslatedBanks.Add(entityEn);
            this._BanksRepository.Add(entityEn);


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
        public IList<BankViewModel> Update(IEnumerable<BankViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._BanksRepository.Update(entityCollection).ToList();

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
        public BankViewModel Update(BankViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._BanksRepository.Update(entity);

            ConditionFilter<Bank, long> conditionFilter = new ConditionFilter<Bank, long>()
            {
                Query = (x =>
                        x.ParentKeyBankId == entity.Id)
            };
            var childs = this._BanksRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._BanksRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._BanksRepository.Update(en);
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
        public void Delete(IEnumerable<BankViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._BanksRepository.Delete(entityCollection);

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
            this._BanksRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BankViewModel model)
        {
            var entity = model.ToEntity();
            this._BanksRepository.Delete(entity);

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
            var result = this._BanksRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        #endregion
    }
}
