#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
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
	/// Banks Controller
	/// </summary>
	[RoutePrefix("api/Banks")]
	public class BanksController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBanksService _BanksService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankController.
		/// </summary>
		/// <param name="BanksService">The injected service.</param>
		public BanksController(IBanksService BanksService)
		{
			this._BanksService = BanksService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
		[JwtAuthentication(Permissions.BanksList)]
		public GenericCollectionViewModel<ListBankLightViewModel> GetByFilter([FromBody]BankFilterViewModel model)
        {
            var result = this._BanksService.GetByFilter(model);
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/get-by-condition 
		 */
		public GenericCollectionViewModel<BankViewModel> Get(ConditionFilter<Bank, long> condition)
		{
			var result = this._BanksService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._BanksService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/get-light-by-condition 
		 */
		public GenericCollectionViewModel<BankLightViewModel> GetLightModel(ConditionFilter<Bank, long> condition)
		{
			var result = this._BanksService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._BanksService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a BankViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.BanksList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/get/1 
		 */
		public BankViewModel Get(long id)
		{
			var result = this._BanksService.Get(id);
			return result;
		}


        /// <summary>
        /// Gets a List of BankLightViewModel Lookup.
        /// </summary>
        /// <param ></param>
        /// <param ></param>
        /// <returns></returns>
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankLightViewModel/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankLightViewModel/get-lookup
		 */
        public List<BankLightViewModel> GetLookup()
        {
            var result = this._BanksService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddBank)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/add-collection 
		 */
		public IList<BankViewModel> Add([FromBody]IEnumerable<BankViewModel> collection)
		{
			var result = this._BanksService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddBank)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/add 
		 */
		public BankViewModel Add([FromBody]BankViewModel model)
		{
			var result = this._BanksService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditBank)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/update-collection 
		 */
		public IList<BankViewModel> Update([FromBody]IEnumerable<BankViewModel> collection)
		{
			var result = this._BanksService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditBank)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/update 
		 */
		public BankViewModel Update([FromBody]BankViewModel model)
		{
			var result = this._BanksService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<BankViewModel> collection)
		{
			this._BanksService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._BanksService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/delete 
		 */
		public void Delete([FromBody]BankViewModel model)
		{
			this._BanksService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Banks/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Banks/delete/1 
		 */
		public void Delete(long id)
		{
			this._BanksService.Delete(id);
		}

		#endregion
	}
}
