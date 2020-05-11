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
	public class CostCenterBillMap : EntityTypeConfiguration<CostCenterBill>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CostCenterBillMap.
		/// </summary>
		public CostCenterBillMap()
		{
			
		}
		#endregion
	}
}
