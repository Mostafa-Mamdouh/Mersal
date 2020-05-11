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
	public class JournalMap : EntityTypeConfiguration<Journal>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// JournalMap.
		/// </summary>
		public JournalMap()
		{
			#region Configure Relations For Foreign Key ParentKeyJournalId
			this.HasMany(entity => entity.ChildTranslatedJournals)
					.WithOptional(entity => entity.ParentKeyJournal)
					.HasForeignKey(entity => entity.ParentKeyJournalId);
			#endregion
		}
		#endregion
	}
}
