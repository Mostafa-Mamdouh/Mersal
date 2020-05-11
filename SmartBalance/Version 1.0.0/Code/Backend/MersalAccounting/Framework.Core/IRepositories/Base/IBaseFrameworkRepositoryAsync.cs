#region Using ...
using Framework.Common.Interfaces;
using Framework.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Core.IRepositories.Base
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TEntityIdentity"></typeparam>
	public interface IBaseFrameworkRepositoryAsync<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<long> GetCountAsync();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		Task<IQueryable<TEntity>> GetAsync(ConditionFilter<TEntity, TEntityIdentity> condition = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<TEntity> GetAsync(TEntityIdentity id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		Task<TEntity> AddAsync(TEntity entity);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		Task<TEntity> UpdateAsync(TEntity entity);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		Task DeleteAsync(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		Task DeleteAsync(TEntity entity);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCollection"></param>
		Task DeleteAsync(IEnumerable<TEntityIdentity> idCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		Task<int> DeleteAsync(TEntityIdentity id);
		#endregion
	}
}
