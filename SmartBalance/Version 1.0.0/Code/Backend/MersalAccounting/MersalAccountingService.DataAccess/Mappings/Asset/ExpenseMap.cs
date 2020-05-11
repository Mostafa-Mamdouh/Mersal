#region Using ...
using MersalAccountingService.Entities.Entity;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
    public class ExpenseMap : EntityTypeConfiguration<Expense>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// ExpenseMap.
        /// </summary>
        public ExpenseMap()
        {
            #region Configure Relations For Foreign Key ParentKeyExpenseId
            this.HasMany(entity => entity.ChildTranslatedExpenses)
                    .WithOptional(entity => entity.ParentKeyExpense)
                    .HasForeignKey(entity => entity.ParentKeyExpenseId);
            #endregion
        }
        #endregion
    }
}
