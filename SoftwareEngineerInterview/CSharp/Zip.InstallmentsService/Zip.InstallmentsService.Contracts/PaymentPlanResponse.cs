using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Contracts
{
    public class PaymentPlanResponse
    {

        /// <summary>
        /// Gets or sets the payment plan GUID 
        /// </summary>
        public Guid PaymentPlanId { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        public List<InstallmentResponse> Installments { get; set; }

   
        /// <summary>
        /// Used to create List of Installments object
        /// </summary>
        public PaymentPlanResponse()
        {
            Installments = new List<InstallmentResponse>();
        }
    }
}
