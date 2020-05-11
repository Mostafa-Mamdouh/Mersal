#region Using ...
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class MenuItemMap : EntityTypeConfiguration<MenuItem>
    {
        #region Constructors
        public MenuItemMap()
        {
            #region Configure Relations For Foreign Key ParentMenuItemId
            this.HasMany(entity => entity.ChildMenuItems)
                    .WithOptional(entity => entity.ParentMenuItem)
                    .HasForeignKey(entity => entity.ParentMenuItemId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyMenuItemId
            this.HasMany(entity => entity.ChildTranslatedMenuItems)
                    .WithOptional(entity => entity.ParentKeyMenuItem)
                    .HasForeignKey(entity => entity.ParentKeyMenuItemId);
            #endregion
        }
        #endregion
    }
}
