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
	/// Provides Vendor service for 
	/// business functionality.
	/// </summary>
	public class VendorsService : IVendorsService
	{
		#region Data Members
		private readonly IVendorsRepository _VendorsRepository;
        private readonly IAddresssRepository _AddresssRepository;
        private readonly IMobilesRepository _MobilesRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type VendorsService.
		/// </summary>
		/// <param name="VendorsRepository"></param>
		/// <param name="unitOfWork"></param>
		public VendorsService(
			IVendorsRepository VendorsRepository,
            IAddresssRepository AddresssRepository,
            IMobilesRepository MobilesRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._VendorsRepository = VendorsRepository;
            this._AddresssRepository = AddresssRepository;
            this._MobilesRepository = MobilesRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Vendor view model</param>
		public void ThrowExceptionIfExist(VendorViewModel model)
		{
			ConditionFilter<Vendor, long> condition = new ConditionFilter<Vendor, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._VendorsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<VendorViewModel> Get(ConditionFilter<Vendor, long> condition)
		{
			var entityCollection = this._VendorsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<VendorViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<VendorViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Vendor, long> condition = new ConditionFilter<Vendor, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._VendorsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<VendorViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<VendorLightViewModel> GetLightModel(ConditionFilter<Vendor, long> condition)
		{
			var entityCollection = this._VendorsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<VendorLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<VendorLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Vendor, long> condition = new ConditionFilter<Vendor, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._VendorsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<VendorLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a VendorViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public VendorViewModel Get(long id)
		{
			var entity = this._VendorsRepository.Get(id);
			var model = entity.ToModel();

            var phone = this._MobilesRepository.Get().FirstOrDefault(x => x.IsActive == true && x.IsMain == true && x.ObjectType == ObjectType.Vendor && x.ObjectId == model.Id);

            if (phone != null)
                model.Phone = phone.Number;

            var address = this._AddresssRepository.Get().FirstOrDefault(x => x.IsActive == true && x.IsMain == true && x.ObjectType == ObjectType.Vendor && x.ObjectId == model.Id);

            if (address != null)
                model.Address = address.Description;

			return model;
		}

		/// <summary>
		/// Gets a ProductLookUpViewModel.
		/// </summary>
		/// <param>no params </param>
		/// <returns> a list of ProductLookUpViewModel </returns>
		public List<VendorLightViewModel> GetLookUp()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Vendor, long> condition = new ConditionFilter<Vendor, long>
			{
				Query = (item =>
				item.Language == lang)
			};
			var entityCollection = this._VendorsRepository.Get(condition).ToList();
			var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			return lookup;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ListVendorsLightViewModel> GetByFilter(VendorFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Vendor, long> condition = new ConditionFilter<Vendor, long>()
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
            IQueryable<Vendor> queryableData = this._VendorsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyVendor != null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyVendor.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (model.OpeningCreditFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyVendor.OpeningCredit >= model.OpeningCreditFrom);

            if (model.OpeningCreditTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyVendor.OpeningCredit <= model.OpeningCreditTo);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyVendor.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyVendor.Date <= model.DateTo);

            var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyVendorId);
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
			var result = new GenericCollectionViewModel<ListVendorsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<VendorViewModel> Add(IEnumerable<VendorViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._VendorsRepository.Add(entityCollection).ToList();

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
		public VendorViewModel Add(VendorViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._VendorsRepository.Add(entity);

            var entityAr = new Vendor
            {
                Id = entity.Id,
                Description = model.DescriptionAr,
                Name = model.NameAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedVendors.Add(entityAr);
            this._VendorsRepository.Add(entityAr);

            var entityEn = new Vendor
            {
                Id = entity.Id,
                Description = model.DescriptionEn,
                Name = model.NameEn,
                Language = Language.English
            };
            entity.ChildTranslatedVendors.Add(entityEn);
            this._VendorsRepository.Add(entityEn);


            #region Commit Changes
            this._unitOfWork.Commit();
			#endregion

            if(string.IsNullOrEmpty(model.Phone) == false)
            {
                Mobile mobile = new Mobile
                {
                    IsActive = true,
                    IsMain = true,
                    Number = model.Phone,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Vendor
                };
                this._MobilesRepository.Add(mobile);
            }

            if(string.IsNullOrEmpty(model.Address) == false)
            {
                Address address = new Address
                {
                    IsActive = true,
                    IsMain = true,
                    Description = model.Address,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Vendor
                };
                this._AddresssRepository.Add(address);
            }

            this._unitOfWork.Commit();

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<VendorViewModel> Update(IEnumerable<VendorViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._VendorsRepository.Update(entityCollection).ToList();

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
		public VendorViewModel Update(VendorViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._VendorsRepository.Update(entity);

            ConditionFilter<Vendor, long> conditionFilter = new ConditionFilter<Vendor, long>()
            {
                Query = (x =>
                        x.ParentKeyVendorId == entity.Id)
            };
            var childs = this._VendorsRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._VendorsRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._VendorsRepository.Update(en);
            }

            if (string.IsNullOrEmpty(model.Address) == false)
            {
                var address = this._AddresssRepository.Get().FirstOrDefault(x => x.IsActive == true && x.IsMain == true && x.ObjectType == ObjectType.Vendor && x.ObjectId == model.Id);

                if (address != null)
                {
                    address.Description = model.Address;
                    this._AddresssRepository.Update(address);
                }
                else
                {
                    Address newAddress = new Address
                    {
                        IsActive = true,
                        IsMain = true,
                        ObjectType = ObjectType.Vendor,
                        ObjectId = entity.Id,
                        Description = model.Address
                    };
                    this._AddresssRepository.Add(newAddress);
                }
            }

            if (string.IsNullOrEmpty(model.Phone) == false)
            {
                Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x => x.IsActive == true && x.IsMain == true && x.ObjectType == ObjectType.Vendor && x.ObjectId == entity.Id);
                if(mobile != null)
                {
                    mobile.Number = model.Phone;
                    this._MobilesRepository.Update(mobile);
                }
                else
                {
                    Mobile newMobile = new Mobile
                    {
                        IsActive = true,
                        IsMain = true,
                        ObjectType = ObjectType.Vendor,
                        ObjectId = entity.Id,
                        Number = model.Phone
                    };
                    this._MobilesRepository.Add(newMobile);
                }
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
		public void Delete(IEnumerable<VendorViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._VendorsRepository.Delete(entityCollection);

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
			this._VendorsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(VendorViewModel model)
		{
			var entity = model.ToEntity();
			this._VendorsRepository.Delete(entity);

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
			var result = this._VendorsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
