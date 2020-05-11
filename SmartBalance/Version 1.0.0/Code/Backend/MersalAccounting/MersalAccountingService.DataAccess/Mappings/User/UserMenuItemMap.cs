#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class UserMenuItemMap : EntityTypeConfiguration<UserMenuItem>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// UserMenuItemMap.
        /// </summary>
        public UserMenuItemMap()
        {

        }
        #endregion
    }
}
