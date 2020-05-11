
using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class DateException : BaseException
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        /// <param name="message"></param>
        public DateException(int message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public DateException()
            : base("DateIsNotValidException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
