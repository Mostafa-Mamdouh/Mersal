#region using...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
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
    [RoutePrefix("api/Documents")]
    public class DocumentsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDocumentService _documentService;
        #endregion

        #region Constructors
        public DocumentsController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of DocumentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get-by-condition 
		 */
        public GenericCollectionViewModel<DocumentViewModel> Get(ConditionFilter<Document, long> condition)
        {
            var result = this._documentService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DocumentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DocumentViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._documentService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DocumentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DocumentLightViewModel> GetLightModel(ConditionFilter<Document, long> condition)
        {
            var result = this._documentService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DocumentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DocumentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._documentService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DocumentViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get/1 
		 */
        public DocumentViewModel Get(long id)
        {
            var result = this._documentService.Get(id);
            return result;
        }
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-lookup
		 */
        public List<DocumentLightViewModel> GetLookup()
        {
            var result = this._documentService.GetLookUp();
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListDocumentsLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/get-with-filter 
		 */
        public GenericCollectionViewModel<ListDocumentsLightViewModel> GetByFilter([FromBody]DocumentFilterViewModel model)
        {
            var result = this._documentService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/add-collection 
		 */
        public IList<DocumentViewModel> Add([FromBody]IEnumerable<DocumentViewModel> collection)
        {
            var result = this._documentService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/add 
		 */
        public DocumentViewModel Add([FromBody]DocumentViewModel model)
        {
            var result = this._documentService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/update-collection 
		 */
        public IList<DocumentViewModel> Update([FromBody]IEnumerable<DocumentViewModel> collection)
        {
            var result = this._documentService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/update 
		 */
        public DocumentViewModel Update([FromBody]DocumentViewModel model)
        {
            var result = this._documentService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DocumentViewModel> collection)
        {
            this._documentService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._documentService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/delete 
		 */
        public void Delete([FromBody]DocumentViewModel model)
        {
            this._documentService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Documents/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Documents/delete/1 
		 */
        public void Delete(long id)
        {
            this._documentService.Delete(id);
        }

        #endregion
    }
}
