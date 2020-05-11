#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
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
    /// Provides DiscountPercentage service for 
    /// business functionality.
    /// </summary>
    public class DiscountPercentagesService : IDiscountPercentagesService
    {
        #region Data Members
        private readonly IDiscountPercentagesRepository _DiscountPercentagesRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DiscountPercentagesService.
        /// </summary>
        /// <param name="DiscountPercentagesRepository"></param>
        /// <param name="unitOfWork"></param>
        public DiscountPercentagesService(
            IDiscountPercentagesRepository DiscountPercentagesRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._DiscountPercentagesRepository = DiscountPercentagesRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">DiscountPercentage view model</param>
        public void ThrowExceptionIfExist(DiscountPercentageViewModel model)
        {
            ConditionFilter<DiscountPercentage, long> condition = new ConditionFilter<DiscountPercentage, long>
            {
                Query = (entity =>
					entity.ParentKeyDiscountPercentageId != null &&
					entity.ParentKeyDiscountPercentageId != model.Id &&
                    entity.Name == model.Name &&
                    entity.Id != model.Id)
            };
            var existEntity = this._DiscountPercentagesRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.DiscountPercentageAlreadyExist);
        }

        public GenericCollectionViewModel<ListDiscountPercentegesLightViewModel> GetByFilter(DiscountPercentageFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<DiscountPercentage, long> condition = new ConditionFilter<DiscountPercentage, long>()
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
            IQueryable<DiscountPercentage> queryableData = this._DiscountPercentagesRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyDiscountPercentage != null);

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBrandId);
            //	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
            //	//if (item.ParentKeyBankMovement.Bank != null)
            //	//{
            //	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
            //	//}
            //	//if (item.ParentKeyBankMovement.JournalType != null)
            //	//{
            //	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
            //	//}
            //}

            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListDiscountPercentegesLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DiscountPercentageViewModel> Get(ConditionFilter<DiscountPercentage, long> condition)
        {
            var entityCollection = this._DiscountPercentagesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DiscountPercentageViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DiscountPercentageViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<DiscountPercentage, long> condition = new ConditionFilter<DiscountPercentage, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._DiscountPercentagesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DiscountPercentageViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DiscountPercentageLightViewModel> GetLightModel(ConditionFilter<DiscountPercentage, long> condition)
        {
            var entityCollection = this._DiscountPercentagesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DiscountPercentageLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DiscountPercentageViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DiscountPercentageLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<DiscountPercentage, long> condition = new ConditionFilter<DiscountPercentage, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._DiscountPercentagesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DiscountPercentageLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a DiscountPercentageViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DiscountPercentageViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._DiscountPercentagesRepository.Get(id);
            entity.Name = entity.ChildTranslatedDiscountPercentages.FirstOrDefault(x => x.Language == lang).Name;

            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<DiscountPercentageViewModel> Add(IEnumerable<DiscountPercentageViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DiscountPercentagesRepository.Add(entityCollection).ToList();

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
        public DiscountPercentageViewModel Add(DiscountPercentageViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();			
			try
			{
				entity.Percentage = int.Parse(model.Name.Replace("%", ""));
			}
			catch
			{

			}
			finally
			{
				entity.Name = null;
			}

            entity = this._DiscountPercentagesRepository.Add(entity);

            var entityAr = new DiscountPercentage
            {
                Name = model.Name,
                Description = model.DescriptionAr,
                Language = Framework.Common.Enums.Language.Arabic,
                ParentKeyDiscountPercentage = entity
            };
            entity.ChildTranslatedDiscountPercentages.Add(entityAr);
            this._DiscountPercentagesRepository.Add(entityAr);

            var entityEn = new DiscountPercentage
            {
                Name = model.Name,
                Description = model.DescriptionEn,
                Language = Framework.Common.Enums.Language.English,
                ParentKeyDiscountPercentage = entity
            };
            entity.ChildTranslatedDiscountPercentages.Add(entityEn);
            this._DiscountPercentagesRepository.Add(entityEn);


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
        public IList<DiscountPercentageViewModel> Update(IEnumerable<DiscountPercentageViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DiscountPercentagesRepository.Update(entityCollection).ToList();

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
        public DiscountPercentageViewModel Update(DiscountPercentageViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = this._DiscountPercentagesRepository.Get(model.Id);
			try
			{
				entity.Percentage = int.Parse(model.Name.Replace("%", ""));
			}
			catch
			{

			}
			finally
			{
				entity.Name = null;
			}
			entity = this._DiscountPercentagesRepository.Update(entity);

            var entityAr = entity.ChildTranslatedDiscountPercentages.FirstOrDefault(x => x.Language == Language.Arabic);

            entityAr.Name = model.Name;
            entityAr.Description = model.DescriptionAr;

            this._DiscountPercentagesRepository.Update(entityAr);

            var entityEn = entity.ChildTranslatedDiscountPercentages.FirstOrDefault(x => x.Language == Language.English);

            entityEn.Name = model.Name;
            entityEn.Description = model.DescriptionEn;

            this._DiscountPercentagesRepository.Update(entityEn);

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
        public void Delete(IEnumerable<DiscountPercentageViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._DiscountPercentagesRepository.Delete(entityCollection);

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
            this._DiscountPercentagesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(DiscountPercentageViewModel model)
        {
            var entity = model.ToEntity();
            this._DiscountPercentagesRepository.Delete(entity);

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
            var result = this._DiscountPercentagesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
