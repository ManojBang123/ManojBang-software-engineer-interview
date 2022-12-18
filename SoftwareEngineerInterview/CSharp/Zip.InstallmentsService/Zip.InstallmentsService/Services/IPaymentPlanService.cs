using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    /// Interface IPaymentPlanFactory - method declartion to create Payment Plan 
    /// </summary>
    public interface IPaymentPlanService
    {
        Task<PaymentPlanResponse> CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest);
    }
}
