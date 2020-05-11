#region Using ...
using Framework.Common.Interfaces;
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories.Base;
using MersalAccountingService.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Repositories.Base
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TEntityIdentity"></typeparam>
	public class BaseServiceRepositoryAsync<TEntity, TEntityIdentity> : BaseFrameworkRepositoryAsync<TEntity, TEntityIdentity>,
		IBaseServiceRepositoryAsync<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BaseServiceRepository.
		/// </summary>
		/// <param name="context"></param>
		public BaseServiceRepositoryAsync(MersalAccountingContext context)
			: base(context)
		{

		}
		#endregion
	}
}
