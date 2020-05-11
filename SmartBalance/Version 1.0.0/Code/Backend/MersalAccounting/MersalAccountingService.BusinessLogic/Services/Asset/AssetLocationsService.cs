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
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides AssetLocation service for 
    /// business functionality.
    /// </summary>
    public class AssetLocationsService : IAssetLocationsService
    {
        #region Data Members
        private readonly IAssetLocationsRepository _AssetLocationsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetLocationsService.
        /// </summary>
        /// <param name="AssetLocationsRepository"></param>
        /// <param name="unitOfWork"></param>
        public AssetLocationsService(
            IAssetLocationsRepository AssetLocationsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._AssetLocationsRepository = AssetLocationsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">AssetLocation view model</param>
        public void ThrowExceptionIfExist(AssetLocationViewModel model)
        {
            //ConditionFilter<AssetLocation, long> condition = new ConditionFilter<AssetLocation, long>
            //{
            //    Query = (entity =>
            //        entity.Code == model.Code &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._AssetLocationsRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public GenericCollectionViewModel<ListAssetLocationsLightViewModel> GetByFilter(AssetLocationsFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetLocation, long> condition = new ConditionFilter<AssetLocation, long>()
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
            IQueryable<AssetLocation> queryableData = this._AssetLocationsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyAssetLocation != null);
           
            if (model.AssetId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAssetLocation.AssetId == model.AssetId);

            if (model.LocationId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAssetLocation.LocationId == model.LocationId);

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();
            
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListAssetLocationsLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetLocationViewModel> Get(ConditionFilter<AssetLocation, long> condition)
        {
            var entityCollection = this._AssetLocationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetLocationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetLocationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetLocation, long> condition = new ConditionFilter<AssetLocation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._AssetLocationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetLocationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(ConditionFilter<AssetLocation, long> condition)
        {
            var entityCollection = this._AssetLocationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetLocationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetLocation, long> condition = new ConditionFilter<AssetLocation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._AssetLocationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetLocationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a AssetLocationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssetLocationViewModel Get(long id)
        {
            var entity = this._AssetLocationsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        ///// <summary>
        ///// Add entities.
        ///// </summary>
        ///// <param name="collection"></param>
        ///// <returns></returns>
        //public IList<AssetLocationViewModel> Add(IEnumerable<AssetLocationViewModel> collection)
        //{
        //    foreach (var model in collection)
        //    {
        //        this.ThrowExceptionIfExist(model);
        //    }

        //    var entityCollection = collection.Select(model => model.ToEntity());
        //    entityCollection = this._AssetLocationsRepository.Add(entityCollection).ToList();

        //    #region Commit Changes
        //    this._unitOfWork.Commit();
        //    #endregion

        //    var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
        //    return modelCollection;
        //}
        ///// <summary>
        ///// Add an entity.
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public AssetLocationViewModel Add(AssetLocationViewModel model)
        //{
        //    this.ThrowExceptionIfExist(model);

        //    var entity = model.ToEntity();
        //    entity = this._AssetLocationsRepository.Add(entity);

        //    var entityAr = new AssetLocation
        //    {
        //        Id = entity.Id,
        //        Description = model.DescriptionAr,
        //        Language = Framework.Common.Enums.Language.Arabic
        //    };
        //    entity.ChildTranslatedAssetLocations.Add(entityAr);
        //    this._AssetLocationsRepository.Add(entityAr);

        //    var entityEn = new AssetLocation
        //    {
        //        Id = entity.Id,
        //        Description = model.DescriptionEn,
        //        Language = Framework.Common.Enums.Language.English
        //    };
        //    entity.ChildTranslatedAssetLocations.Add(entityEn);
        //    this._AssetLocationsRepository.Add(entityEn);

        //    #region Commit Changes
        //    this._unitOfWork.Commit();
        //    #endregion

        //    model = entity.ToModel();
        //    return model;
        //}

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<AssetLocationViewModel> Update(IEnumerable<AssetLocationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._AssetLocationsRepository.Update(entityCollection).ToList();

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
        public AssetLocationViewModel Update(AssetLocationViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            // var entity = model.ToEntity();
            var entity = this._AssetLocationsRepository.Get(model.Id);

            if (entity.AssetId != model.AssetId)
            {
                entity = this._AssetLocationsRepository
                    .Get(null)
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.AssetId == model.AssetId)
                    .FirstOrDefault();
            }

            if (entity.LocationId != model.LocationId)
            {
                entity = new AssetLocation
                {
                    LocationId = model.LocationId,
                    AssetId = model.AssetId,
                    Date = DateTime.Now
                };

                entity = this._AssetLocationsRepository.Add(entity);

                var entityAr = new AssetLocation
                {
                    Id = entity.Id,
                    Description = model.DescriptionAr,
                    Language = Language.Arabic
                };
                entity.ChildTranslatedAssetLocations.Add(entityAr);
                this._AssetLocationsRepository.Add(entityAr);

                var entityEn = new AssetLocation
                {
                    Id = entity.Id,
                    Description = model.DescriptionEn,
                    Language = Language.English
                };
                entity.ChildTranslatedAssetLocations.Add(entityEn);
                this._AssetLocationsRepository.Add(entityEn);
            }
            else
            {
                entity = this._AssetLocationsRepository.Update(entity);
                ConditionFilter<AssetLocation, long> conditionFilter = new ConditionFilter<AssetLocation, long>()
                {
                    Query = (x =>
                            x.ParentKeyAssetLocationId == entity.Id)
                };
                var childs = this._AssetLocationsRepository.Get(conditionFilter);

                if (childs.Count() > 0)
                {
                    var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                    ar.Description = model.DescriptionAr;
                    this._AssetLocationsRepository.Update(ar);

                    var en = childs.FirstOrDefault(x => x.Language == Language.English);
                    en.Description = model.DescriptionEn;
                    this._AssetLocationsRepository.Update(en);
                }
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
        public void Delete(IEnumerable<AssetLocationViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._AssetLocationsRepository.Delete(entityCollection);

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
            this._AssetLocationsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(AssetLocationViewModel model)
        {
            var entity = model.ToEntity();
            this._AssetLocationsRepository.Delete(entity);

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
            var result = this._AssetLocationsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
