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
	public interface IBaseFrameworRepository<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		long GetCount();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		long GetCount(Expression<Func<TEntity, bool>> expression);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		IQueryable<TEntity> Get(ConditionFilter<TEntity, TEntityIdentity> condition = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TEntity Get(TEntityIdentity id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		IEnumerable<TEntity> Add(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		TEntity Add(TEntity entity);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		IEnumerable<TEntity> Update(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		TEntity Update(TEntity entity);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		void Delete(IEnumerable<TEntity> entityCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		void Delete(TEntity entity);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCollection"></param>
		void Delete(IEnumerable<TEntityIdentity> idCollection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		int Delete(TEntityIdentity id);
		#endregion
	}
}
