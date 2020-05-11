#region Using ...
using DocumentFormat.OpenXml.Drawing.Charts;
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
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
    /// <summary>
    /// Provides CurrencyRate service for 
    /// business functionality.
    /// </summary>
    public class CurrencyRatesService : ICurrencyRatesService
    {
        #region Data Members
        private readonly ICurrencyRatesRepository _CurrencyRatesRepository;
        private readonly ICurrencysRepository _currencysRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CurrencyRatesService.
        /// </summary>
        /// <param name="CurrencyRatesRepository"></param>
        /// <param name="unitOfWork"></param>
        public CurrencyRatesService(
            ICurrencyRatesRepository CurrencyRatesRepository,
             ICurrencysRepository currencysRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._CurrencyRatesRepository = CurrencyRatesRepository;
            this._currencysRepository = currencysRepository;

            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public CurrencyRateLightViewModel GetLatestCurrencyRate(long? currencyId, long? exchangeCurrencyId)
        {
            CurrencyRateLightViewModel result = null;
            var lates = this._CurrencyRatesRepository.Get(null)
                .OrderByDescending(x => x.Date)
                .Where(x => x.CurrencyId == currencyId &&
                            x.ExchangeCurrencyId == exchangeCurrencyId)
                .FirstOrDefault();

            if (lates != null)
            {
                result = lates.ToLightModel();
            }

            return result;
        }

        /// <summary>
        /// For posting
        /// </summary>
        /// <param name="origenalAmount"></param>
        /// <param name="currency"></param>
        /// <param name="systemCurrency"></param>
        /// <returns></returns>
        public LatestCurrencyRate GetLatestCurrencyRate(decimal origenalAmount, Currency currency,
            SystemCurrencySettingViewModel systemCurrency)
        {
            LatestCurrencyRate latestCurrencyRate = new LatestCurrencyRate
            {
                NewAmount = origenalAmount
            };
            if (currency.Id != systemCurrency.CurrencyId)
            {
                var lates = this._CurrencyRatesRepository.Get(null)
                    .OrderByDescending(x => x.Date)
                    .Where(x => x.CurrencyId == currency.Id &&
                                x.ExchangeCurrencyId == systemCurrency.CurrencyId)
                //.ToList();
                .FirstOrDefault();

                //CurrencyRate lates = null;
                //if (latesList != null) lates = latesList.FirstOrDefault();

                if (lates != null)
                {
                    latestCurrencyRate.NewAmount = origenalAmount * lates.Price;
                }

                var sysCurrency = this._currencysRepository.Get(systemCurrency.CurrencyId.Value);

                if (currency != null && lates != null && sysCurrency != null)
                {
                    latestCurrencyRate.AppendedDescriptionAr = $" [1 {currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic)?.Name} = {lates.Price} {sysCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic)?.Name}]";
                    latestCurrencyRate.AppendedDescriptionEn = $" [1 {currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.English)?.Name} = {lates.Price} {sysCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.English)?.Name}]";
                }
            }

            return latestCurrencyRate;
        }



        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">CurrencyRate view model</param>
        public void ThrowExceptionIfExist(CurrencyRateViewModel model)
        {
            //ConditionFilter<CurrencyRate, long> condition = new ConditionFilter<CurrencyRate, long>
            //{
            //	Query = (entity =>
            //		entity.Name == model.Name &&
            //		entity.Id != model.Id)
            //};
            //var existEntity = this._CurrencyRatesRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //	throw new ItemAlreadyExistException();
        }

        public GenericCollectionViewModel<ListCurrencyRateLightViewModel> GetByFilter(CurrencyRateFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<CurrencyRate, long> condition = new ConditionFilter<CurrencyRate, long>()
            {
                Order = Framework.Common.Enums.Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Framework.Common.Enums.Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<CurrencyRate> queryableData = this._CurrencyRatesRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyCurrencyRate != null);
            queryableData = queryableData.Where(x => x.ParentKeyCurrencyRate == null);

            if (model.Currency.HasValue)
                queryableData = queryableData.Where(x => x.CurrencyId == model.Currency);

            if (model.ExchangeCurrency.HasValue)
                queryableData = queryableData.Where(x => x.ExchangeCurrencyId == model.ExchangeCurrency);

            if (model.PriceFrom.HasValue)
                queryableData = queryableData.Where(x => x.Price >= model.PriceFrom);

            if (model.PriceTo.HasValue)
                queryableData = queryableData.Where(x => x.Price <= model.PriceTo);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.Id);

                ViewModel.Currency = item.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;

                ViewModel.ExchangeCurrency = item.ExchangeCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;

                //if (item.ParentKeyBank != null)
                //{
                //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                //}              
            }
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
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListCurrencyRateLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CurrencyRateViewModel> Get(ConditionFilter<CurrencyRate, long> condition)
        {
            var entityCollection = this._CurrencyRatesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<CurrencyRateViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CurrencyRateViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<CurrencyRate, long> condition = new ConditionFilter<CurrencyRate, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._CurrencyRatesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<CurrencyRateViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(ConditionFilter<CurrencyRate, long> condition)
        {
            var entityCollection = this._CurrencyRatesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<CurrencyRateLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyRateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CurrencyRateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<CurrencyRate, long> condition = new ConditionFilter<CurrencyRate, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._CurrencyRatesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<CurrencyRateLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a CurrencyRateViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CurrencyRateViewModel Get(long id)
        {
            var entity = this._CurrencyRatesRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<CurrencyRateViewModel> Add(IEnumerable<CurrencyRateViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._CurrencyRatesRepository.Add(entityCollection).ToList();

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
        public CurrencyRateViewModel Add(CurrencyRateViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._CurrencyRatesRepository.Add(entity);

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
        public IList<CurrencyRateViewModel> Update(IEnumerable<CurrencyRateViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._CurrencyRatesRepository.Update(entityCollection).ToList();

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
        public CurrencyRateViewModel Update(CurrencyRateViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._CurrencyRatesRepository.Update(entity);

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
        public void Delete(IEnumerable<CurrencyRateViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._CurrencyRatesRepository.Delete(entityCollection);

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
            this._CurrencyRatesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(CurrencyRateViewModel model)
        {
            var entity = model.ToEntity();
            this._CurrencyRatesRepository.Delete(entity);

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
            var result = this._CurrencyRatesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
