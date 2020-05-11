using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class GeneralException : BaseException
    {
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type GeneralException.
		/// </summary>
		/// <param name="message"></param>
		public GeneralException(int message)
            : base(message)
        {
			//this.ErrorCode = message;
        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public GeneralException()
            : base("GeneralException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
