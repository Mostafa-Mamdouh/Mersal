#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	/// <summary>
	/// Users Controller
	/// </summary>
	[RoutePrefix("api/Users")]
	public class UsersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IUsersService _UsersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UserController.
		/// </summary>
		/// <param name="UsersService">The injected service.</param>
		public UsersController(IUsersService UsersService)
		{
			this._UsersService = UsersService;
		}
		#endregion

		#region Actions

		[Route("has-permission-to-change-posted-accounts")]
		[HttpPost]
		public bool GetHasPermissionToChangePostedAccounts()
		{
			var result = this._UsersService.GetHasPermissionToChangePostedAccounts();
			return result;
		}

		[Route("get-max-payment-limit/{userId}")]
		[HttpGet]
		public decimal? GetMaxPaymentLimit(long userId)
		{
			var result = this._UsersService.GetMaxPaymentLimit(userId);
			return result;
		}

		[Route("get-max-payment-limit-for-current-user")]
		[HttpGet]
		public decimal? GetMaxPaymentLimitForCurrentUser()
		{
			var result = this._UsersService.GetMaxPaymentLimitForCurrentUser();
			return result;
		}

		[Route("get-user-branch/{userId}")]
		[HttpGet]
		public BranchLightViewModel GetUserBranch(long userId)
		{
			var result = this._UsersService.GetUserBranch(userId);
			return result;
		}

		[Route("get-current-user-branch")]
		[HttpGet]
		public BranchLightViewModel GetCurrentUserBranch()
		{
			var result = this._UsersService.GetCurrentUserBranch();
			return result;
		}

        [Route("is-user-has-permission/{userId}/{permissionItem}")]
        [HttpPost]
        public bool IsUserHassPermission(long? userId, Permissions permissionItem)
        {
            var result = this._UsersService.IsUserHassPermission(userId, permissionItem);
            return result;
        }

        [Route("is-current-user-has-permission/{permissionItem}")]
        [HttpPost]
        public bool IsCurrentUserHassPermission(Permissions permissionItem)
        {
            var result = this._UsersService.IsCurrentUserHassPermission(permissionItem);
            return result;
        }



        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get-by-condition 
		 */
		public GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition)
		{
			var result = this._UsersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._UsersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get-light-by-condition 
		 */
		public GenericCollectionViewModel<UserLightViewModel> GetLightModel(ConditionFilter<User, long> condition)
		{
			var result = this._UsersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of UserViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<UserLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._UsersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a UserViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get/1 
		 */
		public UserViewModel Get(long id)
		{
			var result = this._UsersService.Get(id);
			return result;
		}

		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.UserList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/get-with-filter 
		 */
		public GenericCollectionViewModel<ListUsersLightViewModel> GetByFilter([FromBody]UserFilterViewModel model)
		{
			var result = this._UsersService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/add-collection 
		 */
		public IList<UserViewModel> Add([FromBody]IEnumerable<UserViewModel> collection)
		{
			var result = this._UsersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/add 
		 */
		public UserViewModel Add([FromBody]UserViewModel model)
		{
			var result = this._UsersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/update-collection 
		 */
		public IList<UserViewModel> Update([FromBody]IEnumerable<UserViewModel> collection)
		{
			var result = this._UsersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/update 
		 */
		public UserViewModel Update([FromBody]UserViewModel model)
		{
			var result = this._UsersService.Update(model);
			return result;
		}



		[Route("get-user-permissions/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserPermisstions)]
		public UserPermissionListViewModel GetUserPermission(long userId)
		{
			var result = this._UsersService.GetUserPermission(userId);
			return result;
		}

		[Route("update-user-permissions")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeUserPermisstions)]
		public UserPermissionListViewModel UpdateUserPermission([FromBody]UserPermissionListViewModel model)
		{
			var result = this._UsersService.UpdateUserPermission(model);
			return result;
		}

        [Route("get-user-branchs/{userId}")]
        [HttpGet]
        [JwtAuthentication(Permissions.ChangeUserBranchs)]
        public UserBranchListViewModel GetUserBranchs(long userId)
        {
            var result = this._UsersService.GetUserBranchs(userId);
            return result;
        }

        [Route("update-user-branchs")]
        [HttpPost]
        [JwtAuthentication(Permissions.ChangeUserBranchs)]
        public UserBranchListViewModel UpdateUserBranchs([FromBody]UserBranchListViewModel model)
        {
            var result = this._UsersService.UpdateUserBranch(model);
            return result;
        }



        [Route("get-user-roles/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserRoles)]
		public UserRoleListViewModel GetUserRole(long userId)
		{
			var result = this._UsersService.GetUserRole(userId);
			return result;
		}

		[Route("update-user-roles")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeUserRoles)]
		public UserRoleListViewModel UpdateUserRole([FromBody]UserRoleListViewModel model)
		{
			var result = this._UsersService.UpdateUserRole(model);
			return result;
		}



		[Route("get-user-groups/{userId}")]
		[HttpGet]
		[JwtAuthentication(Permissions.ChangeUserGroups)]
		public UserGroupListViewModel GetUserGroup(long userId)
		{
			var result = this._UsersService.GetUserGroup(userId);
			return result;
		}

		[Route("update-user-groups")]
		[HttpPost]
		[JwtAuthentication(Permissions.ChangeUserGroups)]
		public UserGroupListViewModel UpdateUserGroup([FromBody]UserGroupListViewModel model)
		{
			var result = this._UsersService.UpdateUserGroup(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<UserViewModel> collection)
		{
			this._UsersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._UsersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/delete 
		 */
		public void Delete([FromBody]UserViewModel model)
		{
			this._UsersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Users/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Users/delete/1 
		 */
		public void Delete(long id)
		{
			this._UsersService.Delete(id);
		}

		[AllowAnonymous]
		[Route("user-login")]
		[HttpPost]
		public IHttpActionResult LoginInternal(LoginViewModel model)
		{
			UserLoggedInViewModel user = this._UsersService.Login(model);
			if (user != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string s = string.Empty;

				for (int i = 0; i < user.Permissions.Count; i++)
				{
					stringBuilder.Append(user.Permissions[i]);
					if (i < user.Permissions.Count - 1) stringBuilder.Append(',');
				}
				s = stringBuilder.ToString();
				user.access_token = JwtAuthManager.GenerateJWTToken(user.Id.ToString(), s);
				return Ok(user);
			}
			else
			{
				return BadRequest("0001");
			}
		}



		[AllowAnonymous]
		[Route("user-management-proxy-login")]
		[HttpPost]
		public IHttpActionResult Login(LoginViewModel model)
		{
			var url = System.Configuration.ConfigurationManager.AppSettings["mersal-user-management-api"];
			RestClient client = new RestClient(url);
			var request = new RestRequest("token", Method.POST);
			string encodedBody = $"grant_type=password&username={model.UserName}&password={model.Password}";

			request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
			request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
			var response = client.Execute<UserLoggedInViewModel>(request);

			if (response.StatusCode == HttpStatusCode.OK) // login true
			{
				/*
				 {
				 "access_token":"DuWe84gdLB0U8O4d4UK5c4GTxCdlTRyT39IyCXb_dh9DJQrXQ3rY2isuJLHNv2D2y5VMnBF3ZgTlU8Orj80Q1aqQ4m_k5i6BzOTspXFJIChBk6YZPGg3TO252tPWo2NXKKXfpv_IdAIM2gsD1ETPQk5lC20uLTTNXUXAwZnFTToW9S_l5GrB8-Nphq8FDjPb_v0sJoviBkS4MDDfeatiP02j-vj6SytsQH_mpaWRLoKQlkup1Qp0rmsXz-ubmZ1-kr_zIF_VOObfKuTvYxwdhn25-c0IopSbW11JKy8HrvWeR5lE6mW96CaSNcOjRAv9gh9dd9wjSN8tTPQFR22lh6dD-HjwNmxt8Ub3zeMECVLL1_SIyla3isQ-rotG-CsgPQMtfUZzyvc3YYmCWVYCMPJzt552L709Q-Ct7Gk_8TqUSMpWHb3gTXOQ9sCxT_-xvx03fI77Pim_7falfRIDBU7NebyClXeLiSlBxidjRvzJikSWmLYIzykc4FCQS1BN-xlf9Ak1mEK-YAexdGe083usmhUtibnG0l-x4fe15v14bwQ9R6ByQ8XEnRb8-5AYI_PhEAEe8KP6y-CQf_D0I9-gDFeA28PvHF13hII01Bp0OgRu9kq5CmNoXY2ErExOLDhVE_J5FJNqxSkHB7Z4rwjJBFem5DDAu2vxUmupu1xQOSX5AgnSuZYavCephk05sxhkzivZLEa_1Nc23I-4VCe1HONUP6oQiMsDLdGoGmaSBXfnuu7yCxcAG6Epqdnytt5QLUWwNjfZaxR_JttUP-BM70_svVNDvyl1wbhkyByh_CO49xiBJQDEM-2QTn6o3OBjdYzrouWc9igCrJ72RHgEe4vG5_erVU9d-z1a_YttJNNObGm5TRqAcKW0qEIO6mq0Iq_SSZBKEI6433EWCjlgGMUHjoxoyiocmsrmxBEhTG0fAP0thlaGg2TGbwaS",
				 "token_type":"bearer",
				 "expires_in":1209599,
				 "Id":"117",
				 "UserName":"Admin",
				 "FirstName":"admin",
				 "FirstNameOther":"مدير",
				 "MiddleName":"admin",
				 "MiddleNameOther":"مدير",
				 "LastName":"admin",
				 "LastNameOther":"النظام",
				 "Email":"mersalngo@gmail.com",
				 "Phone":"123456789202",
				 "Mobile":"12342",
				 "LocationId":"4109",
				 "Privileges":"29,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,140,141,153,154,155,156,157,158,159,161,1296,1297,2296,2297,2299,2300,2301,2302,2303,3301,4301,5302,5303,5305,5306,5307,5308,5309,5310,5311,5312,5313,5316,5317,5319,5321,5322,5323,5324,5326,5327,5328,5329,5330,5331,5332,5333,5336,5337,5338,5339,5340,5341,5342,5343,5344,5345,5362,5363,5364",
				 "MenuItems":"1042,3088,3089,3090,3091,3092,3093,3094,3095,3096,3097,3098,3099,3100",
				 ".issued":"Fri, 31 May 2019 18:38:54 GMT",
				 ".expires":"Fri, 14 Jun 2019 18:38:54 GMT",
				 "issued":"Fri, 31 May 2019 18:38:54 GMT",
				 "expires":"Fri, 14 Jun 2019 18:38:54 GMT"
				 }
				 */


				var user = response.Data;

				user.PrivilegeList = this._UsersService.GetUserPrivileges(user.Id);
				//user.MenuItemList = this._UsersService.GetUserMenuItems(user.Id);

				return Ok(user);
			}
			else if (response.StatusCode == HttpStatusCode.BadRequest) // login false
			{
				// bad request 
				return BadRequest("0001");
			}

			string result = "";

			if (response.ErrorException != null)
				result = response.ErrorException.ToString();
			else if (string.IsNullOrEmpty(response.ErrorMessage) == false)
				result = response.ErrorMessage;
			else
				result = response.StatusCode.ToString();

			return BadRequest(result);
		}


        [Route("change-password")]
        [HttpPost]
        public IHttpActionResult ChangePassword(ChangePasswordViewModel model)
        {
            this._UsersService.ChangePassword(model);
            return Ok();
        }

        [Route("reset-password/{userId}")]
        [HttpPost]
        public IHttpActionResult ResetPassword(long userId)
        {
            this._UsersService.ResetPassword(userId);
            return Ok();
        }
		#endregion
	}
}
