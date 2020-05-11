#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.PaymentMovment;
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
    public interface IPaymentMovmentsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(PaymentMovmentViewModel model);

        void ValidateAddViewModel(AddPaymentMovmentViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize, int? branchId
            , DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo);

        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentLightViewModel by pagination.
        /// </summary>
        /// <returns></returns>
        GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetReceiptModel(FinancialViewModel model);

        AddPaymentMovmentViewModel Get(long id);

        List<string> GetPaymentCodes();
		AddPaymentMovmentViewModel Update(AddPaymentMovmentViewModel model);
#if Condition
        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PaymentMovmentViewModel> Get(ConditionFilter<PaymentMovment, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PaymentMovmentViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PaymentMovmentLightViewModel> GetLightModel(ConditionFilter<PaymentMovment, long> condition);


        List<PaymentMovmentLightViewModel> GetLookUp();

        /// <summary>
        /// Gets a PaymentMovmentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PaymentMovmentViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PaymentMovmentViewModel> Add(IEnumerable<PaymentMovmentViewModel> collection);
#endif
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		AddPaymentMovmentViewModel Add(AddPaymentMovmentViewModel model);
        string GenerateNewReciptNumber();

        //void PaymentMovmentAddTransAction(PaymentMovment model);
#if condtionMethodCompleted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PaymentMovmentViewModel> Update(IEnumerable<PaymentMovmentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PaymentMovmentViewModel Update(PaymentMovmentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<PaymentMovmentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(PaymentMovmentViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
#endif
        #endregion
    }
}
