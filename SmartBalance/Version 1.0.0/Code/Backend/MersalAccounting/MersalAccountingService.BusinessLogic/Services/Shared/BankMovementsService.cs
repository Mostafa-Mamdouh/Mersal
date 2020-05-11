#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides BankMovement service for 
	/// business functionality.
	/// </summary>
	public class BankMovementsService : IBankMovementsService
	{
		#region Data Members
		private readonly ITransactionsRepository _transactionsRepository;
		private readonly IJournalsRepository _journalsRepository;
		private readonly IJournalPostingsService _journalPostingsService;
		private readonly IBankMovementsRepository _BankMovementsRepository;
		private readonly IClosedMonthsService _closedMonthsService;
		private readonly ICurrentUserService _currentUserService;
		private readonly IClosedChequeRepository _closedChequeRepository;
		private readonly IDonationsService _donationsService;
		private readonly IDonationsRepository _donationsRepository;
		private readonly IAccountChartsRepository _accountChartsRepository;
		private readonly IJournalsService _journalsService;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBankMovementCostCentersRepository _bankMovementCostCentersRepository;

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankMovementsService.
		/// </summary>
		/// <param name="BankMovementsRepository"></param>
		/// <param name="currentUserService"></param>
		/// <param name="languageService"></param>
		/// <param name="unitOfWork"></param>
		public BankMovementsService(
			ITransactionsRepository transactionsRepository,
			IJournalsRepository journalsRepository,
			IJournalPostingsService journalPostingsService,
			IBankMovementsRepository BankMovementsRepository,
			IClosedMonthsService closedMonthsService,
			ICurrentUserService currentUserService,
			IClosedChequeRepository closedChequeRepository,
			IDonationsService donationsService,
			IDonationsRepository donationsRepository,
			IAccountChartsRepository accountChartsRepository,
			IJournalsService journalsService,
			ILanguageService languageService,
			IBankMovementCostCentersRepository bankMovementCostCentersRepository,
			IUnitOfWork unitOfWork)
		{
			this._transactionsRepository = transactionsRepository;
			this._journalsRepository = journalsRepository;
			this._journalPostingsService = journalPostingsService;
			this._BankMovementsRepository = BankMovementsRepository;
			this._closedMonthsService = closedMonthsService;
			this._currentUserService = currentUserService;
			this._closedChequeRepository = closedChequeRepository;
			this._donationsService = donationsService;
			this._donationsRepository = donationsRepository;
			this._accountChartsRepository = accountChartsRepository;
			this._journalsService = journalsService;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
			this._bankMovementCostCentersRepository = bankMovementCostCentersRepository;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">BankMovement view model</param>
		public void ThrowExceptionIfExist(BankMovementViewModel model)
		{
			//ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			//{
			//	Query = (entity =>
			//		entity.Code == model.Code &&
			//		entity.Id != model.Id)
			//};
			//var existEntity = this._BankMovementsRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//	throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BankMovementViewModel> Get(ConditionFilter<BankMovement, long> condition)
		{
			var entityCollection = this._BankMovementsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BankMovementViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._BankMovementsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BankMovementLightViewModel> GetLightModel(ConditionFilter<BankMovement, long> condition)
		{
			var entityCollection = this._BankMovementsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BankMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._BankMovementsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a BankMovementViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public BankMovementViewModel Get(long id)
		{



			var entity = this._BankMovementsRepository.Get(id);
			var model = entity.ToModel();

			ConditionFilter<BankMovementCostCenters, long> condition = new ConditionFilter<BankMovementCostCenters, long>
			{

				Query = (item =>
					item.BankMovementId == id)
			};

			var movementCostCenters = _bankMovementCostCentersRepository.Get(condition).ToList();
			if (movementCostCenters.Any())
			{
				model.CostCenters = movementCostCenters.Select(x => x.ToModel()).ToList();
			}


			if (model.JournalTypeId == 13)
			{
				var bankMovements = this._closedChequeRepository.Get().Where(x => x.BankMovementId == id);
				model.Cheques = this._donationsRepository.Get().Where(x => bankMovements.Any(c => c.DonationId == x.Id)).ToList().Select(x => x.ToChecksUnderCollectionModel()).ToList();
			}

			if (entity.ChildTranslatedBankMovements != null)
			{
				model.DescriptionAr = entity.ChildTranslatedBankMovements.FirstOrDefault(e =>
					e.Language == Framework.Common.Enums.Language.Arabic).Description;

				model.DescriptionEn = entity.ChildTranslatedBankMovements.FirstOrDefault(e =>
					e.Language == Framework.Common.Enums.Language.English).Description;
			}

			return model;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ListBankMovementsLightViewModel> GetByFilter(BankMovementFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			//if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

			IQueryable<BankMovement> queryableData = this._BankMovementsRepository.Get(condition);


			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBankMovement != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.Code.Contains(model.Code));

			if (model.Bank.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.BankId == model.Bank);

			if (model.AmountFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.Amount >= model.AmountFrom);

			if (model.AmountTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.Amount <= model.AmountTo);

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.Date >= model.DateFrom);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.Date <= model.DateTo);

			if (model.JournalType.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBankMovement.JournalTypeId == model.JournalType);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			foreach (var item in entityCollection)
			{
				var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBankMovementId);
				//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
				if (item.ParentKeyBankMovement.Bank != null)
				{
					ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
				}
				if (item.ParentKeyBankMovement.JournalType != null)
				{
					ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
				}
			}

			var total = dtoCollection.Count();
			dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
			var result = new GenericCollectionViewModel<ListBankMovementsLightViewModel>
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
		public IList<BankMovementViewModel> Add(IEnumerable<BankMovementViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BankMovementsRepository.Add(entityCollection).ToList();

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
		public BankMovementViewModel Add(BankMovementViewModel model)
		{
			if (model.Journal == null)
			{
				this.ThrowExceptionIfExist(model);
				this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

				var entity = model.ToEntity();

				if (entity.JournalTypeId == (long)JournalTypeEnum.PaymentPapers)
				{
					IList<long> list = new List<long>();
					foreach (var item in model.Cheques)
					{
						ClosedCheque closedCheque = new ClosedCheque
						{
							BankMovement = entity,
							DonationId = item.Id
						};
						this._closedChequeRepository.Add(closedCheque);
						var donationEntity = this._donationsRepository.Get(item.Id);

						//TODO:
						//if (donationEntity.IsPosted) 
						//{
						donationEntity.Exchangeable = true;
						list.Add(entity.Id);
						//}



						donationEntity = this._donationsRepository.Update(donationEntity);
					}

					this._journalPostingsService.PostChecksUnderCollectionOfReceiptsMovement(list);

				}

				entity.CreatedByUserId = this._currentUserService.CurrentUserId;
				DateTime now = DateTime.Now;
				var ar = new BankMovement
				{
					Description = model.DescriptionAr,
					Language = Language.Arabic,
					CreationDate = now
				};
				var en = new BankMovement
				{
					Description = model.DescriptionEn,
					Language = Language.English,
					CreationDate = now
				};

				entity.ChildTranslatedBankMovements.Add(ar);
				entity.ChildTranslatedBankMovements.Add(en);





				entity = this._BankMovementsRepository.Add(entity);






				#region Commit Changes
				this._unitOfWork.Commit();
				#endregion

				//entity.Code = entity.Id.ToString();
				//#region Commit Changes
				//this._unitOfWork.Commit();
				//#endregion

				//this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.BankMovement);
				if (entity.JournalTypeId == (long)JournalTypeEnum.DirectDonations &&
					model.CostCenters != null &&
					model.CostCenters.Any())
				{
					foreach (var item in model.CostCenters)
					{
						var bankMovementCosCenter = new BankMovementCostCenters()
						{
							BankMovementId = entity.Id,
							CostCenterId = item.Id,
							Amount = (double)item.AssignValue

						};

						_bankMovementCostCentersRepository.Add(bankMovementCosCenter);
						#region Commit Changes
						this._unitOfWork.Commit();
						#endregion

					}

				}

				model = entity.ToModel();
				model.Journal = this._journalPostingsService.Post(model.Id, MovementType.BankMovement);

				model.Journal.Date = model.Date.Value;

				foreach (var Journal in model.Journal.journalDetails)
				{
					Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
				}
				//model.Journal.DescriptionAr = model.DescriptionAr;
				//model.Journal.DescriptionEn = model.DescriptionEn;
			}
			else if (model.Journal.PostingStatus == PostingStatus.Approved)
			{
				this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);

				var entity = this._BankMovementsRepository.Get(model.Id);
				entity.IsPosted = false;
				entity.PostingDate = DateTime.Now;
				entity.PostedByUserId = this._currentUserService.CurrentUserId;
				entity = this._BankMovementsRepository.Update(entity);
				this._unitOfWork.Commit();
			}
			else if (model.Journal.PostingStatus == PostingStatus.Rejected)
			{

			}

			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<BankMovementViewModel> Update(IEnumerable<BankMovementViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BankMovementsRepository.Update(entityCollection).ToList();

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
		public BankMovementViewModel Update(BankMovementViewModel model)
		{
			this.ThrowExceptionIfExist(model);
			this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

			var entity = this._BankMovementsRepository.Get(model.Id);

			entity.AccountChartId = model.AccountChartId;
			entity.Amount = model.Amount;
			entity.BankId = model.BankId;
			entity.Code = model.Code;
			entity.Date = model.Date;
			entity.JournalTypeId = model.JournalTypeId;
			entity.SafeId = model.SafeId;
			entity.ToBankId = model.ToBankId;

			var ar = entity.ChildTranslatedBankMovements.FirstOrDefault(e => e.Language == Framework.Common.Enums.Language.Arabic);
			var en = entity.ChildTranslatedBankMovements.FirstOrDefault(e => e.Language == Framework.Common.Enums.Language.English);

			ar.Description = model.DescriptionAr;
			en.Description = model.DescriptionEn;

			var userId = this._currentUserService.CurrentUserId;
			if (entity.FirstModifiedByUserId == null)
				entity.FirstModifiedByUserId = userId;
			else
				entity.LastModifiedByUserId = userId;

			entity = this._BankMovementsRepository.Update(entity);

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
		public void Delete(IEnumerable<BankMovementViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._BankMovementsRepository.Delete(entityCollection);

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
			this._BankMovementsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(BankMovementViewModel model)
		{
			var entity = model.ToEntity();
			this._BankMovementsRepository.Delete(entity);

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
			var result = this._BankMovementsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
