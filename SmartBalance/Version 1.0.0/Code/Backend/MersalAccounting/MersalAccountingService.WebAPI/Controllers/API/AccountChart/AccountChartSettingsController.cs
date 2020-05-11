#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
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
	/// AccountChartSettings Controller
	/// </summary>
	[RoutePrefix("api/AccountChartSettings")]
	public class AccountChartSettingsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAccountChartSettingsService _AccountChartSettingsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartSettingController.
		/// </summary>
		/// <param name="AccountChartSettingsService">The injected service.</param>
		public AccountChartSettingsController(IAccountChartSettingsService AccountChartSettingsService)
		{
			this._AccountChartSettingsService = AccountChartSettingsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartSettingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartSettingViewModel> Get(ConditionFilter<AccountChartSetting, long> condition)
		{
			var result = this._AccountChartSettingsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartSettingViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartSettingsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartSettingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartSettingLightViewModel> GetLightModel(ConditionFilter<AccountChartSetting, long> condition)
		{
			var result = this._AccountChartSettingsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartSettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartSettingsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AccountChartSettingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get/1 
		 */
		public AccountChartSettingViewModel Get(long id)
		{
			var result = this._AccountChartSettingsService.Get(id);
			return result;
		}

        /// <summary>
        /// Gets a AccountChartSettingViewModel 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/get
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/get
		 */
        public AccountChartSettingViewModel Get()
        {
            var result = this._AccountChartSettingsService.Get();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/add-collection 
		 */
		public IList<AccountChartSettingViewModel> Add([FromBody]IEnumerable<AccountChartSettingViewModel> collection)
		{
			var result = this._AccountChartSettingsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/add 
		 */
		public AccountChartSettingViewModel Add([FromBody]AccountChartSettingViewModel model)
		{
			var result = this._AccountChartSettingsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/update-collection 
		 */
		public IList<AccountChartSettingViewModel> Update([FromBody]IEnumerable<AccountChartSettingViewModel> collection)
		{
			var result = this._AccountChartSettingsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/update 
		 */
		public AccountChartSettingViewModel Update([FromBody]AccountChartSettingViewModel model)
		{
			var result = this._AccountChartSettingsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountChartSettingViewModel> collection)
		{
			this._AccountChartSettingsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountChartSettingsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/delete 
		 */
		public void Delete([FromBody]AccountChartSettingViewModel model)
		{
			this._AccountChartSettingsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartSettings/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartSettings/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountChartSettingsService.Delete(id);
		}

		#endregion
	}
}
