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
	/// DelegateMans Controller
	/// </summary>
	[RoutePrefix("api/DelegateMans")]
	public class DelegateMansController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IDelegateMansService _DelegateMansService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DelegateManController.
		/// </summary>
		/// <param name="DelegateMansService">The injected service.</param>
		public DelegateMansController(IDelegateMansService DelegateMansService)
		{
			this._DelegateMansService = DelegateMansService;
		}
        #endregion

        #region Actions


        [Route("get-with-filter")]
        [HttpPost]
        [JwtAuthentication(Permissions.DelegateList)]
        public GenericCollectionViewModel<ListDelegateMensLightViewModel> GetByFilter([FromBody]DelegateMenFilterViewModel model)
        {
            var result = this._DelegateMansService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DelegateManViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-by-condition 
		 */
		public GenericCollectionViewModel<DelegateManViewModel> Get(ConditionFilter<DelegateMan, long> condition)
		{
			var result = this._DelegateMansService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DelegateManViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._DelegateMansService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-light-by-condition 
		 */
		public GenericCollectionViewModel<DelegateManLightViewModel> GetLightModel(ConditionFilter<DelegateMan, long> condition)
		{
			var result = this._DelegateMansService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of DelegateManViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<DelegateManLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._DelegateMansService.GetLightModel(pageIndex, pageSize);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-lookup
		 */
        public List<DelegateManLightViewModel> GetLookup()
        {
            var result = this._DelegateMansService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a DelegateManViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
		[HttpGet]
        [JwtAuthentication(Permissions.DelegateList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get/1 
		 */
        public DelegateManViewModel Get(long id)
		{
			var result = this._DelegateMansService.Get(id);
			return result;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
        [JwtAuthentication(Permissions.AddDelegate)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/add-collection 
		 */
        public IList<DelegateManViewModel> Add([FromBody]IEnumerable<DelegateManViewModel> collection)
		{
			var result = this._DelegateMansService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
        [JwtAuthentication(Permissions.AddDelegate)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/add 
		 */
		public DelegateManViewModel Add([FromBody]DelegateManViewModel model)
		{
			var result = this._DelegateMansService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
        [JwtAuthentication(Permissions.EditDelegate)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/update-collection 
		 */
        public IList<DelegateManViewModel> Update([FromBody]IEnumerable<DelegateManViewModel> collection)
		{
			var result = this._DelegateMansService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
        [JwtAuthentication(Permissions.EditDelegate)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/update 
		 */
        public DelegateManViewModel Update([FromBody]DelegateManViewModel model)
		{
			var result = this._DelegateMansService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<DelegateManViewModel> collection)
		{
			this._DelegateMansService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._DelegateMansService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/delete 
		 */
		public void Delete([FromBody]DelegateManViewModel model)
		{
			this._DelegateMansService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/delete/1 
		 */
		public void Delete(long id)
		{
			this._DelegateMansService.Delete(id);
		}

		#endregion
	}
}
