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
    /// Provides StoreMovement service for 
    /// business functionality.
    /// </summary>
    public class StoreMovementsService : IStoreMovementsService
    {
        #region Data Members
        private readonly IStoreMovementsRepository _StoreMovementsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type StoreMovementsService.
        /// </summary>
        /// <param name="StoreMovementsRepository"></param>
        /// <param name="unitOfWork"></param>
        public StoreMovementsService(
            IStoreMovementsRepository StoreMovementsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._StoreMovementsRepository = StoreMovementsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">StoreMovement view model</param>
        public void ThrowExceptionIfExist(StoreMovementViewModel model)
        {
            ConditionFilter<StoreMovement, long> condition = new ConditionFilter<StoreMovement, long>
            {
                Query = (entity =>
                    entity.Name == model.Name &&
                    entity.Id != model.Id)
            };
            var existEntity = this._StoreMovementsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<StoreMovementViewModel> Get(ConditionFilter<StoreMovement, long> condition)
        {
            var entityCollection = this._StoreMovementsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<StoreMovementViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<StoreMovementViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<StoreMovement, long> condition = new ConditionFilter<StoreMovement, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._StoreMovementsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<StoreMovementViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<StoreMovementLightViewModel> GetLightModel(ConditionFilter<StoreMovement, long> condition)
        {
            var entityCollection = this._StoreMovementsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<StoreMovementLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of StoreMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<StoreMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<StoreMovement, long> condition = new ConditionFilter<StoreMovement, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._StoreMovementsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<StoreMovementLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a StoreMovementViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StoreMovementViewModel Get(long id)
        {
            var entity = this._StoreMovementsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<StoreMovementViewModel> Add(IEnumerable<StoreMovementViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._StoreMovementsRepository.Add(entityCollection).ToList();

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
        public StoreMovementViewModel Add(StoreMovementViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._StoreMovementsRepository.Add(entity);

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
        public IList<StoreMovementViewModel> Update(IEnumerable<StoreMovementViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._StoreMovementsRepository.Update(entityCollection).ToList();

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
        public StoreMovementViewModel Update(StoreMovementViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._StoreMovementsRepository.Update(entity);

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
        public void Delete(IEnumerable<StoreMovementViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._StoreMovementsRepository.Delete(entityCollection);

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
            this._StoreMovementsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(StoreMovementViewModel model)
        {
            var entity = model.ToEntity();
            this._StoreMovementsRepository.Delete(entity);

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
            var result = this._StoreMovementsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}

