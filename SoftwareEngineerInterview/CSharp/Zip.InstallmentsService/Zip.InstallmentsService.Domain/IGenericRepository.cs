using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T Get(Expression<Func<T, bool>> expression);
    }
}
