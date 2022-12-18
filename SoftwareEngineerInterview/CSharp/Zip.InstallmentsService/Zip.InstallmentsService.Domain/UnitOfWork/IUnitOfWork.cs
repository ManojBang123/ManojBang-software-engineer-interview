using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Domain.Repositories;

namespace Zip.InstallmentsService.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPaymentPlanRepository PaymentPlanRepository { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
