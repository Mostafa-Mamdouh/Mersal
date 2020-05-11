#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Framework.Core.IRepositories.Base;
using Framework.Common.Interfaces;
using Framework.Core.Filters;
#endregion

namespace Framework.DataAccess.Repositories.Base
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TEntityIdentity"></typeparam>
	public class BaseFrameworkRepositoryAsync<TEntity, TEntityIdentity> : IBaseFrameworkRepositoryAsync<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		#region Data Members
		private DbContext _context;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BaseRepository.
		/// </summary>
		/// <param name="context"></param>
		public BaseFrameworkRepositoryAsync(DbContext context)
		{
			this.Context = context;
		}
		#endregion

		#region IBaseRepository
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Task<long> GetCountAsync()
		{
			return Task.Run(() =>
			{
				var result = this.Entities.LongCount();
				return result;
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression)
		{
			return Task.Run(() =>
			{
				var result = this.Entities.LongCount(expression);
				return result;
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public Task<IQueryable<TEntity>> GetAsync(ConditionFilter<TEntity, TEntityIdentity> condition = null)
		{
			return Task.Run(() =>
			{
				var result = this.Entities.AsQueryable();

				if (condition != null)
				{
					#region Include NavigationProperties
					foreach (var item in condition.NavigationProperties)
					{
						result.Include(item);
					}
					#endregion

					#region Specify an Order
					if (condition.Order == Common.Enums.Order.Ascending)
						result = result.OrderBy(entity => entity.Id).AsQueryable();
					else if (condition.Order == Common.Enums.Order.Descending)
						result = result.OrderByDescending(entity => entity.Id).AsQueryable();
					#endregion

					#region Add Query
					if (string.IsNullOrEmpty(condition.QueryString) == false)
					{
						result = result.Where(condition.QueryString, condition.FilterParams);
					}
					else if (condition.Query != null)
					{
						result = result.Where(condition.Query);
					}
					#endregion

					#region Detect Count
					condition.Count = result.LongCount();
					#endregion

					#region Add Pagination
					if (condition.PageIndex.HasValue &&
						condition.PageSize.HasValue)
					{
						result = result
							.Skip(condition.PageIndex.Value * condition.PageSize.Value)
							.Take(condition.PageSize.Value);
					}
					#endregion
				}

				return result;
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<TEntity> GetAsync(TEntityIdentity id)
		{
			return Task.Run(() =>
			{
				var result = this.Entities.Find(id);
				return result;
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		public Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entityCollection)
		{
			return Task.Run(() =>
			{
				if (entityCollection != null)
				{
					DateTime now = DateTime.Now;

					foreach (var entity in entityCollection)
					{
						if (entity is IEntityDateTimeSignature)
						{
							var entityDate = ((IEntityDateTimeSignature)entity);
							entityDate.CreationDate = now;
						}
						this.Context.Entry<TEntity>(entity).State = EntityState.Added;
					}
				}
				return entityCollection;
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual Task<TEntity> AddAsync(TEntity entity)
		{
			return Task.Run(() =>
			{
				if (entity != null)
				{
					DateTime now = DateTime.Now;

					if (entity is IEntityDateTimeSignature)
					{
						var entityDate = ((IEntityDateTimeSignature)entity);
						entityDate.CreationDate = now;
					}
					this.Context.Entry<TEntity>(entity).State = EntityState.Added;
				}
				return entity;
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		public Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entityCollection)
		{
			return Task.Run(() =>
			{
				if (entityCollection != null)
				{
					DateTime now = DateTime.Now;

					foreach (var entity in entityCollection)
					{
						if (entity is IEntityDateTimeSignature)
						{
							var entityDate = ((IEntityDateTimeSignature)entity);

							if (entityDate.FirstModificationDate.HasValue)
								entityDate.LastModificationDate = now;
							else
								entityDate.FirstModificationDate = now;
						}
						this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
					}
				}
				return entityCollection;
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<TEntity> UpdateAsync(TEntity entity)
		{
			return Task.Run(() =>
			{
				if (entity != null)
				{
					DateTime now = DateTime.Now;

					if (entity is IEntityDateTimeSignature)
					{
						var entityDate = ((IEntityDateTimeSignature)entity);

						if (entityDate.FirstModificationDate.HasValue)
							entityDate.LastModificationDate = now;
						else
							entityDate.FirstModificationDate = now;
					}
					this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
				}
				return entity;
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		public Task DeleteAsync(IEnumerable<TEntity> entityCollection)
		{
			return Task.Run(() =>
			{
				if (entityCollection != null)
				{
					foreach (var entity in entityCollection)
					{
						if (entity != null)
						{
							if (entity is IVirtualDelete)
							{
								var virtualDeleteEntity = (IVirtualDelete)entity;

								virtualDeleteEntity.IsDeleted = true;
								virtualDeleteEntity.LastDeletedDate = DateTime.Now;
							}
							else
							{
								this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
							}
						}
					}
				}
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public Task DeleteAsync(TEntity entity)
		{
			return Task.Run(() =>
			{
				if (entity != null)
				{
					if (entity is IVirtualDelete)
					{
						var virtualDeleteEntity = (IVirtualDelete)entity;

						virtualDeleteEntity.IsDeleted = true;
						virtualDeleteEntity.LastDeletedDate = DateTime.Now;
					}
					else
					{
						this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
					}
				}
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCollection"></param>
		public Task DeleteAsync(IEnumerable<TEntityIdentity> idCollection)
		{
			return Task.Run(() =>
			{
				if (idCollection != null)
				{
					foreach (var id in idCollection)
					{
						var entity = this.Entities.Find(id);

						if (entity is IVirtualDelete)
						{
							var virtualDeleteEntity = (IVirtualDelete)entity;

							virtualDeleteEntity.IsDeleted = true;
							virtualDeleteEntity.LastDeletedDate = DateTime.Now;
						}
						else
						{
							this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
						}
					}
				}
			});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public Task<int> DeleteAsync(TEntityIdentity id)
		{
			return Task.Run(() =>
			{
				var entity = this.Entities.Find(id);

				if (entity == null)
					return 0;


				if (entity is IVirtualDelete)
				{
					var virtualDeleteEntity = (IVirtualDelete)entity;

					virtualDeleteEntity.IsDeleted = true;
					virtualDeleteEntity.LastDeletedDate = DateTime.Now;
				}
				else
				{
					this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
				}

				return 1;
			});
		}
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		protected DbContext Context
		{
			get { return this._context; }
			private set
			{
				this._context = value;
				this.Entities = this._context.Set<TEntity>();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		protected IDbSet<TEntity> Entities { get; private set; }
		#endregion
	}
}
