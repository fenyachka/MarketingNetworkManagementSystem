using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
