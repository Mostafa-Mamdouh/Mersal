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
    /// Provides ExpensesType service for 
    /// business functionality.
    /// </summary>
    public class ExpensesTypesService : IExpensesTypesService
    {
        #region Data Members
        private readonly IExpensesTypesRepository _ExpensesTypesRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpensesTypesService.
        /// </summary>
        /// <param name="ExpensesTypesRepository"></param>
        /// <param name="unitOfWork"></param>
        public ExpensesTypesService(
            IExpensesTypesRepository ExpensesTypesRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._ExpensesTypesRepository = ExpensesTypesRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">ExpensesType view model</param>
        public void ThrowExceptionIfExist(ExpensesTypeViewModel model)
        {
            ConditionFilter<ExpensesType, long> condition = new ConditionFilter<ExpensesType, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._ExpensesTypesRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public GenericCollectionViewModel<ListExpensesTypesLightViewModel> GetByFilter(ExpensesTypesFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ExpensesType, long> condition = new ConditionFilter<ExpensesType, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<ExpensesType> queryableData = this._ExpensesTypesRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyExpensesType != null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyExpensesType.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));


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
            var result = new GenericCollectionViewModel<ListExpensesTypesLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpensesTypeViewModel> Get(ConditionFilter<ExpensesType, long> condition)
        {
            var entityCollection = this._ExpensesTypesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExpensesTypeViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpensesTypeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ExpensesType, long> condition = new ConditionFilter<ExpensesType, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._ExpensesTypesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExpensesTypeViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpensesTypeLightViewModel> GetLightModel(ConditionFilter<ExpensesType, long> condition)
        {
            var entityCollection = this._ExpensesTypesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExpensesTypeLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpensesTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpensesTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ExpensesType, long> condition = new ConditionFilter<ExpensesType, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._ExpensesTypesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExpensesTypeLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a ExpensesTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExpensesTypeViewModel Get(long id)
        {
            var entity = this._ExpensesTypesRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<ExpensesTypeViewModel> Add(IEnumerable<ExpensesTypeViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExpensesTypesRepository.Add(entityCollection).ToList();

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
        public ExpensesTypeViewModel Add(ExpensesTypeViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._ExpensesTypesRepository.Add(entity);

            var entityAr = new ExpensesType
            {
                Id = entity.Id,
                Name = model.NameAr,
                Description = model.DescriptionAr,
                Language = Framework.Common.Enums.Language.Arabic
            };
            entity.ChildTranslatedExpensesTypes.Add(entityAr);
            this._ExpensesTypesRepository.Add(entityAr);

            var entityEn = new ExpensesType
            {
                Id = entity.Id,
                Name = model.NameEn,
                Description = model.DescriptionEn,
                Language = Framework.Common.Enums.Language.English
            };
            entity.ChildTranslatedExpensesTypes.Add(entityEn);
            this._ExpensesTypesRepository.Add(entityEn);

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
        public IList<ExpensesTypeViewModel> Update(IEnumerable<ExpensesTypeViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExpensesTypesRepository.Update(entityCollection).ToList();

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
        public ExpensesTypeViewModel Update(ExpensesTypeViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            // var entity = model.ToEntity();
            var entity = this._ExpensesTypesRepository.Get(model.Id);
            entity.Code = model.Code;
            entity = this._ExpensesTypesRepository.Update(entity);

            ConditionFilter<ExpensesType, long> conditionFilter = new ConditionFilter<ExpensesType, long>()
            {
                Query = (x =>
                        x.ParentKeyExpensesTypeId == entity.Id)
            };
            var childs = this._ExpensesTypesRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._ExpensesTypesRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._ExpensesTypesRepository.Update(en);
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
        public void Delete(IEnumerable<ExpensesTypeViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._ExpensesTypesRepository.Delete(entityCollection);

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
            this._ExpensesTypesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(ExpensesTypeViewModel model)
        {
            var entity = model.ToEntity();
            this._ExpensesTypesRepository.Delete(entity);

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
            var result = this._ExpensesTypesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
