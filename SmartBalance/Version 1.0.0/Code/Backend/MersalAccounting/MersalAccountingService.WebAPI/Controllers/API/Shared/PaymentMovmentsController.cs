#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.PaymentMovment;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	/// <summary>
	/// PaymentMovments Controller
	/// </summary>
	[RoutePrefix("api/PaymentMovments")]
	public class PaymentMovmentsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IPaymentMovmentsService _PaymentMovmentsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PaymentMovmentController.
		/// </summary>
		/// <param name="PaymentMovmentsService">The injected service.</param>
		public PaymentMovmentsController(IPaymentMovmentsService PaymentMovmentsService)
		{
			this._PaymentMovmentsService = PaymentMovmentsService;
		}
        #endregion

        #region Actions

#if conditions
        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get-by-condition 
		 */
		public GenericCollectionViewModel<PaymentMovmentViewModel> Get(ConditionFilter<PaymentMovment, long> condition)
		{
			var result = this._PaymentMovmentsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PaymentMovmentViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PaymentMovmentsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PaymentMovmentLightViewModel> GetLightModel(ConditionFilter<PaymentMovment, long> condition)
		{
			var result = this._PaymentMovmentsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PaymentMovmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PaymentMovmentsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PaymentMovmentViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get/1 
		 */
		public PaymentMovmentViewModel Get(long id)
		{
			var result = this._PaymentMovmentsService.Get(id);
			return result;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/add-collection 
		 */
		public IList<PaymentMovmentViewModel> Add([FromBody]IEnumerable<PaymentMovmentViewModel> collection)
		{
			var result = this._PaymentMovmentsService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
        ///
#endif
        /// <summary>
        /// Gets a PaymentMovmentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
		[JwtAuthentication(Permissions.PaymentsMovementsList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get/1 
		 */
		public AddPaymentMovmentViewModel Get(long id)
        {
            var result = this._PaymentMovmentsService.Get(id);
            return result;
        }

        [Route("get-payment-codes")]
        [HttpGet]
        public List<string> GetPaymentCodes()
        {
            var result = this._PaymentMovmentsService.GetPaymentCodes();
            return result;
        }

        /// <summary>
        /// aDD a AddPaymentMovmentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddPaymentsMovements)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/add 
		 */
		public AddPaymentMovmentViewModel AddPaymentMovmentViewModel([FromBody]AddPaymentMovmentViewModel model)
        {
            var result = this._PaymentMovmentsService.Add(model);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}/{BranchId?}/{dateFrom?}/{dateTo?}/{amountFrom?}/{amountTo?}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize, int? BranchId,
             DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo)
        {
            var result = this._PaymentMovmentsService.GetLightModel(pageIndex, pageSize, BranchId,dateFrom, dateTo,
                amountFrom, amountTo);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListDonationLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
		[JwtAuthentication(Permissions.PaymentsMovementsList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/get-with-filter 
		 */
		public GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetByFilter([FromBody]FinancialViewModel model)
        {
            var result = this._PaymentMovmentsService.GetReceiptModel(model);
            return result;
        }

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditPaymentsMovements)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/update 
		 */
		public AddPaymentMovmentViewModel Update([FromBody]AddPaymentMovmentViewModel model)
		{
			var result = this._PaymentMovmentsService.Update(model);
			return result;
		}

        [Route("generate-new-recipt-number")]
        [HttpPost]      
        public string GenerateNewReciptNumber()
        {
            var result = this._PaymentMovmentsService.GenerateNewReciptNumber();
            return result;
        }

#if conditions2
        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
		[HttpPost]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/update-collection 
		 */
		public IList<PaymentMovmentViewModel> Update([FromBody]IEnumerable<PaymentMovmentViewModel> collection)
		{
			var result = this._PaymentMovmentsService.Update(collection);
			return result;
		}


		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PaymentMovmentViewModel> collection)
		{
			this._PaymentMovmentsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PaymentMovmentsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/delete 
		 */
		public void Delete([FromBody]PaymentMovmentViewModel model)
		{
			this._PaymentMovmentsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMovments/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMovments/delete/1 
		 */
		public void Delete(long id)
		{
			this._PaymentMovmentsService.Delete(id);
		}
#endif

		#endregion
	}
}
