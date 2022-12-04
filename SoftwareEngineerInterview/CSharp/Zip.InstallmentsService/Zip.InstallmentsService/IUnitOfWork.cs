using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentPlanFactory PaymentPlanFactory { get; }
    }
}
