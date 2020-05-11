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
	/// <typeparam name="TEntityIdentity"></typeparam>
	public interface IEntityIdentity<TEntityIdentity>
	{
		#region Properties
		/// <summary>
		/// Gets or sets entity Id.
		/// </summary>
		TEntityIdentity Id { get; set; }
		#endregion
	}
}
