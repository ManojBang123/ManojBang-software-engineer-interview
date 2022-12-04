using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Models;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Interface IPaymentPlanFactory - method declartion to create Payment Plan 
    /// </summary>
    public interface IPaymentPlanFactory
    {
        PaymentPlan CreatePaymentPlan(PaymentPlanViewModel paymentPlanViewModel);
    }
}
