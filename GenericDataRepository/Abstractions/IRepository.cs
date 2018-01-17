using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataRepository.Abstractions
{
    public interface IRepository : IReadOnlyRepository
    {
        /// <summary>
        /// Adds TEntity to the collection that represents a row or collection for 
        /// saving in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="entity">object of type TEntity</param>
        /// <param name="createdBy">login details of user doing the adding</param>
        void Create<TEntity>(TEntity entity, string createdBy = null)
        where TEntity : class, IEntity;

        /// <summary>
        /// Modifies TEntity to the collection that represents a row or collection for 
        /// saving in persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="entity">object of type TEntity</param>
        /// <param name="modifiedBy">login details of user doing the modifying</param>
        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Removes TEntity from the collection that represents a row or collection from persistence
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="id">key of TEntity in persistence</param>
        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        /// <summary>
        /// Remove TEntity from persistence by taking in an object of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">reference type that implements IEntity</typeparam>
        /// <param name="entity">object of type TEntity</param>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        /// <summary>
        /// Transactionally save all changes made to persistence or rollback
        /// </summary>
        void Save();

        /// <summary>
        /// Asynchronously and Transactionally save all changes made to persistence or rollback
        /// </summary>
        Task SaveAsync();
    }
}
