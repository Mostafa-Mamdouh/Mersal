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
	public class BrandMap : EntityTypeConfiguration<Brand>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// BrandMap.
		/// </summary>
		public BrandMap()
		{
			#region Configure Relations For Foreign Key ParentKeyBrandId
			this.HasMany(entity => entity.ChildTranslatedBrands)
					.WithOptional(entity => entity.ParentKeyBrand)
					.HasForeignKey(entity => entity.ParentKeyBrandId);
            #endregion

            #region Configure Relations For Foreign Key ParentBrandId
            this.HasMany(entity => entity.ChildBrands)
                    .WithOptional(entity => entity.ParentBrand)
                    .HasForeignKey(entity => entity.ParentBrandId);
            #endregion
        }
        #endregion
    }
}
