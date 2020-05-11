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
	public class ItemAlreadyExistException : Base.BaseException
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ItemAlreadyExistException.
		/// </summary>
		/// <param name="message"></param>
		public ItemAlreadyExistException(string message)
			: base(message)
		{

		}
        /// <summary>
		/// Initializes a new instance of 
		/// type ItemAlreadyExistException.
		/// </summary>
		/// <param name="message"></param>
		public ItemAlreadyExistException(int errorCode)
            : base(errorCode)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemAlreadyExistException.
        /// </summary>
        public ItemAlreadyExistException()
			: base("ItemAlreadyExistException")
		{

		}
		#endregion

		#region Methods

		#endregion

		#region Properties

		#endregion
	}
}
