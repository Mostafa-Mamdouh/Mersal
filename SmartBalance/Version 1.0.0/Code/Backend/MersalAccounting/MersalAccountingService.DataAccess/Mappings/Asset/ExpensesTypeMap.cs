#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class ExpensesTypeMap : EntityTypeConfiguration<ExpensesType>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// ExpensesTypeMap.
        /// </summary>
        public ExpensesTypeMap()
        {
            #region Configure Relations For Foreign Key ParentKeyExpensesTypeId
            this.HasMany(entity => entity.ChildTranslatedExpensesTypes)
                    .WithOptional(entity => entity.ParentKeyExpensesType)
                    .HasForeignKey(entity => entity.ParentKeyExpensesTypeId);
            #endregion
        }
        #endregion
    }
}
