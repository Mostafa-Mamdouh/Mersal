#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Core.Filters
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TEntityIdentity"></typeparam>
	public class ConditionFilter<TEntity, TEntityIdentity> where TEntity : IEntityIdentity<TEntityIdentity>
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ConditionFilter.
		/// </summary>
		public ConditionFilter()
		{
			this.NavigationProperties = new List<string>();
		}
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public IList<string> NavigationProperties { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Expression<Func<TEntity, bool>> Query { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string QueryString { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public IList<Filter> Filters { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public IList<object> FilterParams { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Order Order { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public long Count { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? PageIndex { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? PageSize { get; set; }
		#endregion
	}
}
