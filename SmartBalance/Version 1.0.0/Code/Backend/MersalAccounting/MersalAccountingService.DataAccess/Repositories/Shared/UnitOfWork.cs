#region Using ...
using Framework.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public class UnitOfWork : IUnitOfWork
    {
        #region Data Members
        private MersalAccountingContext _context;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UnitOfWork.
		/// </summary>
		/// <param name="context"></param>
		public UnitOfWork(MersalAccountingContext context)
        {
            this._context = context;
        }
        #endregion

        #region IUnitOfWork
        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            this._context.SaveChanges();
        }
        public DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters)
        {
            return this._context.Database.SqlQuery<T>(sql, parameters);
        }
        #endregion        
    }
}
