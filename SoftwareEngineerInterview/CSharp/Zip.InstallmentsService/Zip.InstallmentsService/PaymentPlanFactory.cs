using System;
using System.Collections.Generic;
using Zip.InstallmentsService.Models;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory : IPaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="PaymentPlanViewModel">PaymentPlanViewModel is request object</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(PaymentPlanViewModel paymentPlanViewModel)
        {
            var paymentPlan = new PaymentPlan();

           
            List<Installment> installmentsList = new List<Installment>();
          
            paymentPlan.Id = Guid.NewGuid();
            paymentPlan.PurchaseAmount=paymentPlanViewModel.PurchaseAmount;

            var resultAmount = paymentPlanViewModel.PurchaseAmount / paymentPlanViewModel.NumberOfInstallments;

            for(var count=0; count < paymentPlanViewModel.NumberOfInstallments; count++)
            {
                var installments = new Installment();
                installments.Id = Guid.NewGuid();
                installments.Amount = resultAmount;
                installments.DueDate =paymentPlanViewModel.PurchaseDate.AddDays(paymentPlanViewModel.Frequency * count).ToShortDateString();
                installmentsList.Add(installments);
                
            }
            paymentPlan.Installments = installmentsList;
            return paymentPlan;
        }
    }
}
