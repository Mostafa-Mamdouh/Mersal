using Framework.Common.Exceptions.Base;

namespace MersalAccountingService.Common.Exceptions
{
    public class BranchException : BaseException
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        /// <param name="message"></param>
        public BranchException(int message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type ItemNotFoundException.
        /// </summary>
        public BranchException()
            : base("BranchIsNotValidException")
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
