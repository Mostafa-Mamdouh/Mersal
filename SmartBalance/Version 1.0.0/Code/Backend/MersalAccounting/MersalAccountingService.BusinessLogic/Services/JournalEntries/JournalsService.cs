#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides Journal service for 
	/// business functionality.
	/// </summary>
	public class JournalsService : IJournalsService
	{
		#region Data Members
		//private readonly ICurrentUserService _currentUserService;
		//private readonly ISettingsService _settingsService;

		private readonly IJournalsRepository _JournalsRepository;
		private readonly ITransactionsRepository _transactionsRepository;

		private readonly IBankMovementsRepository _bankMovementsRepository;
		private readonly IPaymentMovmentsRepository _paymentMovmentsRepository;
		private readonly IPurchaseInvoicesRepository _purchaseInvoicesRepository;
		private readonly IPurchaseRebatesRepository _purchaseRebatesRepository;
		private readonly IDonationsRepository _donationsRepository;
		private readonly ISalesBillRepository _salesBillRepository;
		private readonly ISalesRebatesRepository _salesRebatesRepository;

		private readonly IAccountChartsRepository _accountChartsRepository;
		private readonly ILanguageService _languageService;
		private readonly IResourcesService _resourcesService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalsService.
		/// </summary>      
		/// <param name="JournalsRepository"></param>
		/// <param name="languageService"></param>
		/// <param name="unitOfWork"></param>
		public JournalsService(
			 //ICurrentUserService currentUserService,            
			 //ISettingsService settingsService,
			 IBankMovementsRepository bankMovementsRepository,
			IPaymentMovmentsRepository paymentMovmentsRepository,
			IPurchaseInvoicesRepository purchaseInvoicesRepository,
			IPurchaseRebatesRepository purchaseRebatesRepository,
			IDonationsRepository donationsRepository,
			ISalesBillRepository salesBillRepository,
			ISalesRebatesRepository salesRebatesRepository,

			IJournalsRepository JournalsRepository,
			ITransactionsRepository transactionsRepository,
			IAccountChartsRepository accountChartsRepository,
			ILanguageService languageService,
			IResourcesService resourcesService,
			IUnitOfWork unitOfWork)
		{
			//this._currentUserService = currentUserService;
			//this._settingsService = settingsService;
			this._bankMovementsRepository = bankMovementsRepository;
			this._paymentMovmentsRepository = paymentMovmentsRepository;
			this._purchaseInvoicesRepository = purchaseInvoicesRepository;
			this._purchaseRebatesRepository = purchaseRebatesRepository;
			this._donationsRepository = donationsRepository;
			this._salesBillRepository = salesBillRepository;
			this._salesRebatesRepository = salesRebatesRepository;

			this._JournalsRepository = JournalsRepository;
			this._transactionsRepository = transactionsRepository;
			this._accountChartsRepository = accountChartsRepository;
			this._languageService = languageService;
			this._resourcesService = resourcesService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Journal view model</param>
		public void ThrowExceptionIfExist(JournalViewModel model)
		{
			ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>
			{
				Query = (entity =>
					//entity.Name == model.Name &&
					entity.Code == model.Code)
			};
			var existEntity = this._JournalsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalViewModel> Get(ConditionFilter<Journal, long> condition)
		{
			var entityCollection = this._JournalsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._JournalsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalLightViewModel> GetLightModel(ConditionFilter<Journal, long> condition)
		{
			var entityCollection = this._JournalsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<AddJournalEntriesViewModel> GetByFilter(FilterJournalEntriesViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>()
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
			IQueryable<Journal> queryableData = this._JournalsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.ParentKeyJournalId.HasValue == false);

			if (model.Preview)
				queryableData = queryableData.Where(x => x.PostingStatus == PostingStatus.NeedAprove);
			else
				queryableData = queryableData.Where(x => x.PostingStatus == PostingStatus.Approved);


			List<int> types = new List<int>();

			if (model.PostBankMovement) types.Add((int)MovementType.BankMovement);
			if (model.PostPaymentMovement) types.Add((int)MovementType.PaymentMovement);
			if (model.PostPurchaseInvoice) types.Add((int)MovementType.PurchaseInvoice);
			if (model.PostPurchaseRebate) types.Add((int)MovementType.PurchaseRebate);
			if (model.PostReceiptsMovement) types.Add((int)MovementType.ReceiptsMovement);
			if (model.PostSalesInvoice) types.Add((int)MovementType.SalesInvoice);
			if (model.PostSalesRebate) types.Add((int)MovementType.SalesRebate);
			if (model.PostStoreMovement) types.Add((int)MovementType.StoreMovement);

			if (types.Count > 0)
			{
				queryableData = queryableData.Where(x =>
					x.MovementType.HasValue &&
					types.Any(t => t == (int)x.MovementType)
					);
			}
			//if (model.PostPaymentMovement)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.PaymentMovement);

			//if (model.PostPurchaseInvoice)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.PurchaseInvoice);

			//if (model.PostPurchaseRebate)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.PurchaseRebate);

			//if (model.PostReceiptsMovement)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.ReceiptsMovement);

			//if (model.PostSalesInvoice)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.SalesInvoice);

			//if (model.PostSalesRebate)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.SalesRebate);

			//if (model.PostStoreMovement)
			//    queryableData = queryableData.Where(x => x.MovementType == MovementType.StoreMovement);


			if (string.IsNullOrEmpty(model.Id) == false)
				queryableData = queryableData.Where(x => x.Id.ToString().Contains(model.Id));

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.Date >= model.DateFrom.Value);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.Date <= model.DateTo.Value);

			if (string.IsNullOrEmpty(model.DescriptionAr) == false)
			{
				queryableData = queryableData.Where(x =>
					x.ChildTranslatedJournals.FirstOrDefault(y => y.Language == Language.Arabic).Description.Contains(model.DescriptionAr));
			}

			if (string.IsNullOrEmpty(model.DescriptionEn) == false)
			{
				queryableData = queryableData.Where(x =>
					x.ChildTranslatedJournals.FirstOrDefault(y => y.Language == Language.English).Description.Contains(model.DescriptionEn));
			}

			//if (string.IsNullOrEmpty(model.Id) &&
			//    model.DateFrom != null && model.DateTo != null)
			//{
			//    condition.Query = x => 
			//        x.ParentKeyJournalId == null &&
			//        x.Date >= model.DateFrom && x.Date <= model.DateTo;
			//}
			//else if (string.IsNullOrEmpty(model.Id) == false &&
			//  model.DateFrom != null && model.DateTo != null)
			//{
			//    condition.Query = x =>
			//        x.ParentKeyJournalId == null &&
			//        x.Id.ToString().Contains(model.Id) &&
			//        x.Date >= model.DateFrom && x.Date <= model.DateTo;
			//}


			//else if (string.IsNullOrEmpty(model.Id) &&
			//    model.DateFrom != null && model.DateTo == null)
			//{
			//    condition.Query = x => 
			//        x.ParentKeyJournalId == null &&
			//        x.Date >= model.DateFrom;
			//}
			//else if (string.IsNullOrEmpty(model.Id) == false &&
			//  model.DateFrom != null && model.DateTo == null)
			//{
			//    condition.Query = x =>
			//        x.ParentKeyJournalId == null &&
			//        x.Id.ToString().Contains(model.Id) &&
			//        x.Date >= model.DateFrom;
			//}


			//else if (string.IsNullOrEmpty(model.Id) &&
			//    model.DateFrom == null && model.DateTo != null)
			//{
			//    condition.Query = x => 
			//        x.ParentKeyJournalId == null &&
			//        x.Date <= model.DateTo;
			//}
			//else if (string.IsNullOrEmpty(model.Id) == false &&
			//   model.DateFrom == null && model.DateTo != null)
			//{
			//    condition.Query = x =>
			//        x.ParentKeyJournalId == null &&
			//        x.Id.ToString().Contains(model.Id) &&
			//        x.Date <= model.DateTo;
			//}


			//else if (string.IsNullOrEmpty(model.Id) &&
			//   model.DateFrom == null && model.DateTo == null)
			//{
			//    condition.Query = x =>
			//        x.ParentKeyJournalId == null;
			//}
			//else if (string.IsNullOrEmpty(model.Id) == false &&
			//   model.DateFrom == null && model.DateTo == null)
			//{
			//    condition.Query = x =>
			//        x.ParentKeyJournalId == null &&
			//        x.Id.ToString().Contains(model.Id);
			//}

			//else
			//{
			//    condition.Query = x => x.ParentKeyJournalId == null;
			//}

			//var entityCollection = this._JournalsRepository.Get(condition).ToList();

			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToAddModel()).ToList();

			//if (model.Filters != null)
			//{
			//    foreach (var item in model.Filters)
			//    {
			//        switch (item.Field)
			//        {
			//            case "descriptionAr":
			//                dtoCollection = dtoCollection.Where(x => x.DescriptionAr.Contains(item.Value)).ToList();
			//                break;
			//            case "descriptionEn":
			//                dtoCollection = dtoCollection.Where(x => x.DescriptionEn.Contains(item.Value)).ToList();
			//                break;
			//            case "documentNumber":
			//                dtoCollection = dtoCollection.Where(x => x.DocumentNumber.Contains(item.Value)).ToList();
			//                break;
			//            default:
			//                break;
			//        }
			//    }
			//}

			var total = dtoCollection.Count();
			dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
			var result = new GenericCollectionViewModel<AddJournalEntriesViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._JournalsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a JournalViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public JournalViewModel Get(long id)
		{
			var entity = this._JournalsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Gets a AddJournalEntriesViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AddJournalEntriesViewModel getJournalsDetails(long id)
		{
			var lang = this._languageService.CurrentLanguage;
			var entity = this._JournalsRepository.Get(id);
			var model = entity.ToAddModel();

			if (model.MovementType.HasValue)
			{
				if (model.MovementType == MovementType.BankMovement)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.BankMovement, lang].Value;
				else if (model.MovementType == MovementType.PaymentMovement)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.PaymentMovement, lang].Value;
				else if (model.MovementType == MovementType.PurchaseInvoice)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.PurchaseInvoice, lang].Value;
				else if (model.MovementType == MovementType.PurchaseRebate)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.PurchaseRebate, lang].Value;
				else if (model.MovementType == MovementType.ReceiptsMovement)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.ReceiptsMovement, lang].Value;
				else if (model.MovementType == MovementType.SalesInvoice)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.SalesInvoice, lang].Value;
				else if (model.MovementType == MovementType.SalesRebate)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.SalesRebate, lang].Value;
				else if (model.MovementType == MovementType.StoreMovement)
					model.MovementTypeName = this._resourcesService[ResourceKeyEnum.StoreMovement, lang].Value;
			}

			return model;
		}
		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<JournalViewModel> Add(IEnumerable<JournalViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalsRepository.Add(entityCollection).ToList();

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
		public JournalViewModel Add(JournalViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();

			entity = this._JournalsRepository.Add(entity);

			#region Commit Changes;
			this._unitOfWork.Commit();
			entity.Code = entity.Id.ToString();
			this._JournalsRepository.Update(entity);
			this._unitOfWork.Commit();

			#endregion

			model = entity.ToModel();
			return model;
		}

		public AddJournalEntriesViewModel AddJournal(AddJournalEntriesViewModel model, PostingStatus postingStatus = PostingStatus.Approved)
		{
			var journalDetails = model.journalDetails;

			//if (journalDetails.Count % 2 == 0)
			//{
				var credit = journalDetails.Where(z => z.IsCreditor == true).Select(x => x.CreditorValue).Sum();
				var debt = journalDetails.Where(z => z.IsCreditor == false).Select(x => x.DebtorValue).Sum();

				if ((credit - debt) != 0)
				{
					throw new GeneralException((int)ErrorCodeEnum.JournalNotbalanced);
				}
			//}
			//else
			//{
				//throw new GeneralException((int)ErrorCodeEnum.JournalNotbalanced);
			//}

			foreach (var item in model.journalDetails)
			{
				if (item.IsCreditor)
				{
					item.Amount = item.CreditorValue;
				}
				else
				{
					item.Amount = item.DebtorValue;
				}
			}

			DateTime CurrentDate = DateTime.Now;
			var entity = model.ToEntity();
			entity.PostingStatus = postingStatus;

			#region translation
			entity.Description = "";
			entity.CreationDate = CurrentDate;
			entity.Code = model.DocumentNumber;
			entity.Date = model.Date;
			entity.Language = Language.None;

			Journal JournalAr = new Journal();
			JournalAr.Description = model.DescriptionAr;
			JournalAr.Language = Language.Arabic;
			JournalAr.CreationDate = CurrentDate;
			JournalAr.Date = model.Date;
			JournalAr.FirstModificationDate = model.Date;
			JournalAr.LastModificationDate = model.Date;


			Journal JournalEn = new Journal();
			JournalEn.Description = model.DescriptionEn;
			JournalEn.Language = Language.English;
			JournalEn.CreationDate = CurrentDate;
			JournalEn.Date = model.Date;
			JournalEn.FirstModificationDate = model.Date;
			JournalEn.LastModificationDate = model.Date;

			entity.ChildTranslatedJournals.Add(JournalAr);
			entity.ChildTranslatedJournals.Add(JournalEn);
			#endregion

			entity = this._JournalsRepository.Add(entity);

			//#region Commit Changes
			//this._unitOfWork.Commit();
			//#endregion

			#region Generate New Code
			long newCode = 1;
			try
			{
				ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>
				{
					Query = (entityItem =>
						entityItem.ParentKeyJournalId == null &&
						string.IsNullOrEmpty(entityItem.Code) == false),
					Order = Order.Descending
				};

				var z = this._JournalsRepository.Get(condition);
				var lastEntity = z.FirstOrDefault();

				if (lastEntity != null)
				{
					try
					{
						newCode = long.Parse(lastEntity.Code) + 1;
					}
					catch
					{
						newCode = entity.Id;
					}
				}
			}
			catch
			{
				//entity.Code = entity.Id.ToString();
			}

			entity.Code = newCode.ToString();
			//entity = this._JournalsRepository.Update(entity);

			//this._unitOfWork.Commit();
			#endregion

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			//model.DocumentNumber = entity.Id.ToString();
			model.DocumentNumber = entity.Code;

			if (entity.ReversedFromId.HasValue)
			{
				var existEntity = this._JournalsRepository.Get(entity.ReversedFromId.Value);

				existEntity.IsReversed = true;
				existEntity.ReversedToId = entity.Id;

				this._JournalsRepository.Update(existEntity);
				this._unitOfWork.Commit();
			}

			//model = entity.ToModel();
			return model;
		}






		public ApprovedRejectedCollectionViewModel ApproveAndRejectCollection(ApprovedRejectedCollectionViewModel model)
		{
			bool needCommit = false;

			if (model?.ApprovedCollection?.Count > 0)
			{
				foreach (var item in model.ApprovedCollection)
				{
					var entity = this._JournalsRepository.Get(item);

					if (entity.PostingStatus != PostingStatus.Approved)
					{
						entity.PostingStatus = PostingStatus.Approved;
						this._JournalsRepository.Update(entity);

						this.UpdateCurrentValueOfAccountChartTreeByJournal(journalId: entity.Id);
						if (needCommit == false) needCommit = true;
					}
				}
			}

			if (model?.RejectedCollection?.Count > 0)
			{
				foreach (var item in model.RejectedCollection)
				{
					var transCollection = this._transactionsRepository.Get(null).Where(x => x.JournalId == item);
					if (transCollection.Count() > 0) this._transactionsRepository.Delete(transCollection);

					var entity = this._JournalsRepository.Get(item);
					switch (entity.MovementType)
					{
						case MovementType.BankMovement:
							{
								var movement = this._bankMovementsRepository.Get(entity.ObjectId.Value);
								movement.IsPosted = false;
								movement.PostedByUserId = null;
								movement.PostingDate = null;
								this._bankMovementsRepository.Update(movement);
							}
							break;
						case MovementType.PaymentMovement:
							{
								var movement = this._paymentMovmentsRepository.Get(entity.ObjectId.Value);
								movement.IsPosted = false;
								movement.PostedByUserId = null;
								movement.PostingDate = null;
								this._paymentMovmentsRepository.Update(movement);
							}
							break;
						case MovementType.PurchaseInvoice:
							{
								var movement = this._purchaseInvoicesRepository.Get(entity.ObjectId.Value);
								movement.IsPosted = false;
								movement.PostedByUserId = null;
								movement.PostingDate = null;
								this._purchaseInvoicesRepository.Update(movement);
							}
							break;
						case MovementType.PurchaseRebate:
							{
								var movement = this._purchaseRebatesRepository.Get(entity.ObjectId.Value);
								movement.IsPosted = false;
								movement.PostedByUserId = null;
								movement.PostingDate = null;
								this._purchaseRebatesRepository.Update(movement);
							}
							break;
						case MovementType.ReceiptsMovement:
							{
								var movement = this._donationsRepository.Get(entity.ObjectId.Value);
								movement.IsPosted = false;
								movement.PostedByUserId = null;
								movement.PostingDate = null;
								this._donationsRepository.Update(movement);
							}
							break;
						case MovementType.StoreMovement:
							{

							}
							break;
						case MovementType.SalesInvoice:
							{

							}
							break;
						case MovementType.SalesRebate:
							{

							}
							break;
						default:
							break;
					}

					var journlChileds = this._JournalsRepository.Get(null).Where(x => x.ParentKeyJournalId == entity.Id);
					if (journlChileds.Count() > 0) this._JournalsRepository.Delete(journlChileds);
					this._JournalsRepository.Delete(entity);

					if (needCommit == false) needCommit = true;
				}
			}

			if (needCommit) this._unitOfWork.Commit();

			return model;
		}
		public IdCollectionViewModel<long> Approve(IdCollectionViewModel<long> model)
		{
			ApprovedRejectedCollectionViewModel viewModel = new ApprovedRejectedCollectionViewModel();
			viewModel.ApprovedCollection = model.Collection;
			this.ApproveAndRejectCollection(viewModel);

			return model;
		}
		public AddJournalEntriesViewModel Approve(AddJournalEntriesViewModel model)
		{
			var entity = this._JournalsRepository.Get(model.DocId);
			bool needCommit = false;

			if (entity.PostingStatus != PostingStatus.Approved)
			{
				entity.PostingStatus = PostingStatus.Approved;
				this._JournalsRepository.Update(entity);
				if (needCommit == false) needCommit = true;
			}


			//throw new GeneralException((int)ErrorCodeEnum.NotPurchaseInvoiceOrRebate);

			List<Transaction> transactionsList = new List<Transaction>();
			foreach (var item in model.journalDetails)
			{
				var trans = entity.Transactions.FirstOrDefault(x => x.Id == item.Id);

				if (item.AccountId > 0 && item.AccountId != trans.AccountChartId)
				{
					trans.AccountChartId = item.AccountId;
					if (needCommit == false) needCommit = true;
				}
				transactionsList.Add(trans);
			}
			this.UpdateCurrentValueOfAccountChartTreeByJournal(
				journalId: entity.Id,
				transactionList: transactionsList);


			if (needCommit) this._unitOfWork.Commit();

			return model;
		}

		public IdCollectionViewModel<long> Reject(IdCollectionViewModel<long> model)
		{
			ApprovedRejectedCollectionViewModel viewModel = new ApprovedRejectedCollectionViewModel();
			viewModel.RejectedCollection = model.Collection;
			this.ApproveAndRejectCollection(viewModel);

			return model;
		}






		public IList<AccountChart> UpdateCurrentValueOfAccountChartTreeByJournal(long journalId, List<Transaction> transactionList = null)
		{
			List<AccountChart> list = new List<AccountChart>();

			if (transactionList != null && transactionList.Count > 0)
			{
				foreach (var trans in transactionList)
				{
					if (trans.AccountChartId.HasValue == true)
					{
						AccountChart account = list.FirstOrDefault(x => x.Id == trans.AccountChartId.Value);
						if (account == null)
						{
							account = this._accountChartsRepository.Get(trans.AccountChartId.Value);
						}

						if (account != null)
						{
							if (trans.IsCreditor)
							{
								if (account.CurrentCreditBalance.HasValue == false)
									account.CurrentCreditBalance = trans.Amount;
								else
									account.CurrentCreditBalance += trans.Amount;
							}
							else
							{
								if (account.CurrentDebitBalance.HasValue == false)
									account.CurrentDebitBalance = trans.Amount;
								else
									account.CurrentDebitBalance += trans.Amount;
							}

							this._accountChartsRepository.Update(account);
							list.Add(account);

							list.AddRange(this.UpdateCurrentValueOfParentAccountChartTree(
								account.ParentAccountChartId,
								trans.Amount,
								trans.IsCreditor
								));
						}
					}
				}
			}
			else
			{
				var transCollection = this._transactionsRepository.Get(null).Where(x => x.JournalId == journalId);

				if (transCollection.Count() > 0)
				{
					foreach (var trans in transCollection)
					{
						if (trans.AccountChartId.HasValue == true)
						{
							//var account = this._accountChartsRepository.Get(trans.AccountChartId.Value);
							AccountChart account = list.FirstOrDefault(x => x.Id == trans.AccountChartId.Value);
							if (account == null)
							{
								account = this._accountChartsRepository.Get(trans.AccountChartId.Value);
							}

							if (account != null)
							{
								if (trans.IsCreditor)
								{
									if (account.CurrentCreditBalance.HasValue == false)
										account.CurrentCreditBalance = trans.Amount;
									else
										account.CurrentCreditBalance += trans.Amount;
								}
								else
								{
									if (account.CurrentDebitBalance.HasValue == false)
										account.CurrentDebitBalance = trans.Amount;
									else
										account.CurrentDebitBalance += trans.Amount;
								}

								this._accountChartsRepository.Update(account);
								list.Add(account);

								list.AddRange(this.UpdateCurrentValueOfParentAccountChartTree(
									account.ParentAccountChartId,
									trans.Amount,
									trans.IsCreditor
									));
							}
						}
					}
				}
			}

			return list;
		}

		public IList<AccountChart> UpdateCurrentValueOfParentAccountChartTree(long? parentAccountChartId, decimal amount, bool isCreditor)
		{
			List<AccountChart> list = new List<AccountChart>();

			AccountChart parentAccountChart = list.FirstOrDefault(x => x.Id == parentAccountChartId);
			if (parentAccountChart == null)
			{
				parentAccountChart = this._accountChartsRepository
					.Get(null)
					.Where(x => x.Id == parentAccountChartId)
					.FirstOrDefault();
			}

			if (parentAccountChart != null)
			{
				if (isCreditor)
				{
					if (parentAccountChart.CurrentCreditBalance.HasValue == false)
						parentAccountChart.CurrentCreditBalance = amount;
					else
						parentAccountChart.CurrentCreditBalance += amount;
				}
				else
				{
					if (parentAccountChart.CurrentDebitBalance.HasValue == false)
						parentAccountChart.CurrentDebitBalance = amount;
					else
						parentAccountChart.CurrentDebitBalance += amount;
				}

				this._accountChartsRepository.Update(parentAccountChart);
				list.Add(parentAccountChart);

				if (parentAccountChart.ParentAccountChartId.HasValue)
				{
					list.AddRange(this.UpdateCurrentValueOfParentAccountChartTree(parentAccountChart.ParentAccountChartId, amount, isCreditor));
				}
			}
			//else
			//{

			//}

			return list;
		}




		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<JournalViewModel> Update(IEnumerable<JournalViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalsRepository.Update(entityCollection).ToList();

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
		public AddJournalEntriesViewModel Update(AddJournalEntriesViewModel model)
		{
			//this.ThrowExceptionIfExist(model);

			var entity = this._JournalsRepository.Get().FirstOrDefault(x => x.Id == model.Id);
			var entityAr = entity.ChildTranslatedJournals.FirstOrDefault(x => x.Language == Language.Arabic);
			entityAr.Description = model.DescriptionAr;
			var entityEn = entity.ChildTranslatedJournals.FirstOrDefault(x => x.Language == Language.English);
			entityEn.Description = model.DescriptionEn;
			this._JournalsRepository.Update(entityAr);
			this._JournalsRepository.Update(entityEn);

			for (int i = 0; i < entity.Transactions.Count; i++)
			{
				var id = entity.Transactions.ToArray()[i].Id;
				var tran = this._transactionsRepository.Get().FirstOrDefault(x => x.Id == id);
				tran.AccountChartId = model.journalDetails.ToArray()[i].AccountId;
				tran.CostCenterId = model.journalDetails.ToArray()[i].CostCenterId;
				tran.DescriptionAR = model.journalDetails.ToArray()[i].DescriptionAr;
				tran.DescriptionEN = model.journalDetails.ToArray()[i].DescriptionEn;
				this._transactionsRepository.Update(tran);
			}

			entity = this._JournalsRepository.Update(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToAddModel();
			return model;
		}

		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<JournalViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._JournalsRepository.Delete(entityCollection);

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
			this._JournalsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(JournalViewModel model)
		{
			var entity = model.ToEntity();
			this._JournalsRepository.Delete(entity);

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
			var result = this._JournalsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		#endregion
	}
}
