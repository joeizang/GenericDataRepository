using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataRepository.Abstractions
{
    public interface IReadOnlyRepository
    {
        /// <summary>
        /// Return an Enumerable collection of classes that implement the interface IEntity
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="orderBy">Linq expression to order collection being returned</param>
        /// <param name="includeProperties">name of all the entities being eager loaded</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>IEnumerable<TEntity></returns>
        IEnumerable<TEntity> GetAll<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously Return an Enumerable collection of classes that implement the interface IEntity
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="orderBy">Linq expression to order collection being returned</param>
        /// <param name="includeProperties">name of all the entities being eager loaded</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>Task<IEnumerable<TEntity>></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Return a filtered collection of Entities that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="orderBy">Linq expression to order collection being returned</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>IEnumerable<TEntity></returns>
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously return a filtered collection of Entities that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="orderBy">Linq expression to order collection being returned</param>
        /// /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>Task<IEnumerable<TEntity>></returns>
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Return an Entity from persistence that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>TEntity</returns>
        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously return an Entity from persistence that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>Task<TEntity></returns>
        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Return the first Entity from persistence that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>TEntity</returns>
        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously return the first Entity from persistence that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="includeProperties">name of entities that are being eager loaded</param>
        /// <param name="filter">Linq expression that acts as a predicate for any filtering</param>
        /// <param name="skip">value to omit when making a paginated collection of results</param>
        /// <param name="take">value which is the number of entities to return in the collection.</param>
        /// <returns>Task<TEntity></returns>
        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Return an Entity from persistence, based on submitted id, that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="id">id of the entity sought for in persistence</param>
        /// <returns>TEntity</returns>
        TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously return an Entity from persistence, based on submitted id, 
        /// that implements IEntity interface
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="id">id of the entity sought for in persistence</param>
        /// <returns>Task<TEntity></returns>
        Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class, IEntity;

        /// <summary>
        /// Aggregate and count the number of times an entity occurs in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="filter">Linq expression to filter the aggregation operation</param>
        /// <returns>Task<int></returns>
        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Aggregate and count the number of times an entity occurs in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="filter">Linq expression to filter the aggregation operation</param>
        /// <returns>Task<int></returns>
        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Verifies that TEntity exists in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="filter">Linq expression to filter the aggregation operation</param>
        /// <returns>bool</returns>
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Asynchronously verifies if TEntity exists in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="filter">Linq expression to filter the operation</param>
        /// <returns>Task<bool></returns>
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
    }
}
