#region using...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
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
    public class AccountChartDocumentService : IAccountChartDocumentService
    {
        #region Data Members
        private readonly IAccountChartDocumentRepository _accountDocumentRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public AccountChartDocumentService(
            IAccountChartDocumentRepository accountDocumentRepository,
            IAccountChartsRepository accountChartsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork
            )
        {
            this._accountDocumentRepository = accountDocumentRepository;
            this._accountChartsRepository = accountChartsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public void ThrowExceptionIfExist(AccountChartDocumentViewModel model)
        {
            ConditionFilter<AccountChartDocument, long> condition = new ConditionFilter<AccountChartDocument, long>
            {
                Query = (entity =>
                    entity.Id != model.Id &&
                    entity.AccountChartId == model.AccountChartId &&
                    entity.DocumentId == model.DocumentId)
            };
            var existEntity = this._accountDocumentRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        public GenericCollectionViewModel<ListAccountChartDocumentLightViewModel> GetByFilter(AccountChartDocumentFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AccountChartDocument, long> condition = new ConditionFilter<AccountChartDocument, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }


           // The IQueryable data to query.
           IQueryable<AccountChartDocument> queryableData = this._accountDocumentRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBank != null);

            if (model.AccountChartId.HasValue)
                queryableData = queryableData.Where(x => x.AccountChartId == model.AccountChartId.Value);

            //if (string.IsNullOrEmpty(model.Name) == false)
            //    queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            //if (model.OpeningCreditFrom.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.OpeningCredit >= model.OpeningCreditFrom);

            //if (model.OpeningCreditTo.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.OpeningCredit <= model.OpeningCreditTo);

            //if (model.DateFrom.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.Date >= model.DateFrom);

            //if (model.DateTo.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var accountIds = entityCollection.Select(x => x.AccountChartId).Distinct();
            var dtoCollection = new List<ListAccountChartDocumentLightViewModel>(); //entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var item in accountIds)
            {
                var ViewModel = entityCollection.Select(x => x.ToListModel()).FirstOrDefault(x => x.AccountChartId == item); //dtoCollection.Find(x => x.AccountId == item);

                AccountChart accountChart = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == item);

                ViewModel.AccountChartName = $"{accountChart.ParentAccountChart.FullCode}-{accountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name}";

                dtoCollection.Add(ViewModel);


                //if (item.ParentKeyBank != null)
                //{
                //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                //}              
            }
            
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListAccountChartDocumentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<AccountChartDocumentViewModel> Get(ConditionFilter<AccountChartDocument, long> condition)
        {
            var entityCollection = this._accountDocumentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AccountChartDocumentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<AccountChartDocumentViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<AccountChartDocument, long> condition = new ConditionFilter<AccountChartDocument, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._accountDocumentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AccountChartDocumentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public List<AccountChartDocumentViewModel> Get(long accountId)
        {
            return _accountDocumentRepository.Get().Where(x => x.AccountChartId == accountId).ToList().Select(e => e.ToModel()).ToList();
        }

        public AccountChartDocumentViewModel Get(long bankId, long documentId)
        {
            return this._accountDocumentRepository.Get().FirstOrDefault(e => e.AccountChartId == bankId && e.DocumentId == documentId).ToModel();
        }

        public IList<AccountChartDocumentViewModel> Add(IEnumerable<AccountChartDocumentViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._accountDocumentRepository.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public AccountChartDocumentViewModel Add(AccountChartDocumentViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._accountDocumentRepository.Add(entity);


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public IList<AccountChartDocumentViewModel> Update(IEnumerable<AccountChartDocumentViewModel> collection)
        {
            //foreach (var model in collection)
            //{
            //    this.ThrowExceptionIfExist(model);
            //}

            IEnumerable<AccountChartDocumentViewModel> accountDocumentsDelete = collection.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Delete);
            if(accountDocumentsDelete != null && accountDocumentsDelete.Count() > 0)
            {
                foreach (var accountDocumentDelete in accountDocumentsDelete)
                {
                    AccountChartDocument accountDocument = this._accountDocumentRepository.Get().FirstOrDefault(x => x.AccountChartId == accountDocumentDelete.AccountChartId && x.DocumentId == accountDocumentDelete.DocumentId);
                    if(accountDocument != null)
                        this._accountDocumentRepository.Delete(accountDocument);
                }
            }
            IEnumerable<AccountChartDocumentViewModel> accountDocumentsAdd = collection.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Add);
            if(accountDocumentsAdd != null && accountDocumentsAdd.Count() > 0)
            {
                foreach(var accountDocumentAdd in accountDocumentsAdd)
                {
                    try
                    {
                        ThrowExceptionIfExist(accountDocumentAdd);
                        this._accountDocumentRepository.Add(accountDocumentAdd.ToEntity());
                    }
                    catch (ItemAlreadyExistException)
                    {
                        continue;
                    }
                }
            }



            //var entityCollection = collection.Select(model => model.ToEntity());
            var modelCollection = accountDocumentsDelete.Union(accountDocumentsAdd); //this._accountDocumentRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            //var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection.ToList();
        }

        public AccountChartDocumentViewModel Update(AccountChartDocumentViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._accountDocumentRepository.Update(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public void Delete(IEnumerable<AccountChartDocumentViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._accountDocumentRepository.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(IEnumerable<long> collection)
        {
            this._accountDocumentRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(AccountChartDocumentViewModel model)
        {
            var entity = model.ToEntity();
            this._accountDocumentRepository.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(long id)
        {
            var result = this._accountDocumentRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }


        #endregion
    }
}
