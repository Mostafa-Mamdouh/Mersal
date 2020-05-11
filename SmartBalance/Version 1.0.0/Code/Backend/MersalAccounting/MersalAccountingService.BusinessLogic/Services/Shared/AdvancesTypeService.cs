using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.BusinessLogic.Services
{
    public class AdvancesTypeService : IAdvancesTypeService
    {

    #region Data Members
    private readonly IAdvancesTypeRepository _AdvancesTypesRepository;
    private readonly ILanguageService _languageService;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of 
    /// type AdvancesTypesService.
    /// </summary>
    /// <param name="AdvancesTypesRepository"></param>
    /// <param name="unitOfWork"></param>
    public AdvancesTypeService(
        IAdvancesTypeRepository AdvancesTypesRepository,
        ILanguageService languageService,
        IUnitOfWork unitOfWork)
    {
        this._AdvancesTypesRepository = AdvancesTypesRepository;
        this._languageService = languageService;
        this._unitOfWork = unitOfWork;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Throw an exception if name is exist.
    /// </summary>
    /// <param name="model">AdvancesType view model</param>
    public void ThrowExceptionIfExist(AdvancesTypeViewModel model)
    {
        ConditionFilter<AdvancesType, int> condition = new ConditionFilter<AdvancesType, int>
        {
            Query = (entity =>
                entity.ParentKeyAdvancesTypeId != null &&
                entity.ParentKeyAdvancesTypeId != model.Id &&
                entity.Id != model.Id)
        };
        var existEntity = this._AdvancesTypesRepository.Get(condition).FirstOrDefault();

        if (existEntity != null)
            throw new ItemAlreadyExistException();
    }

    //public GenericCollectionViewModel<ListAdvancesTypesLightViewModel> GetByFilter(AdvancesTypeFilterViewModel model)
    //{
    //    var lang = this._languageService.CurrentLanguage;
    //    ConditionFilter<AdvancesType, int> condition = new ConditionFilter<AdvancesType, int>()
    //    {
    //        Order = Order.Descending
    //    };

    //    if (model.Sort?.Count > 0)
    //    {
    //        if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
    //    }

    //    //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
    //    //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

    //    // The IQueryable data to query.  
    //    IQueryable<AdvancesType> queryableData = this._AdvancesTypesRepository.Get(condition);

    //    queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyAdvancesType != null);

    //    if (string.IsNullOrEmpty(model.Name) == false)
    //        queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

    //    var entityCollection = queryableData.ToList();
    //    var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

    //    //foreach (var item in entityCollection)
    //    //{
    //    //	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBrandId);
    //    //	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
    //    //	//if (item.ParentKeyBankMovement.Bank != null)
    //    //	//{
    //    //	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
    //    //	//}
    //    //	//if (item.ParentKeyBankMovement.JournalType != null)
    //    //	//{
    //    //	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
    //    //	//}
    //    //}

    //    var total = dtoCollection.Count();
    //    dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
    //    var result = new GenericCollectionViewModel<ListDiscountPercentegesLightViewModel>
    //    {
    //        Collection = dtoCollection,
    //        TotalCount = total,
    //        PageIndex = model.PageIndex,
    //        PageSize = model.PageSize
    //    };

    //    return result;
    //}

    /// <summary>
    /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by condition.
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public GenericCollectionViewModel<AdvancesTypeViewModel> Get(ConditionFilter<AdvancesType, int> condition)
    {
        var entityCollection = this._AdvancesTypesRepository.Get(condition).ToList();
        var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
        var result = new GenericCollectionViewModel<AdvancesTypeViewModel>
        {
            Collection = modelCollection,
            TotalCount = modelCollection.Count,
            PageIndex = condition.PageIndex,
            PageSize = condition.PageSize
        };

        return result;
    }

    /// <summary>
    /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by pagination.
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public GenericCollectionViewModel<AdvancesTypeViewModel> Get(int? pageIndex, int? pageSize)
    {
        var lang = this._languageService.CurrentLanguage;
        ConditionFilter<AdvancesType, int> condition = new ConditionFilter<AdvancesType, int>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Query = (item =>
                item.Language == lang)
        };
        var entityCollection = this._AdvancesTypesRepository.Get(condition).ToList();
        var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
        var result = new GenericCollectionViewModel<AdvancesTypeViewModel>
        {
            Collection = modelCollection,
            TotalCount = modelCollection.Count,
            PageIndex = pageIndex,
            PageSize = pageSize
        };

        return result;
    }

    /// <summary>
    /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by condition.
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public GenericCollectionViewModel<AdvancesTypeLightViewModel> GetLightModel(ConditionFilter<AdvancesType, int> condition)
    {
        var entityCollection = this._AdvancesTypesRepository.Get(condition).ToList();
        var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        var result = new GenericCollectionViewModel<AdvancesTypeLightViewModel>
        {
            Collection = dtoCollection,
            TotalCount = dtoCollection.Count,
            PageIndex = condition.PageIndex,
            PageSize = condition.PageSize
        };

        return result;
    }

    /// <summary>
    /// Gets a GenericCollectionViewModel of AdvancesTypeViewModel by pagination.
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public GenericCollectionViewModel<AdvancesTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
    {
        var lang = this._languageService.CurrentLanguage;
        ConditionFilter<AdvancesType, int> condition = new ConditionFilter<AdvancesType, int>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Query = (item =>
                item.Language == lang)
        };
        var entityCollection = this._AdvancesTypesRepository.Get(condition).ToList();
        var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        var result = new GenericCollectionViewModel<AdvancesTypeLightViewModel>
        {
            Collection = dtoCollection,
            TotalCount = dtoCollection.Count,
            PageIndex = pageIndex,
            PageSize = pageSize
        };

        return result;
    }

    /// <summary>
    /// Gets a AdvancesTypeViewModel by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public AdvancesTypeViewModel Get(int id)
    {
        Language lang = this._languageService.CurrentLanguage;
        var entity = this._AdvancesTypesRepository.Get(id);
        entity.Name = entity.ChildTranslatedAdvancesTypes.FirstOrDefault(x => x.Language == lang).Name;

        var model = entity.ToModel();

        return model;
    }

    /// <summary>
    /// Add entities.
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public IList<AdvancesTypeViewModel> Add(IEnumerable<AdvancesTypeViewModel> collection)
    {
        foreach (var model in collection)
        {
            this.ThrowExceptionIfExist(model);
        }

        var entityCollection = collection.Select(model => model.ToEntity());
        entityCollection = this._AdvancesTypesRepository.Add(entityCollection).ToList();

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
    public AdvancesTypeViewModel Add(AdvancesTypeViewModel model)
    {
        this.ThrowExceptionIfExist(model);

        var entity = model.ToEntity();

        entity = this._AdvancesTypesRepository.Add(entity);

        var entityAr = new AdvancesType
        {
            Name = model.NameAr,
            Language = Framework.Common.Enums.Language.Arabic,
            ParentKeyAdvancesTypes = entity
        };
        entity.ChildTranslatedAdvancesTypes.Add(entityAr);
        this._AdvancesTypesRepository.Add(entityAr);

        var entityEn = new AdvancesType
        {
            Name = model.NameEn,
            Language = Framework.Common.Enums.Language.English,
            ParentKeyAdvancesTypes = entity
        };
        entity.ChildTranslatedAdvancesTypes.Add(entityEn);
        this._AdvancesTypesRepository.Add(entityEn);


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
    public IList<AdvancesTypeViewModel> Update(IEnumerable<AdvancesTypeViewModel> collection)
    {
        foreach (var model in collection)
        {
            this.ThrowExceptionIfExist(model);
        }

        var entityCollection = collection.Select(model => model.ToEntity());
        entityCollection = this._AdvancesTypesRepository.Update(entityCollection).ToList();

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
    public AdvancesTypeViewModel Update(AdvancesTypeViewModel model)
    {
        //this.ThrowExceptionIfExist(model);

        var entity = this._AdvancesTypesRepository.Get(model.Id.Value);

        entity = this._AdvancesTypesRepository.Update(entity);

        var entityAr = entity.ChildTranslatedAdvancesTypes.FirstOrDefault(x => x.Language == Language.Arabic);

        entityAr.Name = model.NameAr;

        this._AdvancesTypesRepository.Update(entityAr);

        var entityEn = entity.ChildTranslatedAdvancesTypes.FirstOrDefault(x => x.Language == Language.English);

        entityEn.Name = model.NameEn;

        this._AdvancesTypesRepository.Update(entityEn);

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
    public void Delete(IEnumerable<AdvancesTypeViewModel> collection)
    {
        var entityCollection = collection.Select(model => model.ToEntity());
        this._AdvancesTypesRepository.Delete(entityCollection);

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
        this._AdvancesTypesRepository.Delete(collection);

        #region Commit Changes
        this._unitOfWork.Commit();
        #endregion
    }
    /// <summary>
    /// Delete an entity.
    /// </summary>
    /// <param name="model"></param>
    public void Delete(AdvancesTypeViewModel model)
    {
        var entity = model.ToEntity();
        this._AdvancesTypesRepository.Delete(entity);

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
        var result = this._AdvancesTypesRepository.Delete(id);

        if (result == 0)
            throw new ItemNotFoundException();

        #region Commit Changes
        this._unitOfWork.Commit();
        #endregion
    }
        #endregion
    }
}
