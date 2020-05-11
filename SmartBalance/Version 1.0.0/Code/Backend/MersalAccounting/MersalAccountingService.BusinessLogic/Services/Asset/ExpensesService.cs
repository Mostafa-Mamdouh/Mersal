#region Using ...
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
    /// Provides Expense service for 
    /// business functionality.
    /// </summary>
    public class ExpensesService : IExpensesService
    {
        #region Data Members
        private readonly IExpensesRepository _ExpensesRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpensesService.
        /// </summary>
        /// <param name="ExpensesRepository"></param>
        /// <param name="unitOfWork"></param>
        public ExpensesService(
            IExpensesRepository ExpensesRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._ExpensesRepository = ExpensesRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Expense view model</param>
        public void ThrowExceptionIfExist(ExpenseViewModel model)
        {
            //ConditionFilter<Expense, long> condition = new ConditionFilter<Expense, long>
            //{
            //	Query = (entity =>
            //		entity.Name == model.Name &&
            //		entity.Id != model.Id)
            //};
            //var existEntity = this._ExpensesRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //	throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpenseViewModel> Get(ConditionFilter<Expense, long> condition)
        {
            var entityCollection = this._ExpensesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExpenseViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpenseViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Expense, long> condition = new ConditionFilter<Expense, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._ExpensesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExpenseViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(ConditionFilter<Expense, long> condition)
        {
            var entityCollection = this._ExpensesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExpenseLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Expense, long> condition = new ConditionFilter<Expense, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._ExpensesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExpenseLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a ExpenseViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExpenseViewModel Get(long id)
        {
            var entity = this._ExpensesRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }


        public GenericCollectionViewModel<ListExpenseLightViewModel> GetByFilter(ExpenseFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Expense, long> condition = new ConditionFilter<Expense, long>()
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
            IQueryable<Expense> queryableData = this._ExpensesRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyExpense != null);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.Date <= model.DateTo);


            if (model.AmountFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.Amount >= model.AmountFrom);

            if (model.AmountTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.Amount <= model.AmountTo);


            if (model.AccountChartId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.AccountChartId == model.AccountChartId);

            if (model.ExpensesTypeId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.ExpensesTypeId == model.ExpensesTypeId);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyExpense.Code.Contains(model.Code));           
           

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyExpenseId);

            //    //if (item.ParentKeyExpense != null)
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
            var result = new GenericCollectionViewModel<ListExpenseLightViewModel>
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
        public IList<ExpenseViewModel> Add(IEnumerable<ExpenseViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExpensesRepository.Add(entityCollection).ToList();

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
        public ExpenseViewModel Add(ExpenseViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._ExpensesRepository.Add(entity);

            var entityAr = new Expense
            {
                Id = entity.Id,
                Description = model.DescriptionAr,
                //Name = model.NameAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedExpenses.Add(entityAr);
            this._ExpensesRepository.Add(entityAr);

            var entityEn = new Expense
            {
                Id = entity.Id,
                Description = model.DescriptionEn,
                //Name = model.NameEn,
                Language = Language.English
            };
            entity.ChildTranslatedExpenses.Add(entityEn);
            this._ExpensesRepository.Add(entityEn);

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
        public IList<ExpenseViewModel> Update(IEnumerable<ExpenseViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExpensesRepository.Update(entityCollection).ToList();

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
        public ExpenseViewModel Update(ExpenseViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = this._ExpensesRepository.Get(model.Id);

            entity.ExpensesTypeId = model.ExpensesTypeId;
            //entity.AccountChartId = model.AccountChartId;
            //entity.Amount = model.Amount;

            entity = this._ExpensesRepository.Update(entity);

            ConditionFilter<Expense, long> conditionFilter = new ConditionFilter<Expense, long>()
            {
                Query = (x =>
                        x.ParentKeyExpenseId == entity.Id)
            };
            var childs = this._ExpensesRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                //ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._ExpensesRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                //en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._ExpensesRepository.Update(en);
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
        public void Delete(IEnumerable<ExpenseViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._ExpensesRepository.Delete(entityCollection);

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
            this._ExpensesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(ExpenseViewModel model)
        {
            var entity = model.ToEntity();
            this._ExpensesRepository.Delete(entity);

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
            var result = this._ExpensesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
