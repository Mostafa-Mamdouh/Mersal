#region Using ...
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
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides UserMenuItem service for 
    /// business functionality.
    /// </summary>
    public class UserMenuItemsService : IUserMenuItemsService
    {
        #region Data Members
        private readonly IUserMenuItemsRepository _UserMenuItemsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserMenuItemsService.
        /// </summary>
        /// <param name="UserMenuItemsRepository"></param>
        /// <param name="unitOfWork"></param>
        public UserMenuItemsService(
            IUserMenuItemsRepository UserMenuItemsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._UserMenuItemsRepository = UserMenuItemsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserMenuItemViewModel> Get(ConditionFilter<UserMenuItem, long> condition)
        {
            var entityCollection = this._UserMenuItemsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserMenuItemViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserMenuItemViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<UserMenuItem, long> condition = new ConditionFilter<UserMenuItem, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._UserMenuItemsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserMenuItemViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserMenuItemLightViewModel> GetLightModel(ConditionFilter<UserMenuItem, long> condition)
        {
            var entityCollection = this._UserMenuItemsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserMenuItemLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserMenuItemLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            ConditionFilter<UserMenuItem, long> condition = new ConditionFilter<UserMenuItem, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._UserMenuItemsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserMenuItemLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a UserMenuItemViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserMenuItemViewModel Get(long id)
        {
            var entity = this._UserMenuItemsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<UserMenuItemViewModel> Add(IEnumerable<UserMenuItemViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._UserMenuItemsRepository.Add(entityCollection).ToList();

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
        public UserMenuItemViewModel Add(UserMenuItemViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._UserMenuItemsRepository.Add(entity);

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
        public IList<UserMenuItemViewModel> Update(IEnumerable<UserMenuItemViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._UserMenuItemsRepository.Update(entityCollection).ToList();

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
        public UserMenuItemViewModel Update(UserMenuItemViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._UserMenuItemsRepository.Update(entity);

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
        public void Delete(IEnumerable<UserMenuItemViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._UserMenuItemsRepository.Delete(entityCollection);

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
            this._UserMenuItemsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(UserMenuItemViewModel model)
        {
            var entity = model.ToEntity();
            this._UserMenuItemsRepository.Delete(entity);

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
            var result = this._UserMenuItemsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
