#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Common;
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
	/// AccountChartLevelSettings Controller
	/// </summary>
	[RoutePrefix("api/AccountChartLevelSettings")]
	public class AccountChartLevelSettingsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICurrentUserService _currentUserService;
		private readonly IAccountChartLevelSettingsService _AccountChartLevelSettingsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartLevelSettingController.
		/// </summary>
		/// <param name="currentUserService">The injected currentUserService.</param>
		/// <param name="AccountChartLevelSettingsService">The injected service.</param>
		public AccountChartLevelSettingsController(
			ICurrentUserService currentUserService,
			IAccountChartLevelSettingsService AccountChartLevelSettingsService)
		{
			this._currentUserService = currentUserService;
			this._AccountChartLevelSettingsService = AccountChartLevelSettingsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(ConditionFilter<AccountChartLevelSetting, long> condition)
		{
			var result = this._AccountChartLevelSettingsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartLevelSettingsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(ConditionFilter<AccountChartLevelSetting, long> condition)
		{
			var result = this._AccountChartLevelSettingsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AccountChartLevelSettingsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AccountChartLevelSettingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get/1 
		 */
		public AccountChartLevelSettingViewModel Get(long id)
		{
			var result = this._AccountChartLevelSettingsService.Get(id);
			return result;
		}


        /// <summary>
		/// Gets a AccountChartLevelSettingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/get/1 
		 */
        public List<AccountChartLevelSettingLightViewModel> Get()
        {
            var result = this._AccountChartLevelSettingsService.GetLightModel();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/add-collection 
		 */
		public IList<AccountChartLevelSettingViewModel> Add([FromBody]IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			var result = this._AccountChartLevelSettingsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/add 
		 */
		public AccountChartLevelSettingViewModel Add([FromBody]AccountChartLevelSettingViewModel model)
		{
			var result = this._AccountChartLevelSettingsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/update-collection 
		 */
		public IList<AccountChartLevelSettingViewModel> Update([FromBody]IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			var result = this._AccountChartLevelSettingsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/update 
		 */
		public AccountChartLevelSettingViewModel Update([FromBody]AccountChartLevelSettingViewModel model)
		{
			var result = this._AccountChartLevelSettingsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountChartLevelSettingViewModel> collection)
		{
			this._AccountChartLevelSettingsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountChartLevelSettingsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/delete 
		 */
		public void Delete([FromBody]AccountChartLevelSettingViewModel model)
		{
			this._AccountChartLevelSettingsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountChartLevelSettings/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountChartLevelSettings/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountChartLevelSettingsService.Delete(id);
		}

		#endregion
	}
}
