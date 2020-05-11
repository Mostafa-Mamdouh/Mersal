#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class DepreciationTypeMap : EntityTypeConfiguration<DepreciationType>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// DepreciationTypeMap.
        /// </summary>
        public DepreciationTypeMap()
        {
            #region Configure Relations For Foreign Key ParentKeyDepreciationTypeId
            this.HasMany(entity => entity.ChildTranslatedDepreciationTypes)
                    .WithOptional(entity => entity.ParentKeyDepreciationType)
                    .HasForeignKey(entity => entity.ParentKeyDepreciationTypeId);
            #endregion
        }
        #endregion
    }
}
