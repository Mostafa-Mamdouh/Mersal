#region Using ...
using Framework.Common.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Exceptions
{
	public class InvalidLoginException : BaseException
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InvalidLoginException.
		/// </summary>
		/// <param name="message"></param>
		public InvalidLoginException(string message)
			: base(message)
		{

		}
		/// <summary>
		/// Initializes a new instance of 
		/// type InvalidLoginException.
		/// </summary>
		public InvalidLoginException()
			: base("InvalidLoginException")
		{

		}
		#endregion

		#region Methods

		#endregion

		#region Properties

		#endregion
	}
}
