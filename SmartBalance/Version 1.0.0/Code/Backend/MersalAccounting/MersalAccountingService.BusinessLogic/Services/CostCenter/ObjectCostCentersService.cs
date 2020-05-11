#region using...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
    public class ObjectCostCentersService : IObjectCostCentersService
    {
        #region Data Members
        private readonly IObjectCostCentersRepository _objectCostCentersRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public ObjectCostCentersService(
            IObjectCostCentersRepository objectCostCentersRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork
            )
        {
            this._objectCostCentersRepository = objectCostCentersRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">CostCenter view model</param>
		public void ThrowExceptionIfExist(ObjectCostCenterViewModel model)
        {
            ConditionFilter<ObjectCostCenter, long> condition = new ConditionFilter<ObjectCostCenter, long>
            {
                Query = (entity =>
                    entity.CostCenterId == model.CostCenterId &&
					 entity.ObjectId == model.ObjectId &&
					entity.ObjectType == model.ObjectType &&
					//entity.ObjectCostCenterId == model.ObjectCostCenterId &&
					//entity.ObjectCostCenterType == model.ObjectCostCenterType &&
					entity.Id != model.Id)
            };
            var existEntity = this._objectCostCentersRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public GenericCollectionViewModel<ListObjectCostCenterLightViewModel> GetByFilter(ObjectCostCenterFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ObjectCostCenter, long> condition = new ConditionFilter<ObjectCostCenter, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToNow();

            // The IQueryable data to query.  
            IQueryable<ObjectCostCenter> queryableData = this._objectCostCentersRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyObjectCostCenter != null);

            if (model.CostCenterId.HasValue)
                queryableData = queryableData.Where(x => x.CostCenterId == model.CostCenterId.Value);

            if (model.ObjectType.HasValue)
                queryableData = queryableData.Where(x => x.ObjectType == model.ObjectType);

            if (model.ObjectId.HasValue)
                queryableData = queryableData.Where(x => x.ObjectId == model.ObjectId.Value);

            //if (model.DateFrom.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.Date >= model.DateFrom);

            //if (model.DateTo.HasValue)
            //    queryableData = queryableData.Where(x => x.ParentKeyBank.Date <= model.DateTo);

            //if (model.IsActive != null)
            //    queryableData = queryableData.Where(x => x.IsActive);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    //var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyObjectCostCenterId);

            //    //ViewModel.Name = item.ChildTranslatedObjectCostCenters.FirstOrDefault(x => x.Language == lang).Name;

            //    //ViewModel.Description = item.ChildTranslatedObjectCostCenters.FirstOrDefault(x => x.Language == lang).Description;

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
            var result = new GenericCollectionViewModel<ListObjectCostCenterLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ObjectCostCenterViewModel> Get(ConditionFilter<ObjectCostCenter, long> condition)
        {
            var entityCollection = this._objectCostCentersRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ObjectCostCenterViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ObjectCostCenterViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<ObjectCostCenter, long> condition = new ConditionFilter<ObjectCostCenter, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._objectCostCentersRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ObjectCostCenterViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //public GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(ConditionFilter<ObjectCostCenter, long> condition)
        //{
        //    var entityCollection = this._objectCostCentersRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        //    var result = new GenericCollectionViewModel<ObjectCostCenterLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = dtoCollection.Count,
        //        PageIndex = condition.PageIndex,
        //        PageSize = condition.PageSize
        //    };

        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //public GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<ObjectCostCenter, long> condition = new ConditionFilter<ObjectCostCenter, long>
        //    {
        //        PageIndex = pageIndex,
        //        PageSize = pageSize                    
        //    };
        //    var entityCollection = this._objectCostCentersRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        //    var result = new GenericCollectionViewModel<ObjectCostCenterLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = dtoCollection.Count,
        //        PageIndex = pageIndex,
        //        PageSize = pageSize
        //    };

        //    return result;
        //}

        /// <summary>
        /// Gets a ProductLookUpViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of ProductLookUpViewModel </returns>
        //public List<ObjectCostCenterLightViewModel> GetLookUp()
        //{
        //    var lang = this._languageService.CurrentLanguage;

        //    ConditionFilter<ObjectCostCenter, long> condition = new ConditionFilter<ObjectCostCenter, long>
        //    {
                
        //    };
        //    var entityCollection = this._objectCostCentersRepository.Get(condition).ToList();
        //    var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

        //    return lookup;
        //}

        /// <summary>
        /// Gets a ObjectCostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ObjectCostCenterViewModel Get(long id)
        {
            var entity = this._objectCostCentersRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<ObjectCostCenterViewModel> Add(IEnumerable<ObjectCostCenterViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._objectCostCentersRepository.Add(entityCollection).ToList();

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
        public ObjectCostCenterViewModel Add(ObjectCostCenterViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._objectCostCentersRepository.Add(entity);


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
        public IList<ObjectCostCenterViewModel> Update(IEnumerable<ObjectCostCenterViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._objectCostCentersRepository.Update(entityCollection).ToList();

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
        public ObjectCostCenterViewModel Update(ObjectCostCenterViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._objectCostCentersRepository.Update(entity);

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
        public void Delete(IEnumerable<ObjectCostCenterViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._objectCostCentersRepository.Delete(entityCollection);

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
            this._objectCostCentersRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(ObjectCostCenterViewModel model)
        {
            var entity = model.ToEntity();
            this._objectCostCentersRepository.Delete(entity);

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
            var result = this._objectCostCentersRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
