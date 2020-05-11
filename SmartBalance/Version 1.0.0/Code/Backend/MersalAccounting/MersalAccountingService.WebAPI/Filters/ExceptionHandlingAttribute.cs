#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions.Base;
using Framework.Core.Common;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;
#endregion

namespace MersalAccountingService.WebAPI.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        #region Data Members
        private ILoggerService _loggerService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type 
        /// ExceptionHandlingAttribute.
        /// </summary>
        public ExceptionHandlingAttribute(ILoggerService loggerService)
        {
            this._loggerService = loggerService;
        }
        #endregion

        #region Methods
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            this._loggerService.Log(actionExecutedContext.Exception.ToString(), LogType.Error);

            if (actionExecutedContext.Exception is BaseException)
            {
                var baseException = (BaseException)actionExecutedContext.Exception;              

                actionExecutedContext.Response = new HttpResponseMessage((HttpStatusCode)baseException.ErrorCode);
                actionExecutedContext.Response.ReasonPhrase = baseException.ErrorCode.ToString();
            }

            base.OnException(actionExecutedContext);
        }
        #endregion
    }
}