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
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly SuSDbContext _context;
        private IDbSet<T> _entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if(_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }


        public EfRepository()
        {
            _context = SuSDbContext.Create();
        }


        protected string GetErrorText(DbEntityValidationException dbEx)
        {
            string errorMsg = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    errorMsg += String.Format("PropertyName: {0}, Error: {1}{2}", error.PropertyName, error.ErrorMessage, Environment.NewLine);

            return errorMsg;
        }


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

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public void GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
