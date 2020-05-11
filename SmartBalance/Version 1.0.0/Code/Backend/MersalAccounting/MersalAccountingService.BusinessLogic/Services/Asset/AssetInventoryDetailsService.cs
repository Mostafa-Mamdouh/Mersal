#region Using ...
using Framework.Common.Exceptions;
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
    /// Provides AssetInventoryDetail service for 
    /// business functionality.
    /// </summary>
    public class AssetInventoryDetailsService : IAssetInventoryDetailsService
    {
        #region Data Members
        private readonly IAssetInventoryDetailsRepository _AssetInventoryDetailsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetInventoryDetailsService.
        /// </summary>
        /// <param name="AssetInventoryDetailsRepository"></param>
        /// <param name="unitOfWork"></param>
        public AssetInventoryDetailsService(
            IAssetInventoryDetailsRepository AssetInventoryDetailsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._AssetInventoryDetailsRepository = AssetInventoryDetailsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">AssetInventoryDetail view model</param>
        public void ThrowExceptionIfExist(AssetInventoryDetailViewModel model)
        {
            //ConditionFilter<AssetInventoryDetail, long> condition = new ConditionFilter<AssetInventoryDetail, long>
            //{
            //    Query = (entity =>
            //        entity.Name == model.Name &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._AssetInventoryDetailsRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryDetailViewModel> Get(ConditionFilter<AssetInventoryDetail, long> condition)
        {
            var entityCollection = this._AssetInventoryDetailsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryDetailViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryDetailViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetInventoryDetail, long> condition = new ConditionFilter<AssetInventoryDetail, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //    item.Language == lang)
            };
            var entityCollection = this._AssetInventoryDetailsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryDetailViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryDetailLightViewModel> GetLightModel(ConditionFilter<AssetInventoryDetail, long> condition)
        {
            var entityCollection = this._AssetInventoryDetailsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryDetailLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetInventoryDetailViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<AssetInventoryDetailLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<AssetInventoryDetail, long> condition = new ConditionFilter<AssetInventoryDetail, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //    item.Language == lang)
            };
            var entityCollection = this._AssetInventoryDetailsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<AssetInventoryDetailLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a AssetInventoryDetailViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssetInventoryDetailViewModel Get(long id)
        {
            var entity = this._AssetInventoryDetailsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<AssetInventoryDetailViewModel> Add(IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._AssetInventoryDetailsRepository.Add(entityCollection).ToList();

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
        public AssetInventoryDetailViewModel Add(AssetInventoryDetailViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._AssetInventoryDetailsRepository.Add(entity);

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
        public IList<AssetInventoryDetailViewModel> Update(IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._AssetInventoryDetailsRepository.Update(entityCollection).ToList();

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
        public AssetInventoryDetailViewModel Update(AssetInventoryDetailViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._AssetInventoryDetailsRepository.Update(entity);

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
        public void Delete(IEnumerable<AssetInventoryDetailViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._AssetInventoryDetailsRepository.Delete(entityCollection);

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
            this._AssetInventoryDetailsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(AssetInventoryDetailViewModel model)
        {
            var entity = model.ToEntity();
            this._AssetInventoryDetailsRepository.Delete(entity);

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
            var result = this._AssetInventoryDetailsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
