#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class CostCenterTypeMap : EntityTypeConfiguration<CostCenterType>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// CostCenterTypeMap.
        /// </summary>
        public CostCenterTypeMap()
        {
            #region Configure Relations For Foreign Key ParentKeyCostCenterTypeId
            this.HasMany(entity => entity.ChildTranslatedCostCenterTypes)
                    .WithOptional(entity => entity.ParentKeyCostCenterType)
                    .HasForeignKey(entity => entity.ParentKeyCostCenterTypeId);
            #endregion
        }
        #endregion
    }
}
