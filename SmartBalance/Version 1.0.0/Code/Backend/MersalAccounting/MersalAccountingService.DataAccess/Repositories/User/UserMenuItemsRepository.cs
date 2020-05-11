#region Using ...
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserMenuItemsRepository : BaseServiceRepository<UserMenuItem, long>, IUserMenuItemsRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserMenuItemsRepository.
        /// </summary>
        /// <param name="context"></param>
        public UserMenuItemsRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
