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
	public class JournalTypeMap : EntityTypeConfiguration<JournalType>
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// JournalTypeMap.
		/// </summary>
		public JournalTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyJournalTypeId
			this.HasMany(entity => entity.ChildTranslatedJournalTypes)
					.WithOptional(entity => entity.ParentKeyJournalType)
					.HasForeignKey(entity => entity.ParentKeyJournalTypeId);
			#endregion
		}
		#endregion
	}
}
