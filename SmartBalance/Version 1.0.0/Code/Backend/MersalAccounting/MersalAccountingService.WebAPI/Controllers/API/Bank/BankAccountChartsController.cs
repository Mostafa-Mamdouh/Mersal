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
	/// BankAccountCharts Controller
	/// </summary>
	[RoutePrefix("api/BankAccountCharts")]
	public class BankAccountChartsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBankAccountChartService _BankAccountChartsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankAccountChartController.
		/// </summary>
		/// <param name="BankAccountChartsService">The injected service.</param>
		public BankAccountChartsController(IBankAccountChartService BankAccountChartsService)
		{
			this._BankAccountChartsService = BankAccountChartsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankAccountChartViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/get-by-condition 
		 */
		public GenericCollectionViewModel<BankAccountChartViewModel> Get(ConditionFilter<BankAccountChart, long> condition)
		{
			var result = this._BankAccountChartsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankAccountChartViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankAccountChartViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._BankAccountChartsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankAccountChartViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/get-light-by-condition 
		 */
		public GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(ConditionFilter<BankAccountChart, long> condition)
		{
			var result = this._BankAccountChartsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankAccountChartViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._BankAccountChartsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a BankAccountChartViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{bankId}/{accountChartId}")]
		[HttpGet]
		public BankAccountChartViewModel Get(long bankId, long accountChartId)
		{
			var result = this._BankAccountChartsService.Get(bankId, accountChartId);
			return result;
		}

        [Route("get-account-charts/{bankId}")]
        [HttpGet]
        public List<AccountChartLightViewModel> GetAccountCharts(long bankId)
        {
            return this._BankAccountChartsService.GetAccountCharts(bankId);
        }


        [Route("get/{id}")]
		[HttpGet]
        [JwtAuthentication(Permissions.BankAccountChartsList)]
		public List<BankAccountChartViewModel> Get(long id)
		{
			var result = this._BankAccountChartsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/add-collection 
		 */
		public IList<BankAccountChartViewModel> Add([FromBody]IEnumerable<BankAccountChartViewModel> collection)
		{
			var result = this._BankAccountChartsService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/add 
		 */
		public BankAccountChartViewModel Add([FromBody]BankAccountChartViewModel model)
		{
			var result = this._BankAccountChartsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
        [JwtAuthentication(Permissions.EditBankAccountCharts)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/update-collection 
		 */
        public IList<BankAccountChartViewModel> Update([FromBody]IEnumerable<BankAccountChartViewModel> collection)
		{
			var result = this._BankAccountChartsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/update 
		 */
		public BankAccountChartViewModel Update([FromBody]BankAccountChartViewModel model)
		{
			var result = this._BankAccountChartsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<BankAccountChartViewModel> collection)
		{
			this._BankAccountChartsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._BankAccountChartsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/delete 
		 */
		public void Delete([FromBody]BankAccountChartViewModel model)
		{
			this._BankAccountChartsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankAccountCharts/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankAccountCharts/delete/1 
		 */
		public void Delete(long id)
		{
			this._BankAccountChartsService.Delete(id);
		}

		#endregion
	}
}
