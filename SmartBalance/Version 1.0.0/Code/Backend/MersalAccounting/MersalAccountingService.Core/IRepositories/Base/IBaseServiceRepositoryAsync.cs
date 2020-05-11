#region Using ...
using Framework.Common.Interfaces;
using Framework.Core.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IRepositories.Base
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TEntityIdentity"></typeparam>
	public interface IBaseServiceRepositoryAsync<TEntity, TEntityIdentity> : IBaseFrameworkRepositoryAsync<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{

	}
}
