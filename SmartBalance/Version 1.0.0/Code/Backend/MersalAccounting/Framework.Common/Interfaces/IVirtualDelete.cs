#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Common.Interfaces
{
	public interface IVirtualDelete
	{
		#region Properties
		bool IsDeleted { get; set; }
		DateTime? LastDeletedDate { get; set; }
		DateTime? LastRestoredDate { get; set; }
		#endregion
	}
}
