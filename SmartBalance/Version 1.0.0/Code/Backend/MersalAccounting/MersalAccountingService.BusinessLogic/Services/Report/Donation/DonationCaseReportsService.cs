#region Using ...
using Framework.Common.Enums;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using MersalAccountingService.Common.Enums;
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
    public class DonationCaseReportsService : IDonationCaseReportsService
    {
        #region Data Members
        private readonly IResourcesService _resourcesService;
        private readonly IDonationsRepository _donationsRepository;
        private readonly IDonationCasesRepository _donationCasesRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISettingsService _settingsService;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionsService.
        /// </summary>      
        /// <param name="unitOfWork"></param>
        public DonationCaseReportsService(
            IResourcesService resourcesService,
            IDonationsRepository donationsRepository,
            IDonationCasesRepository donationCasesRepository,
            ICurrentUserService currentUserService,
            ISettingsService settingsService,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._resourcesService = resourcesService;
            this._donationsRepository = donationsRepository;
            this._donationCasesRepository = donationCasesRepository;
            this._currentUserService = currentUserService;
            this._settingsService = settingsService;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public IList<DonatorCasesHistoryReportViewModel> GetDonatorCasesHistoryReport(long? donatorId, DateTime? DateFrom, DateTime? DateTo)
        {
            List<DonatorCasesHistoryReportViewModel> list = new List<DonatorCasesHistoryReportViewModel>();

            var entitysQuerable = this._donationCasesRepository.Get().Where(x =>
                x.Donation.ParentKeyDonationId == null &&
                x.Donation.DonationDonators.Count > 0);

            if (donatorId.HasValue)
                entitysQuerable = entitysQuerable.Where(x => x.Donation.DonationDonators.Any(c => c.DonatorId == donatorId));

            if (DateFrom.HasValue)
                entitysQuerable = entitysQuerable.Where(x => x.Donation.Date >= DateFrom);

            if (DateTo.HasValue)
            {
                DateTo = DateTo.SetTimeToMax();
                entitysQuerable = entitysQuerable.Where(x => x.Donation.Date <= DateTo);
            }

            var entitys = entitysQuerable.ToList();

            foreach (var item in entitys)
            {

                DonatorCasesHistoryReportViewModel row = new DonatorCasesHistoryReportViewModel
                {
                    Amount = item.Amount,
                    ExternalId = item.Case.ExternalId,
                    CaseName = item.Case.Name,
                    Date = item.Donation.Date,
                    //DonatorId = item.Donation.DonatorId,
                    //DonatorName = item.Donation.Donator.Name
                    //DateFrom = DateFrom,
                    //DateTo = DateTo
                };

                list.Add(row);
            }

            return list;
        }

        public IList<DonationCasesBalanceReportViewModel> GetDonationCasesBalanceReport(long? caseId, DateTime? DateFrom, DateTime? DateTo)
        {
            List<DonationCasesBalanceReportViewModel> list = new List<DonationCasesBalanceReportViewModel>();

            var entitysQuerable = this._donationCasesRepository.Get(null).Where(x =>
                 x.Donation.ParentKeyDonationId == null);

            if(caseId.HasValue)
                entitysQuerable = entitysQuerable.Where(x => x.Case.ExternalId == caseId.ToString());

            if (DateFrom.HasValue)
                entitysQuerable = entitysQuerable.Where(x => x.Donation.Date >= DateFrom);

            if (DateTo.HasValue)
            {
                DateTo = DateTo.SetTimeToMax();
                entitysQuerable = entitysQuerable.Where(x => x.Donation.Date <= DateTo);
            }

            var entitys = entitysQuerable.ToList();

            foreach (var item in entitys)
            {
                DonationCasesBalanceReportViewModel row = list.Where(x => 
                    x.ExternalId == item.Case.ExternalId).FirstOrDefault();

                if (row == null)
                {
                    row = new DonationCasesBalanceReportViewModel
                    {
                        TotalAmount = item.Amount,
                        ExternalId = item.Case.ExternalId,
                        CaseName = item.Case.Name,
                        //DateFrom = DateFrom,
                        //DateTo = DateTo
                    };

                    list.Add(row);
                }
                else
                {
                    row.TotalAmount += item.Amount;                  
                }
            }

            return list;
        }
        #endregion
    }
}
