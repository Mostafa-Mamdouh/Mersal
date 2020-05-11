#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
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
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides Location service for 
    /// business functionality.
    /// </summary>
    public class LocationsService : ILocationsService
    {
        #region Data Members
        private readonly ILocationsRepository _LocationsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LocationsService.
        /// </summary>
        /// <param name="LocationsRepository"></param>
        /// <param name="unitOfWork"></param>
        public LocationsService(
            ILocationsRepository LocationsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._LocationsRepository = LocationsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Location view model</param>
        public void ThrowExceptionIfExist(LocationViewModel model)
        {
			ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._LocationsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LocationViewModel> Get(ConditionFilter<Location, long> condition)
        {
            var entityCollection = this._LocationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<LocationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LocationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
            var entityCollection = this._LocationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<LocationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LocationLightViewModel> GetLightModel(ConditionFilter<Location, long> condition)
        {
            var entityCollection = this._LocationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<LocationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LocationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
				Query = (item =>
					item.Language == lang &&
                    item.ParentKeyLocation.ParentLocationId == null)
			};
            var entityCollection = this._LocationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            //foreach (var item in dtoCollection)
            //{
            //    var entity = entityCollection.FirstOrDefault(x => x.ParentKeyLocationId == item.Id).ParentKeyLocation;
            //    foreach (var child in item.ChildLocations)
            //    {
            //        var childEntity = entity.ChildLocations.FirstOrDefault(x => x.Id == child.Id);
            //        child.DisplyedName = $"{child.Code}-{childEntity.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Title}";
            //    }
            //}
            var result = new GenericCollectionViewModel<LocationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a LocationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LocationViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._LocationsRepository.Get(id);
            var model = entity.ToModel();
            if (entity.ParentLocationId != null)
            {
                Location location = entity.ParentLocation.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang);
                model.ParentLocationName = $"{location.ParentKeyLocation.Code}-{location.Title}";
            }
            return model;
        }


        public GenericCollectionViewModel<ListLocationsLightViewModel> GetByFilter(LocationFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>()
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
            IQueryable<Location> queryableData = this._LocationsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyLocationId.HasValue == true);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyLocation.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Title) == false)
                queryableData = queryableData.Where(x => x.ParentKeyLocation.Title.Contains(model.Title));
            
            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyLocation.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyLocation.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.Id);

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
            var result = new GenericCollectionViewModel<ListLocationsLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public List<LocationLightViewModel> GetChildren(long locationId)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>
            {
                Query = (item =>
                    item.Language == lang &&
                    item.ParentKeyLocation.ParentLocationId == locationId)
            };
            var entityCollection = this._LocationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return dtoCollection;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<LocationViewModel> Add(IEnumerable<LocationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._LocationsRepository.Add(entityCollection).ToList();

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
        public LocationViewModel Add(LocationViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._LocationsRepository.Add(entity);

			var ar = new Location
			{
				Language = Language.Arabic,
				Title = model.TitleAr,
				Description = model.DescriptionAr
			};
			entity.ChildTranslatedLocations.Add(ar);
			this._LocationsRepository.Add(ar);

			var en = new Location
			{
				Language = Language.English,
				Title = model.TitleEn,
				Description = model.DescriptionEn
			};
			entity.ChildTranslatedLocations.Add(en);
			this._LocationsRepository.Add(en);

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
        public IList<LocationViewModel> Update(IEnumerable<LocationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._LocationsRepository.Update(entityCollection).ToList();

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
        public LocationViewModel Update(LocationViewModel model)
        {
            this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._LocationsRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.Date = model.Date;
            entity.ParentLocationId = model.ParentLocationId;
			entity = this._LocationsRepository.Update(entity);

			
			var childs = this._LocationsRepository.Get(null).Where(x => x.ParentKeyLocationId == entity.Id);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Title = model.TitleAr;
				ar.Description = model.DescriptionAr;
				this._LocationsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Title = model.TitleEn;
				en.Description = model.DescriptionEn;
				this._LocationsRepository.Update(en);
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
        public void Delete(IEnumerable<LocationViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._LocationsRepository.Delete(entityCollection);

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
            this._LocationsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(LocationViewModel model)
        {
            var entity = model.ToEntity();
            this._LocationsRepository.Delete(entity);

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
            var result = this._LocationsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
