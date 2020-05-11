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
	public class TestamentExtractionMap : EntityTypeConfiguration<TestamentExtraction>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// TestamentExtractionMap.
		/// </summary>
		public TestamentExtractionMap()
		{
			#region Configure Relations For Foreign Key ParentKeyTestamentExtractionId
			this.HasMany(entity => entity.ChildTranslatedTestamentExtractions)
					.WithOptional(entity => entity.ParentKeyTestamentExtraction)
					.HasForeignKey(entity => entity.ParentKeyTestamentExtractionId);
            #endregion
        }
        #endregion
    }
}
