using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Domain.Repositories;
using Zip.InstallmentsService.Domain.UnitOfWork;
using Zip.InstallmentsService.Persistence.Repositories;

namespace Zip.InstallmentsService.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ZipInstallmentsServiceDbContext _dbContext;
        private IPaymentPlanRepository _paymentPlanRepository;
        public UnitOfWork(ZipInstallmentsServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPaymentPlanRepository PaymentPlanRepository
        {
            get {
                return _paymentPlanRepository =_paymentPlanRepository ?? new PaymentPlanRepository(_dbContext);
                    }
           // set {                _paymentPlanRepository=    new PaymentPlanRepository(_dbContext); }
        }

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
