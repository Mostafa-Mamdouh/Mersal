#region using...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
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
	/// 
	/// </summary>
    [RoutePrefix("api/AccountChartDocuments")]
    public class AccountChartDocumentController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IAccountChartDocumentService _accountDocumentService;
        #endregion

        #region Constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountDocumentService"></param>
        public AccountChartDocumentController(IAccountChartDocumentService accountDocumentService)
        {
            this._accountDocumentService = accountDocumentService;
        }
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        [JwtAuthentication(Permissions.AccountChartDocumentList)]
        public GenericCollectionViewModel<ListAccountChartDocumentLightViewModel> GetByFilter([FromBody]AccountChartDocumentFilterViewModel model)
        {
            var result = this._accountDocumentService.GetByFilter(model);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of BankDocumentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/get-by-condition 
		 */
        public GenericCollectionViewModel<AccountChartDocumentViewModel> Get(ConditionFilter<AccountChartDocument, long> condition)
        {
            var result = this._accountDocumentService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankDocumentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<AccountChartDocumentViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._accountDocumentService.Get(pageIndex, pageSize);
            return result;
        }

   //     /// <summary>
   //     /// Gets a GenericCollectionViewModel of BankDocumentViewModel by condition.
   //     /// </summary>
   //     /// <param name="condition"></param>
   //     /// <returns></returns>
   //     [Route("get-light-by-condition")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/get-light-by-condition
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/get-light-by-condition 
		 //*/
   //     public GenericCollectionViewModel<BankDocumentLightViewModel> GetLightModel(ConditionFilter<BankDocument, long> condition)
   //     {
   //         var result = this._bankDocumentService.GetLightModel(condition);
   //         return result;
   //     }

   //     /// <summary>
   //     /// Gets a GenericCollectionViewModel of BankDocumentViewModel by pagination.
   //     /// </summary>
   //     /// <param name="pageIndex"></param>
   //     /// <param name="pageSize"></param>
   //     /// <returns></returns>
   //     [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/get-light-by-pagger/{pageIndex}/{pageSize}
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/get-light-by-pagger/0/10 
		 //*/
   //     public GenericCollectionViewModel<BankDocumentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
   //     {
   //         var result = this._bankDocumentService.GetLightModel(pageIndex, pageSize);
   //         return result;
   //     }

        /// <summary>
        /// Gets a BankDocumentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        [JwtAuthentication(Permissions.AccountChartDocumentList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/get/1 
		 */
        public List<AccountChartDocumentViewModel> Get(long id)
        {
            var result = this._accountDocumentService.Get(id);
            return result;
        }


   //     /// <summary>
   //     /// Gets a List of BankDocumentLightViewModel Lookup.
   //     /// </summary>
   //     /// <param ></param>
   //     /// <param ></param>
   //     /// <returns></returns>
   //     [Route("get-lookup")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocumentLightViewModel/get-lookup
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocumentLightViewModel/get-lookup
		 //*/
   //     public List<BankDocumentLightViewModel> GetLookup()
   //     {
   //         var result = this._bankDocumentService.GetLookUp();
   //         return result;
   //     }
        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.AddAccountChartDocument)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/add-collection 
		 */
        public IList<AccountChartDocumentViewModel> Add([FromBody]IEnumerable<AccountChartDocumentViewModel> collection)
        {
            var result = this._accountDocumentService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        [JwtAuthentication(Permissions.AddAccountChartDocument)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/add 
		 */
        public AccountChartDocumentViewModel Add([FromBody]AccountChartDocumentViewModel model)
        {
            var result = this._accountDocumentService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditAccountChartDocument)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/update-collection 
		 */
        public IList<AccountChartDocumentViewModel> Update([FromBody]IEnumerable<AccountChartDocumentViewModel> collection)
        {
            var result = this._accountDocumentService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        [JwtAuthentication(Permissions.EditAccountChartDocument)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/update 
		 */
        public AccountChartDocumentViewModel Update([FromBody]AccountChartDocumentViewModel model)
        {
            var result = this._accountDocumentService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<AccountChartDocumentViewModel> collection)
        {
            this._accountDocumentService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._accountDocumentService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/delete 
		 */
        public void Delete([FromBody]AccountChartDocumentViewModel model)
        {
            this._accountDocumentService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankDocuments/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankDocuments/delete/1 
		 */
        public void Delete(long id)
        {
            this._accountDocumentService.Delete(id);
        }

        #endregion
    }
}
