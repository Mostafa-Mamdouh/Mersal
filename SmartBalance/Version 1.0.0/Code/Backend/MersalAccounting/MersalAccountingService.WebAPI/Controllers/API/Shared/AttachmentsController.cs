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
	/// Attachments Controller
	/// </summary>
	[RoutePrefix("api/Attachments")]
	public class AttachmentsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAttachmentsService _AttachmentsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AttachmentController.
		/// </summary>
		/// <param name="AttachmentsService">The injected service.</param>
		public AttachmentsController(IAttachmentsService AttachmentsService)
		{
			this._AttachmentsService = AttachmentsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AttachmentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/get-by-condition 
		 */
		public GenericCollectionViewModel<AttachmentViewModel> Get(ConditionFilter<Attachment, long> condition)
		{
			var result = this._AttachmentsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AttachmentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AttachmentViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AttachmentsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AttachmentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AttachmentLightViewModel> GetLightModel(ConditionFilter<Attachment, long> condition)
		{
			var result = this._AttachmentsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AttachmentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AttachmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AttachmentsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AttachmentViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/get/1 
		 */
		public AttachmentViewModel Get(long id)
		{
			var result = this._AttachmentsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/add-collection 
		 */
		public IList<AttachmentViewModel> Add([FromBody]IEnumerable<AttachmentViewModel> collection)
		{
			var result = this._AttachmentsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/add 
		 */
		public AttachmentViewModel Add([FromBody]AttachmentViewModel model)
		{
			var result = this._AttachmentsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/update-collection 
		 */
		public IList<AttachmentViewModel> Update([FromBody]IEnumerable<AttachmentViewModel> collection)
		{
			var result = this._AttachmentsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/update 
		 */
		public AttachmentViewModel Update([FromBody]AttachmentViewModel model)
		{
			var result = this._AttachmentsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AttachmentViewModel> collection)
		{
			this._AttachmentsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AttachmentsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/delete 
		 */
		public void Delete([FromBody]AttachmentViewModel model)
		{
			this._AttachmentsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Attachments/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Attachments/delete/1 
		 */
		public void Delete(long id)
		{
			this._AttachmentsService.Delete(id);
		}

		#endregion
	}
}
