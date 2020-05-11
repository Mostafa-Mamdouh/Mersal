#region Using ...
using MersalAccountingService.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
#endregion

namespace MersalAccountingService.BusinessLogic.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class CurrentUserService : ICurrentUserService
	{
		#region Data Members

		#endregion

		#region Constructors
		public CurrentUserService()
		{

		}
		#endregion

		#region ICurrentUserService
		public long? CurrentUserId
		{
			get
			{
				string userId = HttpContext.Current.Request.Headers["user-id"];

				if (string.IsNullOrEmpty(userId) == false)
				{
					return long.Parse(userId);
				}
				return null;
			}
		}
		#endregion
	}
}
