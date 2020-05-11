using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class PaymentException : BaseException
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        /// <param name="message"></param>
        public PaymentException(int message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public PaymentException()
            : base("PaymentIsNotValidException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
