using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Domain;
using Zip.InstallmentsService.Domain.Repositories;

namespace Zip.InstallmentsService.Persistence.Repositories
{
    public class PaymentPlanRepository : GenericRepository<PaymentPlan>, IPaymentPlanRepository
    {
        public PaymentPlanRepository(ZipInstallmentsServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
