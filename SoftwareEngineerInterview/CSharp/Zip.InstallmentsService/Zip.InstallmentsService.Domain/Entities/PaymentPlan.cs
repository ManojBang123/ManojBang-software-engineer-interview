using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService.Domain
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan : BaseEntity
    {
        public decimal PurchaseAmount { get; set; }

        public List<Installment> Installments { get; set; }

        public PaymentPlan(decimal purchaseAmount)
        {
            Id = Guid.NewGuid();
            Installments = new List<Installment>();
            PurchaseAmount = purchaseAmount;
        }

    }
}
