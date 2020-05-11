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
using MersalAccountingService.Common.Exceptions;
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
    /// Provides ClosedMonth service for 
    /// business functionality.
    /// </summary>
    public class ClosedMonthsService : IClosedMonthsService
    {
        #region Data Members
        private readonly IClosedMonthsRepository _ClosedMonthsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedMonthsService.
        /// </summary>
        /// <param name="ClosedMonthsRepository"></param>
        /// <param name="unitOfWork"></param>
        public ClosedMonthsService(
            IClosedMonthsRepository ClosedMonthsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._ClosedMonthsRepository = ClosedMonthsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">ClosedMonth view model</param>
        public void ThrowExceptionIfExist(ClosedMonthViewModel model)
        {
            //ConditionFilter<ClosedMonth, long> condition = new ConditionFilter<ClosedMonth, long>
            //{
            //    Query = (entity =>
            //        entity.Name == model.Name &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._ClosedMonthsRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException();
        }

        public void ValidateFromAndTo(ClosedMonthViewModel model)
        {
            if (model.From.Value.Month != model.To.Value.Month)
                throw new GeneralException((int)ErrorCodeEnum.FromMonthAndToMonthAreNotTheSame);

            if (model.From.Value.Day != 1)
                throw new GeneralException((int)ErrorCodeEnum.FromDateMustBeTheFirstDayInMonth);

            if (model.To.Value.IsLastDayInMonth() == false)
                throw new GeneralException((int)ErrorCodeEnum.ToDateMustBeTheLastDayInMonth);

            var latest = this._ClosedMonthsRepository.Get(null)
                .OrderByDescending(entity => entity.Id)
                .Where(x => x.ParentKeyClosedMonthId == null)
                .FirstOrDefault();

            bool exist = false;
            if (latest != null)
            {
                exist = (model.From.Value.Month == latest.Month.Value &&
                    model.From.Value.Year == latest.From.Value.Year);
            }

            if (exist == true)
            {
                throw new GeneralException((int)ErrorCodeEnum.ThisMonthHasBeenAddedBefore);
            }
        }

        public bool IsClosed(DateTime dateTime)
        {
            var result = false;

            var exist = this._ClosedMonthsRepository.Get(null).Where(x =>
                x.IsClosed == true &&
                x.Month == dateTime.Month &&
                x.From.Value.Year == dateTime.Year)
                .FirstOrDefault();

            result = (exist != null);

            return result;
        }

        public void ValidateIfMonthIsClosed(DateTime dateTime)
        {
            bool isClosed = this.IsClosed(dateTime);

            if (isClosed)
                throw new GeneralException((int)ErrorCodeEnum.ThisMonthIsClosed);
        }

        public GenericCollectionViewModel<ListClosedMonthsLightViewModel> GetByFilter(ClosedMonthsFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ClosedMonth, long> condition = new ConditionFilter<ClosedMonth, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.To.HasValue) model.To = model.To.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<ClosedMonth> queryableData = this._ClosedMonthsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyClosedMonth != null);

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (string.IsNullOrEmpty(model.Description) == false)
                queryableData = queryableData.Where(x => x.Description.Contains(model.Description));

            if (model.Month.HasValue)
                queryableData = queryableData.Where(x => x.Month == model.Month);

            if (model.From.HasValue)
                queryableData = queryableData.Where(x => x.From <= model.From);

            if (model.To.HasValue)
                queryableData = queryableData.Where(x => x.To >= model.To);

            if (model.IsClosed.HasValue)
                queryableData = queryableData.Where(x => x.IsClosed == model.IsClosed);

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
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListClosedMonthsLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ClosedMonthViewModel> Get(ConditionFilter<ClosedMonth, long> condition)
        {
            var entityCollection = this._ClosedMonthsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ClosedMonthViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ClosedMonthViewModel> Get(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ClosedMonth, long> condition = new ConditionFilter<ClosedMonth, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._ClosedMonthsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ClosedMonthViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(ConditionFilter<ClosedMonth, long> condition)
        {
            var entityCollection = this._ClosedMonthsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ClosedMonthLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ClosedMonth, long> condition = new ConditionFilter<ClosedMonth, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._ClosedMonthsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ClosedMonthLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a ClosedMonthViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClosedMonthViewModel Get(long id)
        {
            var entity = this._ClosedMonthsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<ClosedMonthViewModel> Add(IEnumerable<ClosedMonthViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ClosedMonthsRepository.Add(entityCollection).ToList();

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
        public ClosedMonthViewModel Add(ClosedMonthViewModel model)
        {
            //model.To = model.To.SetTimeToMax();
            //this.ThrowExceptionIfExist(model);
            this.ValidateFromAndTo(model);

            var entity = model.ToEntity();
            entity.Month = (byte)model.From.Value.Month;
            entity = this._ClosedMonthsRepository.Add(entity);

            var entityAr = new ClosedMonth
            {
                Id = entity.Id,
                Name = model.NameAr,
                Description = model.DescriptionAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedClosedMonths.Add(entityAr);
            this._ClosedMonthsRepository.Add(entityAr);

            var entityEn = new ClosedMonth
            {
                Id = entity.Id,
                Name = model.NameEn,
                Description = model.DescriptionEn,
                Language = Language.English
            };
            entity.ChildTranslatedClosedMonths.Add(entityEn);
            this._ClosedMonthsRepository.Add(entityEn);

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
        public IList<ClosedMonthViewModel> Update(IEnumerable<ClosedMonthViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ClosedMonthsRepository.Update(entityCollection).ToList();

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
        public ClosedMonthViewModel Update(ClosedMonthViewModel model)
        {
            //this.ThrowExceptionIfExist(model);
            //this.ValidateFromAndTo(model);

            // var entity = model.ToEntity();
            var entity = this._ClosedMonthsRepository.Get(model.Id);
            entity.IsClosed = model.IsClosed;
            entity = this._ClosedMonthsRepository.Update(entity);

            ConditionFilter<ClosedMonth, long> conditionFilter = new ConditionFilter<ClosedMonth, long>()
            {
                Query = (x =>
                        x.ParentKeyClosedMonthId == entity.Id)
            };
            var childs = this._ClosedMonthsRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._ClosedMonthsRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._ClosedMonthsRepository.Update(en);
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
        public void Delete(IEnumerable<ClosedMonthViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._ClosedMonthsRepository.Delete(entityCollection);

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
            this._ClosedMonthsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(ClosedMonthViewModel model)
        {
            var entity = model.ToEntity();
            this._ClosedMonthsRepository.Delete(entity);

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
            var result = this._ClosedMonthsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
