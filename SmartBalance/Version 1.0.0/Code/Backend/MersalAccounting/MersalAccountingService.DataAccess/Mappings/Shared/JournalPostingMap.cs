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
    public class JournalPostingMap : EntityTypeConfiguration<JournalPosting>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of type
        /// JournalMap.
        /// </summary>
        public JournalPostingMap()
        {
            //#region Configure Relations For Foreign Key ParentKeyJournalId
            //this.HasMany(entity => entity.ChildTranslatedJournalPostings)
            //        .WithOptional(entity => entity.ParentKeyJournalPosting)
            //        .HasForeignKey(entity => entity.ParentKeyJournalPostingId);
            //#endregion
        }
        #endregion
    }
}
