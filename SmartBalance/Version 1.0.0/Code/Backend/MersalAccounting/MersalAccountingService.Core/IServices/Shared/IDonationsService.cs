#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDonationsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(DonationViewModel model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetByFilter(ChecksUnderCollectionFilterViewModel model);

        GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecksByBank(long bankId, bool exchangeable = false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecksUnderCollection(int? pageIndex, int? pageSize);
             
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<ChecksUnderCollectionViewModel> UpdateCollectionOfCheckUnderCollection(IList<ChecksUnderCollectionLightViewModel> model);




        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DonationViewModel> Get(ConditionFilter<Donation, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DonationViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonationLightViewModel> GetLightModel(ConditionFilter<Donation, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListDonationLightViewModel> GetLightModel(int? pageIndex, int? pageSize,
            int?branchId,DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo);


        /// <summary>
		/// Gets a GenericCollectionViewModel of DonationLightViewModel by pagination.
		/// </summary>
		/// <returns></returns>
		GenericCollectionViewModel<ListDonationLightViewModel> GetReceiptModel(FinancialViewModel model);


        /// <summary>
        /// Gets a DonationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DetailsDonationViewModel Get(long id);


        DonationInvoiceViewModel DonationInvoice(int Id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		DonationViewModel GetById(long id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<DonationViewModel> Add(IEnumerable<DonationViewModel> collection);
    
        
        /// <summary>
        /// This Service Used to add external 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        long AddExternalDonation(AddExternalDonationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        void MakeAddTransactions(Donation model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		AddDonationViewModel Add(AddDonationViewModel model);

        void SaveNewDonatorData(AddDonatorViewModel donator, long Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DonationViewModel> Update(IEnumerable<DonationViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		AddDonationViewModel Update(AddDonationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<DonationViewModel> collection);
        AddDonationViewModel GetDetailsById(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(DonationViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
