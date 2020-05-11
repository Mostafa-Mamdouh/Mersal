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
	public class PaymentMethodMap : EntityTypeConfiguration<PaymentMethod>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// PaymentMethodMap.
		/// </summary>
		public PaymentMethodMap()
		{
			#region Configure Relations For Foreign Key ParentKeyPaymentMethodId
			this.HasMany(entity => entity.ChildTranslatedPaymentMethods)
					.WithOptional(entity => entity.ParentKeyPaymentMethod)
					.HasForeignKey(entity => entity.ParentKeyPaymentMethodId);
			#endregion
		}
		#endregion
	}
}
