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
    /// Provides AssetInventory service for 
    /// business functionality.
    /// </summary>
    public class AssetInventorysService : IAssetInventorysService
    {
        #region Data Members
        private readonly IAssetInventorysRepository _AssetInventorysRepository;
        private readonly IAssetInventoryDetailsRepository _AssetInventoryDetailsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventorysService.
        /// </summary>
        /// <param name="AssetInventorysRepository"></param>
        /// <param name="unitOfWork"></param>
        public AssetInventorysService(
            IAssetInventorysRepository AssetInventorysRepository,
            IAssetInventoryDetailsRepository AssetInventoryDetailsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._AssetInventorysRepository = AssetInventorysRepository;
            this._AssetInventoryDetailsRepository = AssetInventoryDetailsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">AssetInventory view model</param>
        public void ThrowExceptionIfExist(AssetInventoryViewModel model)
        {
            //ConditionFilter<AssetInventory, long> condition = new ConditionFilter<AssetInventory, long>
            //{
            //    Query = (entity =>
            //        entity.Name == model.Name &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._AssetInventorysRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryViewModel> Get(ConditionFilter<AssetInventory, long> condition)
        {
            var entityCollection = this._AssetInventorysRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetInventory, long> condition = new ConditionFilter<AssetInventory, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._AssetInventorysRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryLightViewModel> GetLightModel(ConditionFilter<AssetInventory, long> condition)
        {
            var entityCollection = this._AssetInventorysRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetInventory, long> condition = new ConditionFilter<AssetInventory, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._AssetInventorysRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a AssetInventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssetInventoryViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._AssetInventorysRepository.Get(id);
            
            var model = entity.ToModel();
            string locationName = "";
            if (lang == Language.Arabic)
                locationName = model.Location.TitleAr;
            else if (lang == Language.English)
                locationName = model.Location.TitleEn;
            model.LocationName = $"{model.Location.Code}-{locationName}";
            foreach (var item in model.AssetInventoryDetails)
            {
                BrandViewModel brand = item.Brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang);
                string name = string.Empty;
                if(lang == Language.Arabic)
                {
                    name = brand.NameAr;
                }
                else if(lang == Language.English)
                {
                    name = brand.NameEn;
                }
                item.Brand.DisplyedName = $"{brand.ParentKeyBrand.Code} - {name}";
            }
            return model;
        }

        public GenericCollectionViewModel<ListAssetInventorysLightViewModel> GetByFilter(AssetInventoryFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetInventory, long> condition = new ConditionFilter<AssetInventory, long>()
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
            IQueryable<AssetInventory> queryableData = this._AssetInventorysRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyAssetInventory != null);
            //queryableData = queryableData.Where(x => x.ParentKeyInventoryId == null);
           
            if (model.LocationId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAssetInventory.LocationId >= model.LocationId);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAssetInventory.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAssetInventory.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyInventoryId);

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
            var result = new GenericCollectionViewModel<ListAssetInventorysLightViewModel>
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
        public IList<AssetInventoryViewModel> Add(IEnumerable<AssetInventoryViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._AssetInventorysRepository.Add(entityCollection).ToList();

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
        public AssetInventoryViewModel Add(AssetInventoryViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._AssetInventorysRepository.Add(entity);

            var entityEn = new AssetInventory
            {
                Language = Language.English,
                Description = model.DescriptionEn,
            };
            entity.ChildTranslatedAssetInventorys.Add(entityEn);
            this._AssetInventorysRepository.Add(entityEn);

            var entityAr = new AssetInventory
            {
                Language = Language.Arabic,
                Description = model.DescriptionAr
            };
            entity.ChildTranslatedAssetInventorys.Add(entityAr);
            this._AssetInventorysRepository.Add(entityAr);

            var details = entity.AssetInventoryDetails;
            this._AssetInventoryDetailsRepository.Add(details);

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
        public IList<AssetInventoryViewModel> Update(IEnumerable<AssetInventoryViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._AssetInventorysRepository.Update(entityCollection).ToList();

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
        public AssetInventoryViewModel Update(AssetInventoryViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._AssetInventorysRepository.Update(entity);

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
        public void Delete(IEnumerable<AssetInventoryViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._AssetInventorysRepository.Delete(entityCollection);

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
            this._AssetInventorysRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(AssetInventoryViewModel model)
        {
            var entity = model.ToEntity();
            this._AssetInventorysRepository.Delete(entity);

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
            var result = this._AssetInventorysRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
