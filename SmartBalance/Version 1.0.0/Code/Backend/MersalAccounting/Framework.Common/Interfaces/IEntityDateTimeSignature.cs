#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace Framework.Common.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IEntityDateTimeSignature
	{
		#region Properties       
		/// <summary>
		/// Gets or sets entity CreationDate.
		/// </summary>
		DateTime CreationDate { get; set; }
		/// <summary>
		/// Gets or sets entity FirstModificationDate.
		/// </summary>
		DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// Gets or sets entity LastModificationDate.
		/// </summary>
		DateTime? LastModificationDate { get; set; }
		#endregion
	}
}
