using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Repositories
{
    public partial interface IRepository<T> where T : BaseEntity
    {

        void GetById(object id);

        void Add(T entity);
        void Add(ICollection<T> entities);

        void Remove(T entity);
        void Remove(ICollection<T> entities);

        IQueryable<T> Table { get; }
    }
}
