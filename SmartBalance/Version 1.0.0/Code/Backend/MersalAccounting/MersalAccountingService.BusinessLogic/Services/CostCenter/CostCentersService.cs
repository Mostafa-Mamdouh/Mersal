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
	/// Provides CostCenter service for 
	/// business functionality.
	/// </summary>
	public class CostCentersService : ICostCentersService
	{
		#region Data Members
		private readonly ICostCentersRepository _CostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CostCentersService.
		/// </summary>
		/// <param name="CostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public CostCentersService(
			ICostCentersRepository CostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._CostCentersRepository = CostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">CostCenter view model</param>
		public void ThrowExceptionIfExist(CostCenterViewModel model)
		{
            ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._CostCentersRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public GenericCollectionViewModel<ListCostCenterLightViewModel> GetByFilter(CostCenterFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>()
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
            IQueryable<CostCenter> queryableData = this._CostCentersRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyCostCenter != null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyCostCenter.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (model.OpeningCreditFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyCostCenter.OpeningCredit >= model.OpeningCreditFrom);

            if (model.OpeningCreditTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyCostCenter.OpeningCredit <= model.OpeningCreditTo);

            if (model.CostCenterTypeId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyCostCenter.CostCenterTypeId == model.CostCenterTypeId);

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
            //    //var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyCostCenterId);

            //    //ViewModel.Name = item.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Name;

            //    //ViewModel.Description = item.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Description;

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
            var result = new GenericCollectionViewModel<ListCostCenterLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CostCenterViewModel> Get(ConditionFilter<CostCenter, long> condition)
		{
			var entityCollection = this._CostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<CostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<CostCenterViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._CostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<CostCenterViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

        public GenericCollectionViewModel<CostCenterLightViewModel> GetEmployeesCostCenter()
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
            {
                Query = (item =>
                    item.Language == lang && item.ParentKeyCostCenter.CostCenterTypeId == 4)
            };
            var entityCollection = this._CostCentersRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<CostCenterLightViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(ConditionFilter<CostCenter, long> condition)
		{
			var entityCollection = this._CostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<CostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CostCenterViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._CostCentersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<CostCenterLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

        /// <summary>
        /// Gets a ProductLookUpViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of ProductLookUpViewModel </returns>
        public List<CostCenterLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
            {
                Query = (item =>
                item.Language == lang /*&& item.IsActive*/)
            };
            var entityCollection = this._CostCentersRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
       
            return lookup;
        }

        /// <summary>
        /// Gets a CostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CostCenterViewModel Get(long id)
		{
			var entity = this._CostCentersRepository.Get(id);
			var model = entity.ToModel();

            model.NameAr = entity.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == Language.Arabic).Name;
            model.NameEn = entity.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == Language.English).Name;
            model.DescriptionAr = entity.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == Language.Arabic).Description;
            model.DescriptionEn = entity.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == Language.English).Description;

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<CostCenterViewModel> Add(IEnumerable<CostCenterViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._CostCentersRepository.Add(entityCollection).ToList();

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
		public CostCenterViewModel Add(CostCenterViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._CostCentersRepository.Add(entity);

            var entityAr = new CostCenter
            {
                Id = entity.Id,
                Name = model.NameAr,
                Description = model.DescriptionAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedCostCenters.Add(entityAr);
            this._CostCentersRepository.Add(entityAr);

            var entityEn = new CostCenter
            {
                Id = entity.Id,
                Name = model.NameEn,
                Description = model.DescriptionEn,
                Language = Language.English
            };
            entity.ChildTranslatedCostCenters.Add(entityEn);
            this._CostCentersRepository.Add(entityEn);

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
		public IList<CostCenterViewModel> Update(IEnumerable<CostCenterViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._CostCentersRepository.Update(entityCollection).ToList();

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
		public CostCenterViewModel Update(CostCenterViewModel model)
		{
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._CostCentersRepository.Update(entity);

            ConditionFilter<CostCenter, long> conditionFilter = new ConditionFilter<CostCenter, long>()
            {
                Query = (x =>
                        x.ParentKeyCostCenterId == entity.Id)
            };
            var childs = this._CostCentersRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._CostCentersRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._CostCentersRepository.Update(en);
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
		public void Delete(IEnumerable<CostCenterViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._CostCentersRepository.Delete(entityCollection);

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
			this._CostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(CostCenterViewModel model)
		{
			var entity = model.ToEntity();
			this._CostCentersRepository.Delete(entity);

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
			var result = this._CostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
