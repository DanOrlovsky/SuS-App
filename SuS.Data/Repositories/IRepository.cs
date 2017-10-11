using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Repositories
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get a single entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);
        
        /// <summary>
        /// Add a single entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Add a range of entities
        /// </summary>
        /// <param name="entities"></param>
        void Add(ICollection<T> entities);

        /// <summary>
        /// Update a single entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Update a range of entities
        /// </summary>
        /// <param name="entities"></param>
        void Update(ICollection<T> entities);

        /// <summary>
        /// Remove a single entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        void Remove(ICollection<T> entities);

        /// <summary>
        /// Returns the full table
        /// </summary>
        IQueryable<T> DataTable { get; }
    }
}
