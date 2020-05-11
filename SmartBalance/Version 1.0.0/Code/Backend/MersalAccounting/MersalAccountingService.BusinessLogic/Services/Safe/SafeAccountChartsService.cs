#region using ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
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
    public class SafeAccountChartsService : ISafeAccountChartsService
    {
        #region Data Members
        private readonly ISafeAccountChartsRepository _safeAccountChartsRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageService _languageService;
        #endregion

        #region Constructors
        public SafeAccountChartsService(ISafeAccountChartsRepository safeAccountChartsRepository, IAccountChartsRepository accountChartsRepository, IUnitOfWork UnitOfWork, ILanguageService languageService)
        {
            this._safeAccountChartsRepository = safeAccountChartsRepository;
            this._accountChartsRepository = accountChartsRepository;
            this._unitOfWork = UnitOfWork;
            this._languageService = languageService;
        }
        #endregion

        #region Methods
        public void ThrowExceptionIfExist(SafeAccountChartViewModel model)
        {
            //////ConditionFilter<SafeAccountChart, long> condition = new ConditionFilter<SafeAccountChart, long>
            //////{
            //////    Query = (entity =>
            //////        entity.BankId == model.BankId &&
            //////        entity.AccocunChartId == model.AccountChartId)
            //////};
            //////var existEntity = this._safeAccountChartsRepository.Get(condition).FirstOrDefault();

            //////if (existEntity != null)
            //////    throw new ItemAlreadyExistException();
        }

        public GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(ConditionFilter<SafeAccountChart, long> condition)
        {
            var entityCollection = this._safeAccountChartsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<SafeAccountChartLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }
        public GenericCollectionViewModel<SafeAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<SafeAccountChart, long> condition = new ConditionFilter<SafeAccountChart, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //    item.Language == lang)
            };
            var entityCollection = this._safeAccountChartsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<SafeAccountChartLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public GenericCollectionViewModel<SafeAccountChartViewModel> Get(ConditionFilter<SafeAccountChart, long> condition)
        {
            var entityCollection = this._safeAccountChartsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<SafeAccountChartViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<SafeAccountChartViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<SafeAccountChart, long> condition = new ConditionFilter<SafeAccountChart, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._safeAccountChartsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<SafeAccountChartViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public List<SafeAccountChartViewModel> Get(long safeId)
        {
            //return null;
            List<SafeAccountChart> bankAccountChart = _safeAccountChartsRepository.Get().Where(x => x.SafeId == safeId).ToList();
            return bankAccountChart.Select(e => e.ToModel()).ToList();
        }

        public List<AccountChartLightViewModel> GetAccountCharts(long safeId)
        {
            ConditionFilter<SafeAccountChart, long> condition = new ConditionFilter<SafeAccountChart, long>
            {
                Query = (item => item.SafeId == safeId)
            };
            var enity = this._safeAccountChartsRepository.Get(condition).Select(x => x.AccountChart).ToList();
            var result = enity.Select(x => x.ToLightModel()).ToList();
            foreach (var item in result)
            {
                item.DisplyedName = $"{item.DisplyedName}{enity.FirstOrDefault(x => x.Id == item.Id).ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
            }
            return result;
        }


        public SafeAccountChartViewModel Get(long safeId, long accountChartId)
        {
            // return null;
            return this._safeAccountChartsRepository.Get().FirstOrDefault(e => e.SafeId == safeId && e.AccountChartId == accountChartId).ToModel();
        }


        public IList<SafeAccountChartViewModel> Add(IEnumerable<SafeAccountChartViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._safeAccountChartsRepository.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public SafeAccountChartViewModel Add(SafeAccountChartViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._safeAccountChartsRepository.Add(entity);


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public IList<SafeAccountChartViewModel> Update(IEnumerable<SafeAccountChartViewModel> collection)
        {
            //IEnumerable<SafeAccountChartViewModel> bankAccountsDelete = collection.Where(x => x.ModelStatus == ModelStatus.Delete);
            //if (bankAccountsDelete != null && bankAccountsDelete.Count() > 0)
            //{
            //    foreach (var bankAccountDelete in bankAccountsDelete)
            //    {
            //        SafeAccountChart bankAccount = this._safeAccountChartsRepository.Get().FirstOrDefault(x => x.AccountChartId == bankAccountDelete.AccountChartId && x.BankId == bankAccountDelete.BankId);
            //        if (bankAccount != null)
            //            this._safeAccountChartsRepository.Delete(bankAccount);
            //    }
            //}
            //IEnumerable<SafeAccountChartViewModel> bankAccountsAdd = collection.Where(x => x.ModelStatus == ModelStatus.Add);
            //if (bankAccountsAdd != null && bankAccountsAdd.Count() > 0)
            //{
            //    foreach (var bankAccountAdd in bankAccountsAdd)
            //    {
            //        try
            //        {
            //            ThrowExceptionIfExist(bankAccountAdd);
            //            this._safeAccountChartsRepository.Add(bankAccountAdd.ToEntity());
            //        }
            //        catch (ItemAlreadyExistException)
            //        {
            //            continue;
            //        }
            //    }
            //}



            //var entityCollection = collection.Select(model => model.ToEntity());
            //var modelCollection = bankAccountsDelete.Union(bankAccountsAdd); //this._accountDocumentRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            //var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return null; //modelCollection.ToList();
        }

        public SafeAccountChartViewModel Update(SafeAccountChartViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._safeAccountChartsRepository.Update(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public void Delete(IEnumerable<SafeAccountChartViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._safeAccountChartsRepository.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(IEnumerable<long> collection)
        {
            this._safeAccountChartsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(SafeAccountChartViewModel model)
        {
            var entity = model.ToEntity();
            this._safeAccountChartsRepository.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(long id)
        {
            var result = this._safeAccountChartsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        #endregion
    }
}
