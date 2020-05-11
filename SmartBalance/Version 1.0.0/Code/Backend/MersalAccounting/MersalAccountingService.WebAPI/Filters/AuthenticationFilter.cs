#region Using ...
using Framework.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.WebAPI.Filters
{
	public class AuthenticationFilter : AuthorizeAttribute
	{
		#region Date Members
		private readonly ICurrentUserService _currentUserService;
		#endregion

		#region Constructors
		public AuthenticationFilter(ICurrentUserService currentUserService)
		{
			this._currentUserService = currentUserService;
		}
		#endregion

		public override void OnAuthorization(HttpActionContext actionContext)
		{
			if (actionContext.ActionDescriptor.ActionName == "Login" &&
				actionContext.ControllerContext.ControllerDescriptor.ControllerName == "Users")
				return;
			else
			{
				var userId = this._currentUserService.CurrentUserId;

				if (userId.HasValue == false)
					throw new InvalidLoginException(((int)GlobalVariables.InvalidLoginCode).ToString());
			}
		}

		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			base.HandleUnauthorizedRequest(actionContext);
		}
		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			return base.IsAuthorized(actionContext);
		}
		public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
		{
			return base.OnAuthorizationAsync(actionContext, cancellationToken);
		}
	}
}