#region Using ...
using Framework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace Framework.Core.Filters
{
	/// <summary>
	/// 
	/// </summary>
	public class Filter
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Filter.
		/// </summary>
		public Filter()
		{

		}
		#endregion

		#region Methods

		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public int StartPracesCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FieldName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public FieldValueOperator FieldOperator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public object Value { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int EndPracesCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public FilterOperator FilterOperator { get; set; }
		#endregion
	}
}
