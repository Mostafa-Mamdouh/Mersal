#region Using ...
using Framework.Common.Enums;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides JournalPosting service for 
    /// business functionality.
    /// </summary>
    public class ReportsService : IReportsService
    {
        #region Data Members
        private readonly IBankMovementsRepository _bankMovementsRepository;
        private readonly IPaymentMovmentsRepository _paymentMovmentsRepository;
        private readonly IPurchaseInvoicesRepository _purchaseInvoicesRepository;
        private readonly IPurchaseRebatesRepository _purchaseRebatesRepository;
        private readonly IDonationsRepository _donationsRepository;
        private readonly ISalesBillRepository _salesBillRepository;
        private readonly ISalesRebatesRepository _salesRebatesRepository;
        // private readonly IStoreMovementsRepository _storeMovementsRepository;
        private readonly IInventoryMovementsRepository _inventoryMovementsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISettingsService _settingsService;
        private readonly IJournalsRepository _JournalsRepository;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly ISafesRepository _safesRepository;
        private readonly IBanksRepository _banksRepository;

        private readonly IJournalPostingsRepository _JournalPostingsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type JournalPostingsService.
        /// </summary>
        /// <param name="bankMovementsRepository"></param>
        /// <param name="paymentMovmentsRepository"></param>
        /// <param name="purchaseInvoicesRepository"></param>
        /// <param name="purchaseRebatesRepository"></param>
        /// <param name="donationsRepository"></param>
        /// <param name="salesBillRepository"></param>
        /// <param name="salesRebatesRepository"></param>
        /// <param name="currentUserService"></param>
        /// <param name="inventoryMovementsRepository"></param>
        /// <param name="settingsService"></param>
        /// <param name="JournalsRepository"></param>
        /// <param name="JournalPostingsRepository"></param>
        /// <param name="languageService"></param>
        /// <param name="unitOfWork"></param>
        public ReportsService(
            IBankMovementsRepository bankMovementsRepository,
            IPaymentMovmentsRepository paymentMovmentsRepository,
            IPurchaseInvoicesRepository purchaseInvoicesRepository,
            IPurchaseRebatesRepository purchaseRebatesRepository,
            IDonationsRepository donationsRepository,
            ISalesBillRepository salesBillRepository,
            ISalesRebatesRepository salesRebatesRepository,
            //IStoreMovementsRepository storeMovementsRepository,
            ICurrentUserService currentUserService,
            IInventoryMovementsRepository inventoryMovementsRepository,
            ISettingsService settingsService,
            IJournalsRepository JournalsRepository,
            IVendorsRepository vendorsRepository,
            ISafesRepository safesRepository,
            IBanksRepository banksRepository,

            IJournalPostingsRepository JournalPostingsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._bankMovementsRepository = bankMovementsRepository;
            this._paymentMovmentsRepository = paymentMovmentsRepository;
            this._purchaseInvoicesRepository = purchaseInvoicesRepository;
            this._purchaseRebatesRepository = purchaseRebatesRepository;
            this._donationsRepository = donationsRepository;
            this._salesBillRepository = salesBillRepository;
            this._salesRebatesRepository = salesRebatesRepository;
            //this._storeMovementsRepository = storeMovementsRepository;
            this._currentUserService = currentUserService;
            this._inventoryMovementsRepository = inventoryMovementsRepository;
            this._settingsService = settingsService;
            this._JournalsRepository = JournalsRepository;
            this._vendorsRepository = vendorsRepository;
            this._safesRepository = safesRepository;
            this._banksRepository = banksRepository;

            this._JournalPostingsRepository = JournalPostingsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeReport(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> data = new List<AccountsReportViewModel>();

            if (true)
            {
                var posted = this.SafeBankMovement(SafeId, DateFrom, DateTo);
                data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafePaymentMovement(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafePurchaseInvoice(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafePurchaseRebate(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafeReceiptsMovement(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafeSalesInvoice(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafeSalesRebate(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }
            if (true)
            {
                var posted = this.SafeStoreMovement(SafeId, DateFrom, DateTo);
                 data.AddRange(posted);
            }

            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeBankMovement(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();
            var safe = this._safesRepository.Get(SafeId);
            ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
            {
                Query = (x => x.ParentKeyBankMovementId.HasValue == false &&
                              x.Date <= DateTo &&
                              x.Date >= DateFrom &&
                              x.SafeId == SafeId)
            };           
            var sourceEntities = this._bankMovementsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                 foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                       safeReport.Code = source.Code;
                       safeReport.Name = safe.Name;
                       safeReport.MovementType = "حركة بنوك";
                       safeReport.Description = source.Description;
                       safeReport.FullCode = safe.Code;
                       safeReport.CreationDate = source.CreationDate;
                       //safeReport.CreditorValue = source.Amount;
                       safeReport.DebtorValue = source.Amount;
                       list.Add(safeReport);
                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafePaymentMovement(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();
            var safe = this._safesRepository.Get(SafeId);
            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            {
                Query = (x => x.ParentKeyPaymentMovmentId.HasValue == false &&
                              x.Date <= DateTo &&
                              x.Date >= DateFrom &&
                              x.SafeId == SafeId)
            };
           
            var sourceEntities = this._paymentMovmentsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                    safeReport.Code = source.Code;
                    safeReport.Name = safe.Name;
                    safeReport.MovementType = "حركة المدفوعات";
                    safeReport.Description = source.Description;
                    safeReport.FullCode = safe.Code;
                    safeReport.CreationDate = source.CreationDate;
                    safeReport.CreditorValue = source.Amount;
                    list.Add(safeReport);                
                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafePurchaseInvoice(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();
            var safe = this._safesRepository.Get(SafeId);
            ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
            {
                Query = (x => x.Date <= DateTo &&
                              x.Date >= DateFrom &&
                              x.SafeId == SafeId)
            };            
            var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {                
                foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                    safeReport.Code = source.Code;
                    safeReport.Name = safe.Name;
                    safeReport.MovementType = "فاتورة الشراء";
                    safeReport.Description = "";
                    safeReport.FullCode = safe.Code;
                    safeReport.CreationDate = source.CreationDate;
                    safeReport.CreditorValue = source.NetAmount;
                    list.Add(safeReport);
                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafePurchaseRebate(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();
            var safe = this._safesRepository.Get(SafeId);
            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                Query = (x => x.Date <= DateTo &&
                              x.Date >= DateFrom &&
                              x.SafeId == SafeId)
            };            
            var sourceEntities = this._purchaseRebatesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                    safeReport.Code = source.Code;
                    safeReport.Name = safe.Name;
                    safeReport.MovementType = "فاتورة الشراء";
                    safeReport.Description = "";
                    safeReport.FullCode = safe.Code;
                    safeReport.CreationDate = source.CreationDate;
                    safeReport.DebtorValue = source.NetAmount;
                    list.Add(safeReport);

                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeReceiptsMovement(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();
            var safe = this._safesRepository.Get(SafeId);
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (x => x.ParentKeyDonationId.HasValue == false &&
                              x.Date <= DateTo &&
                              x.Date >= DateFrom &&
                              x.SafeId == SafeId)
            };
            var sourceEntities = this._donationsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                    safeReport.Code = source.Code;
                    safeReport.Name = safe.Name;
                    safeReport.MovementType = "فاتورة الشراء";
                    safeReport.Description = source.Description;
                    safeReport.FullCode = safe.Code;
                    safeReport.CreationDate = source.CreationDate;
                    safeReport.DebtorValue = source.Amount;
                    list.Add(safeReport);

                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeSalesInvoice(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeSalesRebate(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="IsAutomaticPosting"></param>
        /// <param name="IsBulkPosting"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeStoreMovement(long SafeId, DateTime DateFrom, DateTime DateTo)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();

            return list;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns></returns>
        public IList<AccountsReportViewModel> SafeChecksUnderCollectionOfReceiptsMovement(IList<long> idCollection)
        {
            List<AccountsReportViewModel> list = new List<AccountsReportViewModel>();

            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (x => x.IsPosted &&
                              x.ParentKeyDonationId.HasValue == false &&
                              idCollection.Any(item => item == x.Id))
            };

            var sourceEntities = this._donationsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                var userId = this._currentUserService.CurrentUserId;
                var financialSetting = this._settingsService.GetFinancialSetting();
                foreach (var source in sourceEntities)
                {
                    AccountsReportViewModel safeReport = new AccountsReportViewModel();
                    safeReport.Code = source.Code;
                    safeReport.Name = source.Safe.Name;
                    safeReport.MovementType = "فاتورة الشراء";
                    safeReport.Description = source.Description;
                    safeReport.FullCode = source.Safe.Code;
                    safeReport.CreationDate = source.CreationDate;
                    safeReport.DebtorValue = source.Amount;
                    list.Add(safeReport);
                }

               
            }

            return list;
        }


        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">JournalPosting view model</param>
        public void ThrowExceptionIfExist(JournalPostingViewModel model)
        {
            //ConditionFilter<JournalPosting, long> condition = new ConditionFilter<JournalPosting, long>
            //{
            //    Query = (entity =>
            //        entity.Name == model.Name &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._JournalPostingsRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException();
        }

    
        #endregion
    }
}
