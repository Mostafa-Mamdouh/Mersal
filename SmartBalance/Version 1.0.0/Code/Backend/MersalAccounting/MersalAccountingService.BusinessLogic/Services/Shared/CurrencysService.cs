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
	/// Provides Currency service for 
	/// business functionality.
	/// </summary>
	public class CurrencysService : ICurrencysService
	{
		#region Data Members
		private readonly ICurrencysRepository _CurrencysRepository;
		private readonly ICurrencyRatesRepository _currencyRatesRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CurrencysService.
		/// </summary>
		/// <param name="CurrencysRepository"></param>
		/// <param name="unitOfWork"></param>
		public CurrencysService(
			ICurrencysRepository CurrencysRepository,
			ICurrencyRatesRepository currencyRatesRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._CurrencysRepository = CurrencysRepository;
			this._currencyRatesRepository = currencyRatesRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Currency view model</param>
		public void ThrowExceptionIfExist(CurrencyViewModel model)
		{
			//ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
			//{
			//    Query = (entity =>
			//        entity.Name == model.Name &&
			//        entity.Id != model.Id)
			//};
			//var existEntity = this._CurrencysRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//    throw new ItemAlreadyExistException();
		}
		public void ThrowExceptionIfExist(Currency model)
		{
			ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
			{
				Query = (entity =>
					entity.Name == model.Name &&
					entity.Id != model.Id)
			};
			var existEntity = this._CurrencysRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		public GenericCollectionViewModel<ListCurrencyLightViewModel> GetByFilter(CurrencyFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>()
			{
				Order = Framework.Common.Enums.Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Framework.Common.Enums.Order.Ascending;
			}

			//if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();

			// The IQueryable data to query.  
			IQueryable<Currency> queryableData = this._CurrencysRepository.Get(condition);

			//queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyCurrency != null);
			queryableData = queryableData.Where(x => x.ParentKeyCurrency == null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyCurrency.Code.Contains(model.Code));

			if (string.IsNullOrEmpty(model.NameAr) == false)
				queryableData = queryableData.Where(x => x.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == Language.Arabic).Name.Contains(model.NameAr));

			if (string.IsNullOrEmpty(model.NameEn) == false)
				queryableData = queryableData.Where(x => x.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == Language.English).Name.Contains(model.NameEn));

			if (string.IsNullOrEmpty(model.Symbol) == false)
				queryableData = queryableData.Where(x => x.Symbol.Equals(model.Symbol));

			if (string.IsNullOrEmpty(model.DescriptionAr) == false)
				queryableData = queryableData.Where(x => x.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == Language.Arabic).Description.Contains(model.DescriptionAr));

			if (string.IsNullOrEmpty(model.DescriptionEn) == false)
				queryableData = queryableData.Where(x => x.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == Language.English).Description.Contains(model.DescriptionEn));


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

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
			var result = new GenericCollectionViewModel<ListCurrencyLightViewModel>
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
		public GenericCollectionViewModel<CurrencyViewModel> Get(ConditionFilter<Currency, long> condition)
		{
			var entityCollection = this._CurrencysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<CurrencyViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
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
		public GenericCollectionViewModel<CurrencyViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._CurrencysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<CurrencyViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CurrencyViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<CurrencyLightViewModel> GetLightModel(ConditionFilter<Currency, long> condition)
		{
			var entityCollection = this._CurrencysRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<CurrencyLightViewModel>
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
		public GenericCollectionViewModel<CurrencyLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._CurrencysRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<CurrencyLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a CurrencyViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public CurrencyViewModel Get(long id)
		{
			var entity = this._CurrencysRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public List<CurrencyLightViewModel> GetLookUp()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
			{
				Query = (item => item.Language == lang)
			};
			var entityCollection = this._CurrencysRepository.Get(condition).ToList();
			List<CurrencyLightViewModel> lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			return lookup;
		}
		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<CurrencyViewModel> Add(IEnumerable<CurrencyViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._CurrencysRepository.Add(entityCollection).ToList();

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
		public CurrencyViewModel Add(CurrencyViewModel model)
		{
			try
			{
				var entity = model.ToEntity();
				entity = this._CurrencysRepository.Add(entity);
				var entityAr = new Currency
				{
					//Id = entity.Id,
					Description = model.DescriptionAr,
					Name = model.NameAr,
					Language = Language.Arabic
				};
				this.ThrowExceptionIfExist(entityAr);
				entity.ChildTranslatedCurrencys.Add(entityAr);
				this._CurrencysRepository.Add(entityAr);

				var entityEn = new Currency
				{
					//Id = entity.Id,
					Description = model.DescriptionEn,
					Name = model.NameEn,
					Language = Language.English
				};
				this.ThrowExceptionIfExist(entityEn);
				entity.ChildTranslatedCurrencys.Add(entityEn);
				this._CurrencysRepository.Add(entityEn);

				CurrencyRate currencyRate = new CurrencyRate()
				{
					Date = entity.Date,
					Currency = entity,
					Price = model.Price,
					ExchangeCurrencyId = model.ExchangeCurrencyId
				};

				this._currencyRatesRepository.Add(currencyRate);

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
		public IList<CurrencyViewModel> Update(IEnumerable<CurrencyViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._CurrencysRepository.Update(entityCollection).ToList();

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
		public CurrencyViewModel Update(CurrencyViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._CurrencysRepository.Update(entity);

			Currency entityAr = entity.ChildTranslatedCurrencys.Where(x => x.Language == Language.Arabic).FirstOrDefault();
			entityAr.Description = model.DescriptionAr;
			entityAr.Name = model.NameAr;
			entityAr.Date = entity.Date;
			this._CurrencysRepository.Update(entityAr);
			Currency entityEn = entity.ChildTranslatedCurrencys.Where(x => x.Language == Language.English).FirstOrDefault();
			entityEn.Description = model.DescriptionEn;
			entityEn.Name = model.NameEn;
			entityEn.Date = entity.Date;
			this._CurrencysRepository.Update(entityEn);

			var latest = this._currencyRatesRepository.Get(null)
				.OrderByDescending(c => c.Id)
				.Where(x => x.CurrencyId == entity.Id)
				.FirstOrDefault();

			if (!(latest != null && latest.Price == model.Price))
			{
				CurrencyRate currencyRate = new CurrencyRate()
				{
					Date = entity.Date,
					Currency = entity,
					Price = model.Price,
					ExchangeCurrencyId = model.ExchangeCurrencyId
				};

				this._currencyRatesRepository.Add(currencyRate);
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
		public void Delete(IEnumerable<CurrencyViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._CurrencysRepository.Delete(entityCollection);

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
			this._CurrencysRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(CurrencyViewModel model)
		{
			var entity = model.ToEntity();
			this._CurrencysRepository.Delete(entity);

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
			var result = this._CurrencysRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
