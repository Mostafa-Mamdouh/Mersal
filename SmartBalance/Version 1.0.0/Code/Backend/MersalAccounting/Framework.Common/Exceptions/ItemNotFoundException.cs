#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Common.Exceptions
{
	/// <summary>
	/// 
	/// </summary>
	public class ItemNotFoundException : Base.BaseException
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ItemNotFoundException.
		/// </summary>
		/// <param name="message"></param>
		public ItemNotFoundException(string message)
			: base(message)
		{

		}
        /// <summary>
		/// Initializes a new instance of 
		/// type ItemNotFoundException.
		/// </summary>
		/// <param name="message"></param>
		public ItemNotFoundException(int errorCode)
            : base(errorCode)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public ItemNotFoundException()
			: base("ItemNotFoundException")
		{

		}
		#endregion

		#region Methods

		#endregion

		#region Properties

		#endregion
	}
}
