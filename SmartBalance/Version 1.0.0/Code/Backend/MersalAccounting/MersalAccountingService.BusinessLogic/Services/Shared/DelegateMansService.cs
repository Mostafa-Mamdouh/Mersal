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
	/// Provides DelegateMan service for 
	/// business functionality.
	/// </summary>
	public class DelegateMansService : IDelegateMansService
	{
		#region Data Members
		private readonly IDelegateMansRepository _DelegateMansRepository;
        private readonly IMailsRepository _MailsRepository;
        private readonly IAddresssRepository _AddresssRepository;
        private readonly IMobilesRepository _MobilesRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DelegateMansService.
		/// </summary>
		/// <param name="DelegateMansRepository"></param>
		/// <param name="unitOfWork"></param>
		public DelegateMansService(
			IDelegateMansRepository DelegateMansRepository,
            IMailsRepository MailsRepository,
            IAddresssRepository addresssRepository,
            IMobilesRepository MobilesRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._DelegateMansRepository = DelegateMansRepository;
            this._MailsRepository = MailsRepository;
            this._AddresssRepository = addresssRepository;
            this._MobilesRepository = MobilesRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">DelegateMan view model</param>
		public void ThrowExceptionIfExist(DelegateManViewModel model)
		{
            ConditionFilter<DelegateMan, long> condition = new ConditionFilter<DelegateMan, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._DelegateMansRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

        public void ThrowExceptionIfExist(Mail model)
        {
            ConditionFilter<Mail, long> condition = new ConditionFilter<Mail, long>
            {
                Query = (entity =>
                    entity.Email == model.Email &&
                    entity.Id != model.Id)
            };
            var existEntity = this._MailsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.EmailAlreadyExist);
        }

        public void ThrowExceptionIfExist(Mobile model)
        {
            ConditionFilter<Mobile, long> condition = new ConditionFilter<Mobile, long>
            {
                Query = (entity =>
                    entity.Number == model.Number &&
                    entity.Id != model.Id)
            };
            var existEntity = this._MobilesRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.PhoneAlreadyExist);
        }

        public GenericCollectionViewModel<ListDelegateMensLightViewModel> GetByFilter(DelegateMenFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<DelegateMan, long> condition = new ConditionFilter<DelegateMan, long>()
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
            IQueryable<DelegateMan> queryableData = this._DelegateMansRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyDelegateMan != null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyDelegateMan.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDelegateMan.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDelegateMan.Date <= model.DateTo);

            if (string.IsNullOrEmpty(model.Phone) == false)
            {
                IQueryable<long> mobiles = this._MobilesRepository.Get().Where(m => m.Number.Contains(model.Phone))
                    .Where(m => m.ObjectType == ObjectType.Delegate).Select(m => m.ObjectId);
                queryableData = queryableData.Where(x => mobiles.Contains((long)x.ParentKeyDelegateManId));

            }

            if(string.IsNullOrEmpty(model.Email) == false)
            {
                IQueryable<long> mails = this._MailsRepository.Get().Where(m => m.Email.Contains(model.Email))
                    .Where(m => m.ObjectType == ObjectType.Delegate).Select(m => m.ObjectId);
                queryableData = queryableData.Where(x => mails.Contains((long)x.ParentKeyDelegateManId));
            }
            

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyDelegateManId);

                ConditionFilter<Mobile, long> phoneCondition = new ConditionFilter<Mobile, long>();

                var mobile = this._MobilesRepository.Get(phoneCondition).FirstOrDefault(q => ((q.ObjectId == item.ParentKeyDelegateManId) && (q.ObjectType == ObjectType.Delegate)));
                if (mobile != null) ViewModel.Phone = mobile.Number;

                ConditionFilter<Mail, long> mailCondition = new ConditionFilter<Mail, long>();

                var mail = this._MailsRepository.Get(mailCondition).FirstOrDefault(q => ((q.ObjectId == item.ParentKeyDelegateManId) && (q.ObjectType == ObjectType.Delegate)));
                if (mobile != null) ViewModel.Email = mail.Email;

                //if (item.ParentKeyBank != null)
                //{
                //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                //}              
            }
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
            var result = new GenericCollectionViewModel<ListDelegateMensLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DelegateManViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DelegateManViewModel> Get(ConditionFilter<DelegateMan, long> condition)
		{
			var entityCollection = this._DelegateMansRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<DelegateManViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<DelegateManViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<DelegateMan, long> condition = new ConditionFilter<DelegateMan, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (x => x.Language == lang)
			};
			var entityCollection = this._DelegateMansRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<DelegateManViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<DelegateManLightViewModel> GetLightModel(ConditionFilter<DelegateMan, long> condition)
		{
			var entityCollection = this._DelegateMansRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<DelegateManLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<DelegateManLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			ConditionFilter<DelegateMan, long> condition = new ConditionFilter<DelegateMan, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._DelegateMansRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<DelegateManLightViewModel>
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
        public List<DelegateManLightViewModel> GetLookUp()
        {
            var entityCollection = this._DelegateMansRepository.Get(null).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }
        /// <summary>
        /// Gets a DelegateManViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DelegateManViewModel Get(long id)
		{
			var entity = this._DelegateMansRepository.Get(id);
			var model = entity.ToModel();

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            if(address != null)
                model.Address = address.Description;
            Mail mail = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            if(mail != null)
                model.Email = mail.Email;
            Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            if(mobile != null)
                model.Phone = mobile.Number;

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<DelegateManViewModel> Add(IEnumerable<DelegateManViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._DelegateMansRepository.Add(entityCollection).ToList();

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
		public DelegateManViewModel Add(DelegateManViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._DelegateMansRepository.Add(entity);

            var entityAr = new DelegateMan
            {
                Id = entity.Id,
                Description = model.DescriptionAr,
                Name = model.NameAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedDelegateMans.Add(entityAr);
            this._DelegateMansRepository.Add(entityAr);

            var entityEn = new DelegateMan
            {
                Id = entity.Id,
                Description = model.DescriptionEn,
                Name = model.NameEn,
                Language = Language.English
            };
            entity.ChildTranslatedDelegateMans.Add(entityEn);
            this._DelegateMansRepository.Add(entityEn);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            if (string.IsNullOrEmpty(model.Email) == false)
            {
                Mail mail = new Mail
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Delegate,
                    Email = model.Email,
                    IsMain = true,
                    IsVerified = true,
                    IsActive = true
                };
                ThrowExceptionIfExist(mail);
                this._MailsRepository.Add(mail); 
            }

            if (string.IsNullOrEmpty(model.Address) == false)
            {
                Address address = new Address
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Delegate,
                    Description = model.Address,
                    IsMain = true,
                    IsActive = true
                };
                this._AddresssRepository.Add(address); 
            }

            if (string.IsNullOrEmpty(model.Phone) == false)
            {
                Mobile mobile = new Mobile
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Delegate,
                    Number = model.Phone,
                    IsActive = true,
                    IsMain = true
                };
                ThrowExceptionIfExist(mobile);
                this._MobilesRepository.Add(mobile); 
            }

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
		public IList<DelegateManViewModel> Update(IEnumerable<DelegateManViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._DelegateMansRepository.Update(entityCollection).ToList();

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
		public DelegateManViewModel Update(DelegateManViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._DelegateMansRepository.Update(entity);

            ConditionFilter<DelegateMan, long> conditionFilter = new ConditionFilter<DelegateMan, long>()
            {
                Query = (x =>
                        x.ParentKeyDelegateManId == entity.Id)
            };
            var childs = this._DelegateMansRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._DelegateMansRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._DelegateMansRepository.Update(en);
            }

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            address.Description = model.Address;
            this._AddresssRepository.Update(address);

            Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            mobile.Number = model.Phone;

            Mail mail = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Delegate);
            mail.Email = model.Email;
            this._MailsRepository.Update(mail);

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
		public void Delete(IEnumerable<DelegateManViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._DelegateMansRepository.Delete(entityCollection);

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
			this._DelegateMansRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(DelegateManViewModel model)
		{
			var entity = model.ToEntity();
			this._DelegateMansRepository.Delete(entity);

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
			var result = this._DelegateMansRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

        
        #endregion
    }
}
