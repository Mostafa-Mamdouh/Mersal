﻿#region Using ...
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
	public class PaymentMovmentDiscountNotificationMap : EntityTypeConfiguration<PaymentMovmentDiscountNotification>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// PaymentMovmentMap.
		/// </summary>
		public PaymentMovmentDiscountNotificationMap()
		{

        }
        #endregion
    }
}
