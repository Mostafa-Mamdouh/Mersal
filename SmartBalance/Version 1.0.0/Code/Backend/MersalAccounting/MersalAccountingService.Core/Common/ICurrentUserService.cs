#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Common
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICurrentUserService
	{
		#region Properties
		long? CurrentUserId { get; }
		#endregion
	}
}
