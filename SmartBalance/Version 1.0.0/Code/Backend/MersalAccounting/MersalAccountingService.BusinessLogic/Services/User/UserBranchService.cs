#region User ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class UserBranchsService : IUserBranchsService
    {
        #region Data Members
        private readonly IUserBranchsRepository _userBranchsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public UserBranchsService(
            IUserBranchsRepository userBranchsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork
            )
        {
            this._userBranchsRepository = userBranchsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserBranchViewModel> Get(ConditionFilter<UserBranch, long> condition)
        {
            var entityCollection = this._userBranchsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserBranchViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserBranchViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<UserBranch, long> condition = new ConditionFilter<UserBranch, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._userBranchsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserBranchViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserBranchLightViewModel> GetLightModel(ConditionFilter<UserBranch, long> condition)
        {
            var entityCollection = this._userBranchsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserBranchLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserBranchLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            ConditionFilter<UserBranch, long> condition = new ConditionFilter<UserBranch, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._userBranchsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserBranchLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a UserBranchViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserBranchViewModel Get(long id)
        {
            var entity = this._userBranchsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<UserBranchViewModel> Add(IEnumerable<UserBranchViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._userBranchsRepository.Add(entityCollection).ToList();

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
        public UserBranchViewModel Add(UserBranchViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._userBranchsRepository.Add(entity);

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
        public IList<UserBranchViewModel> Update(IEnumerable<UserBranchViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._userBranchsRepository.Update(entityCollection).ToList();

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
        public UserBranchViewModel Update(UserBranchViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._userBranchsRepository.Update(entity);

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
        public void Delete(IEnumerable<UserBranchViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._userBranchsRepository.Delete(entityCollection);

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
            this._userBranchsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(UserBranchViewModel model)
        {
            var entity = model.ToEntity();
            this._userBranchsRepository.Delete(entity);

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
            var result = this._userBranchsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
