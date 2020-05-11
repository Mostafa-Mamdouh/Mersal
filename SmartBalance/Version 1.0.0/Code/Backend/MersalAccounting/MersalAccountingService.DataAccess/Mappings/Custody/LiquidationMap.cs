using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.DataAccess.Mappings
{
    public class LiquidationMap : EntityTypeConfiguration<Liquidation>
    {
        public LiquidationMap()
        {

        }
    }
}
