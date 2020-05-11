﻿#region Using ...
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpensesTypesRepository : BaseServiceRepository<ExpensesType, long>, IExpensesTypesRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpensesTypesRepository.
        /// </summary>
        /// <param name="context"></param>
        public ExpensesTypesRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion
    }
}
