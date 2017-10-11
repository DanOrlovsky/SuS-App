using SuS.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Repositories
{
    // Entity Framework Repository Class
    // All Repositories will inherit the functionality of this class
    public partial class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        // Connection to the context
        private readonly SuSDbContext _context;

        // Private table object
        private IDbSet<T> _entities;
        #endregion

        #region Properties
        /// <summary>
        /// Entities Object
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if(_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        /// <summary>
        /// public DataTable
        /// </summary>
        public IQueryable<T> DataTable
        {
            get
            {
                return Entities;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Repository()
        /// </summary>
        public Repository()
        {
            _context = SuSDbContext.Create();
        }
        #endregion


        #region Methods

        /// <summary>
        /// Builds an error string from the DbEntityValidationException object
        /// </summary>
        /// <param name="dbEx"></param>
        /// <returns></returns>
        protected string GetErrorText(DbEntityValidationException dbEx)
        {
            string errorMsg = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    errorMsg += String.Format("PropertyName: {0}, Error: {1}{2}", error.PropertyName, error.ErrorMessage, Environment.NewLine);

            return errorMsg;
        }

        /// <summary>
        /// Gets the error from DbEntityValidationException object and ensures nothing was changed in the database.
        /// </summary>
        /// <param name="dbEx"></param>
        /// <returns></returns>
        protected string GetErrorAndRollBackChanges(DbEntityValidationException dbEx)
        {
            var fullErrorText = GetErrorText(dbEx);
            foreach(var entry in dbEx.EntityValidationErrors.Select(error => error.Entry))
            {
                if (entry == null)
                    continue;
                entry.State = EntityState.Unchanged;
            }

            _context.SaveChanges();

            return fullErrorText;
        }

        /// <summary>
        /// Gets a single entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        public T GetById(object id)
        {
            // Convert to int to use SingleOrDefault - 100X faster than .Find()
            int intId = Convert.ToInt32(id);
            return Entities.SingleOrDefault(x => x.Id == intId);
        }

        /// <summary>
        /// Adds a single entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetErrorAndRollBackChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Adds a collection of entities
        /// </summary>
        /// <param name="entities"></param>
        public void Add(ICollection<T> entities)
        {
            try
            {
                if (entities.Count < 1)
                    throw new ArgumentNullException(nameof(entities));

                foreach(T entity in entities)
                    Entities.Add(entity);
                
                _context.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
            {
                throw new Exception(GetErrorAndRollBackChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Removes a single entity
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetErrorAndRollBackChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Removes a collection of entities
        /// </summary>
        /// <param name="entities"></param>
        public void Remove(ICollection<T> entities)
        {
            try
            {
                if (entities.Count < 1)
                    throw new ArgumentNullException(nameof(entities));
                foreach (T entity in entities)
                    Entities.Add(entity);
                _context.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
            {
                throw new Exception(GetErrorAndRollBackChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Updates a single entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a collection of entities
        /// </summary>
        /// <param name="entities"></param>
        public void Update(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
