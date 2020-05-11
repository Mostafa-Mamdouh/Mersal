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
	public class BaseFrameworkRepository<TEntity, TEntityIdentity> : IBaseFrameworkRepository<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		#region Data Members
		private DbContext _context;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BaseFrameworkRepository.
		/// </summary>
		/// <param name="context"></param>
		public BaseFrameworkRepository(DbContext context)
		{
			this.Context = context;
		}
		#endregion

		#region IBaseRepository
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public long GetCount()
		{
			var result = this.Entities.LongCount();
			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public long GetCount(Expression<Func<TEntity, bool>> expression)
		{
			var result = this.Entities.LongCount(expression);
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public IQueryable<TEntity> Get(ConditionFilter<TEntity, TEntityIdentity> condition = null)
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
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TEntity Get(TEntityIdentity id)
		{
			var result = this.Entities.Find(id);
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		public IEnumerable<TEntity> Add(IEnumerable<TEntity> entityCollection)
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
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual TEntity Add(TEntity entity)
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
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		/// <returns></returns>
		public IEnumerable<TEntity> Update(IEnumerable<TEntity> entityCollection)
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
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public TEntity Update(TEntity entity)
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
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityCollection"></param>
		public void Delete(IEnumerable<TEntity> entityCollection)
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
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(TEntity entity)
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCollection"></param>
		public void Delete(IEnumerable<TEntityIdentity> idCollection)
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
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public int Delete(TEntityIdentity id)
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
