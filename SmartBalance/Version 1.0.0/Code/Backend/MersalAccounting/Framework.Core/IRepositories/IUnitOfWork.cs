#region Using ...
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Core.IRepositories
{
	/// <summary>
	/// 
	/// </summary>
	public interface IUnitOfWork
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		void Commit();
        DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);


        #endregion
    }
}
