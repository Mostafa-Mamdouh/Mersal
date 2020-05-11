﻿using MersalAccountingService.Core.IRepositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IRepositories
{
    public interface ILiquidationRepository : IBaseServiceRepository<Liquidation, long>
    {
    }
}
