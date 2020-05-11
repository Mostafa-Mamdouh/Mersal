#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
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
	/// Donations Controller
	/// </summary>
	[RoutePrefix("api/Donations")]
	public class DonationsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IDonationsService _DonationsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DonationController.
		/// </summary>
		/// <param name="DonationsService">The injected service.</param>
		public DonationsController(IDonationsService DonationsService)
		{
			this._DonationsService = DonationsService;
		}
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListPurchasLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-checks-under-collection-with-filter")]
        [HttpPost]
		[JwtAuthentication(Permissions.ControlChecksUnderCollection)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PurchaseInvoices/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PurchaseInvoices/get-with-filter 
		 */
		public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetByFilter([FromBody]ChecksUnderCollectionFilterViewModel model)
        {
            var result = this._DonationsService.GetByFilter(model);
            return result;
        }

        [Route("get-checks-by-bank/{bankId}")]
        [HttpGet]
        public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecks(long bankId)
        {
            return this._DonationsService.GetChecksByBank(bankId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-checks-under-collection-by-pagger")]
        [HttpGet]
		[JwtAuthentication(Permissions.ControlChecksUnderCollection)]
		public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecksUnderCollection(int? pageIndex, int? pageSize)
        {
            var result = this._DonationsService.GetChecksUnderCollection(pageIndex, pageSize);
            return result;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[Route("update-check-under-collection")]
        //[HttpPost]
        //public ChecksUnderCollectionViewModel UpdateCheckUnderCollection(ChecksUnderCollectionViewModel model)
        //{
        //    var result = this._DonationsService.UpdateCheckUnderCollection(model);
        //    return result;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update-collection-of-check-under-collection")]
        [HttpPost]
		[JwtAuthentication(Permissions.ControlChecksUnderCollection)]
		public IList<ChecksUnderCollectionViewModel> UpdateCollectionOfCheckUnderCollection(IList<ChecksUnderCollectionLightViewModel> model)
        {
            var result = this._DonationsService.UpdateCollectionOfCheckUnderCollection(model);
            return result;
        }



        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-by-condition 
		 */
		public GenericCollectionViewModel<DonationViewModel> Get(ConditionFilter<Donation, long> condition)
		{
			var result = this._DonationsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}/{BranchId?}/{date?}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DonationViewModel> Get(int? pageIndex, int? pageSize,int? BranchId,DateTime? date)
		{
			var result = this._DonationsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonationViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-light-by-condition 
		 */
		public GenericCollectionViewModel<DonationLightViewModel> GetLightModel(ConditionFilter<Donation, long> condition)
		{
			var result = this._DonationsService.GetLightModel(condition);
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
		public GenericCollectionViewModel<ListDonationLightViewModel> GetLightModel(int? pageIndex, int? pageSize, int? BranchId, 
            DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo)
		{
			var result = this._DonationsService.GetLightModel(pageIndex, pageSize,BranchId, dateFrom, dateTo, 
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
		[JwtAuthentication(Permissions.MovementsReceivedList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-with-filter 
		 */
		public GenericCollectionViewModel<ListDonationLightViewModel> GetByFilter([FromBody]FinancialViewModel model)
        {
            var result = this._DonationsService.GetReceiptModel(model);
            return result;
        }

        /// <summary>
        /// Gets a DonationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.MovementsReceivedList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get/1 
		 */
		public DetailsDonationViewModel Get(long id)
		{
			var result = this._DonationsService.Get(id);
			return result;
		}

        [Route("get/invoice/{id}")]
        [HttpGet]
		[JwtAuthentication(Permissions.PrintReceipt)]
		public DonationInvoiceViewModel GetInvoice(int id)
        {
            var result = this._DonationsService.DonationInvoice(id);
            return result;
        }
        /// <summary>
        /// Gets a DonationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/Details/{id}")]
        [HttpGet]
		[JwtAuthentication(Permissions.MovementsReceivedList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get/1 
		 */
		public DetailsDonationViewModel GetDetails(long id)
        {
            var result = this._DonationsService.Get(id);
            return result;
        }

		/// <summary>
		/// Gets a DonationViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get-by-id/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.MovementsReceivedList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/get-by-id/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/get-by-id/1 
		 */
		public DonationViewModel GetById(long id)
		{
			var result = this._DonationsService.GetById(id);
			return result;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddMovementsReceived)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/add-collection 
		 */
		public IList<DonationViewModel> Add([FromBody]IEnumerable<DonationViewModel> collection)
		{
			var result = this._DonationsService.Add(collection);
			return result;
		}




		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddMovementsReceived)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/add 
		 */
		public AddDonationViewModel AddInternalDonation([FromBody]AddDonationViewModel model)
		{
			var result = this._DonationsService.Add(model);
			return result;
		}

        /// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("ExternalDonation/Add")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ExternalDonations/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ExternalDonations/add 
		 */
        public long Add([FromBody]AddExternalDonationViewModel model)
        {
            var result = this._DonationsService.AddExternalDonation(model);
            return result;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditMovementsReceived)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/update-collection 
		 */
		public IList<DonationViewModel> Update([FromBody]IEnumerable<DonationViewModel> collection)
		{
			var result = this._DonationsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditMovementsReceived)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/update 
		 */
		public AddDonationViewModel Update([FromBody]AddDonationViewModel model)
		{
			var result = this._DonationsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<DonationViewModel> collection)
		{
			this._DonationsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._DonationsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/delete 
		 */
		public void Delete([FromBody]DonationViewModel model)
		{
			this._DonationsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donations/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donations/delete/1 
		 */
		public void Delete(long id)
		{
			this._DonationsService.Delete(id);
		}

		#endregion
	}
}
