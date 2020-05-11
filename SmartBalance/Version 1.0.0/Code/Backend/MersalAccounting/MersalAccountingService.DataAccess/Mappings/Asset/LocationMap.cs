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
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// LocationMap.
        /// </summary>
        public LocationMap()
        {
            #region Configure Relations For AssetLocations
            this.HasMany(entity => entity.AssetLocations)
                .WithOptional(entity => entity.Location)
                .HasForeignKey(entity => entity.LocationId);
            #endregion

            #region Configure Relations For Foreign Key ParentKeyLocationId
            this.HasMany(entity => entity.ChildTranslatedLocations)
					.WithOptional(entity => entity.ParentKeyLocation)
					.HasForeignKey(entity => entity.ParentKeyLocationId);
            #endregion

            #region Configure Relations For Foreign Key ParentLocationId
            this.HasMany(entity => entity.ChildLocations)
                    .WithOptional(entity => entity.ParentLocation)
                    .HasForeignKey(entity => entity.ParentLocationId);
            #endregion
        }
        #endregion
    }
}
