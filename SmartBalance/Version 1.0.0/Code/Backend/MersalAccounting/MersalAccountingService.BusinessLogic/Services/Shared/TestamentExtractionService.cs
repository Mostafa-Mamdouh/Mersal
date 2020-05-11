#region Using ...
using Framework.Common.Enums;
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
	/// Provides TestamentExtraction service for 
	/// business functionality.
	/// </summary>
	public class TestamentExtractionService : ITestamentExtractionService
	{
		#region Data Members
		private readonly ITestamentExtractionRepository _TestamentExtractionRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TestamentExtractionsService.
		/// </summary>
		/// <param name="TestamentExtractionsRepository"></param>
		/// <param name="unitOfWork"></param>
		public TestamentExtractionService(
			ITestamentExtractionRepository TestamentExtractionsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._TestamentExtractionRepository = TestamentExtractionsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">TestamentExtraction view model</param>
		public void ThrowExceptionIfExist(TestamentExtractionViewModel model)
		{
			//ConditionFilter<TestamentExtraction, long> condition = new ConditionFilter<TestamentExtraction, long>
			//{
			//    Query = (entity =>
			//        entity.Name == model.Name &&
			//        entity.Id != model.Id)
			//};
			//var existEntity = this._TestamentExtractionRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//    throw new ItemAlreadyExistException();
		}
		public void ThrowExceptionIfExist(TestamentExtraction model)
		{
			ConditionFilter<TestamentExtraction, long> condition = new ConditionFilter<TestamentExtraction, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._TestamentExtractionRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}
        public GenericCollectionViewModel<TestamentExtractionViewModel> GetByFilter(TestamentExtractionFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<TestamentExtraction, long> condition = new ConditionFilter<TestamentExtraction, long>()
            {
                Order = Framework.Common.Enums.Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Framework.Common.Enums.Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();

            // The IQueryable data to query.  
            IQueryable<TestamentExtraction> queryableData = this._TestamentExtractionRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyCurrency != null);
            queryableData = queryableData.Where(x => x.ParentKeyTestamentExtraction == null);


            if (string.IsNullOrEmpty(model.NameAr) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedTestamentExtractions.FirstOrDefault(z => z.Language == Language.Arabic).Name.Contains(model.NameAr));

            if (string.IsNullOrEmpty(model.NameEn) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedTestamentExtractions.FirstOrDefault(z => z.Language == Language.English).Name.Contains(model.NameEn));



            if (string.IsNullOrEmpty(model.DescriptionAr) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedTestamentExtractions.FirstOrDefault(z => z.Language == Language.Arabic).Description.Contains(model.DescriptionAr));

            if (string.IsNullOrEmpty(model.DescriptionEn) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedTestamentExtractions.FirstOrDefault(z => z.Language == Language.English).Description.Contains(model.DescriptionEn));


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.Id);

            //    //ViewModel.Currency = item.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;

            //    //ViewModel.ExchangeCurrency = item.ExchangeCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;

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
            var result = new GenericCollectionViewModel<TestamentExtractionViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(ConditionFilter<TestamentExtraction, long> condition)
        {
            var entityCollection = this._TestamentExtractionRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentExtractionViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of CurrencyViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<TestamentExtraction, long> condition = new ConditionFilter<TestamentExtraction, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._TestamentExtractionRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<TestamentExtractionViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<TestamentExtractionViewModel> Get(ConditionFilter<TestamentExtraction, long> condition)
		{
			var entityCollection = this._TestamentExtractionRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<TestamentExtractionViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<TestamentExtractionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<TestamentExtraction, long> condition = new ConditionFilter<TestamentExtraction, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._TestamentExtractionRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<TestamentExtractionViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


		/// <summary>
		/// Gets a TestamentExtractionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TestamentExtractionViewModel Get(long id)
		{
			var entity = this._TestamentExtractionRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<TestamentExtractionViewModel> Add(IEnumerable<TestamentExtractionViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._TestamentExtractionRepository.Add(entityCollection).ToList();

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
		public TestamentExtractionViewModel Add(TestamentExtractionViewModel model)
		{
			try
			{
				var entity = model.ToEntity();
				entity = this._TestamentExtractionRepository.Add(entity);
				var entityAr = new TestamentExtraction
				{
					//Id = entity.Id,
					Description = model.DescriptionAr,
					Name = model.NameAr,
					Language = Language.Arabic
				};
				this.ThrowExceptionIfExist(entityAr);
				entity.ChildTranslatedTestamentExtractions.Add(entityAr);
				this._TestamentExtractionRepository.Add(entityAr);

				var entityEn = new TestamentExtraction
				{
					//Id = entity.Id,
					Description = model.DescriptionEn,
					Name = model.NameEn,
					Language = Language.English
				};
				this.ThrowExceptionIfExist(entityEn);
				entity.ChildTranslatedTestamentExtractions.Add(entityEn);
				this._TestamentExtractionRepository.Add(entityEn);


				#region Commit Changes
				this._unitOfWork.Commit();
				#endregion

				model = entity.ToModel();
				return model;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<TestamentExtractionViewModel> Update(IEnumerable<TestamentExtractionViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._TestamentExtractionRepository.Update(entityCollection).ToList();

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
		public TestamentExtractionViewModel Update(TestamentExtractionViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._TestamentExtractionRepository.Update(entity);

			TestamentExtraction entityAr = entity.ChildTranslatedTestamentExtractions.Where(x => x.Language == Language.Arabic).FirstOrDefault();
			entityAr.Description = model.DescriptionAr;
			entityAr.Name = model.NameAr;
			this._TestamentExtractionRepository.Update(entityAr);
			TestamentExtraction entityEn = entity.ChildTranslatedTestamentExtractions.Where(x => x.Language == Language.English).FirstOrDefault();
			entityEn.Description = model.DescriptionEn;
			entityEn.Name = model.NameEn;
			this._TestamentExtractionRepository.Update(entityEn);

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
		public void Delete(IEnumerable<TestamentExtractionViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._TestamentExtractionRepository.Delete(entityCollection);

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
			this._TestamentExtractionRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(TestamentExtractionViewModel model)
		{
			var entity = model.ToEntity();
			this._TestamentExtractionRepository.Delete(entity);

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
			var result = this._TestamentExtractionRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
