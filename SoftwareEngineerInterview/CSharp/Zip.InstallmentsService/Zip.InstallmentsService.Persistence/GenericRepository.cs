using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Domain;

namespace Zip.InstallmentsService.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        protected readonly ZipInstallmentsServiceDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public GenericRepository(ZipInstallmentsServiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
           _dbContext.AddAsync(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
           return  _entitiySet.FirstOrDefault(expression);
        }
    }
}
