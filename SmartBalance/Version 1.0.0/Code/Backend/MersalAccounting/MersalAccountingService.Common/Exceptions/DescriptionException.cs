using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class DescriptionException : BaseException
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        /// <param name="message"></param>
        public DescriptionException(int message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public DescriptionException()
            : base("DescriptionIsNotValidException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
