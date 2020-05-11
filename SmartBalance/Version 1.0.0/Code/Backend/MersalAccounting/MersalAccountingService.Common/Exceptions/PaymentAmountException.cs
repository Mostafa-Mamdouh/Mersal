using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class PaymentAmountException : BaseException
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        /// <param name="message"></param>
        public PaymentAmountException(int message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public PaymentAmountException()
            : base("PaymentAmountIsNotValidException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
