#region Using ...
using Framework.Core.Filters;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.DependancyInjection.App_Start;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
#endregion

namespace MersalAccountingService.WebAPI.Auth
{
	public class JwtAuthentication : Attribute, IAuthenticationFilter
	{
		public string Realm { get; set; }
		public bool AllowMultiple => false;

		private readonly Permissions _permission;
		private IUserPermissionsRepository _UserPermissionsRepository;
		private IUserRolesRepository _userRolesRepository;
		private IUserGroupsRepository _userGroupsRepository;


		public JwtAuthentication(Permissions permission)
		{
			this._permission = permission;
		}

		public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			this._UserPermissionsRepository = SimpleInjectorWebApiInitializer.Resolve<IUserPermissionsRepository>();

			var request = context.Request;
			var authorization = request.Headers.Authorization;
			// checking request header value having required scheme "Bearer" or not.
			if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
			{
				context.ErrorResult = new AuthFailureResult("JWT Token is Missing", request);
				return;
			}
			// Getting Token value from header values.
			var token = authorization.Parameter;
			var principal = await AuthJwtToken(token);
			if (principal == null)
			{
				context.ErrorResult = new AuthFailureResult("Invalid JWT Token", request);
			}
			else
			{
				var identity = principal.Identity as ClaimsIdentity;
				var isAuthorization = bool.Parse(identity.FindFirst(ClaimTypes.AuthorizationDecision).Value);

				if (isAuthorization == false)
				{
					context.ErrorResult = new AuthFailureResult("Unauthorized", request);
				}
				else
				{
					context.Principal = principal;
				}
			}
		}
		private bool ValidateToken(string token, out string id)
		{
			id = null;

			var simplePrinciple = JwtAuthManager.GetPrincipal(token);
			if (simplePrinciple == null)
				return false;
			var identity = simplePrinciple.Identity as ClaimsIdentity;

			if (identity == null)
				return false;

			if (!identity.IsAuthenticated)
				return false;

			var usernameClaim = identity.FindFirst(ClaimTypes.Name);
			id = usernameClaim?.Value;

			if (string.IsNullOrEmpty(id))
				return false;

			// You can implement more validation to check whether username exists in your DB or not or something else. 



			return true;
		}
		protected Task<IPrincipal> AuthJwtToken(string token)
		{
			string id;

			if (ValidateToken(token, out id))
			{
				//to get more information from DB in order to build local identity based on username 
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, id)
                    // you can add more claims if needed like Roles ( Admin or normal user or something else)
                };


				string authorization;
				long userId = long.Parse(id);

				var permission = this._UserPermissionsRepository.Get().FirstOrDefault(x =>
					x.UserId == userId &&
					x.Permission.Code == (int)_permission);

				UserRole userRole = null;

				if (permission == null)
				{
					this._userRolesRepository = SimpleInjectorWebApiInitializer.Resolve<IUserRolesRepository>();

					userRole = this._userRolesRepository.Get(null).Where(x =>
						x.UserId == userId &&
						x.RoleId.HasValue == true &&
						x.Role.RolePermissions.FirstOrDefault(r => r.PermissionId == (int)_permission) != null).FirstOrDefault();
				}

				UserGroup userGroup = null;

				if (permission == null && userRole == null)
				{
					this._userGroupsRepository = SimpleInjectorWebApiInitializer.Resolve<IUserGroupsRepository>();

					userGroup = this._userGroupsRepository.Get(null).Where(x =>
						x.UserId == userId &&
						x.GroupId.HasValue == true &&
						x.Group.GroupPermissions.FirstOrDefault(r => r.PermissionId == (int)_permission) != null).FirstOrDefault();
				}



				if (permission != null || userRole != null || userGroup != null)
					authorization = bool.TrueString;
				else
					authorization = bool.FalseString;

				var identity = new ClaimsIdentity(claims, "Jwt");
				IPrincipal user = new ClaimsPrincipal(identity);
				identity.AddClaim(new Claim(ClaimTypes.AuthorizationDecision, authorization));

				return Task.FromResult(user);
			}

			return Task.FromResult<IPrincipal>(null);
		}
		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			Challenge(context);
			return Task.FromResult(0);
		}
		private void Challenge(HttpAuthenticationChallengeContext context)
		{
			string parameter = null;

			if (!string.IsNullOrEmpty(Realm))
				parameter = "realm=\"" + Realm + "\"";

			//context.ChallengeWith("Bearer", parameter);
		}
	}
}