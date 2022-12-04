using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.ViewModels
{
    /// <summary>
    /// Data structure which defines all the properties for Payment Plan details to be given .
    /// </summary>
    public class PaymentPlanViewModel
    {
        /// <summary>
        /// Gets or sets the Frequency for Payment Plan.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfInstallments for Payment Plan.
        /// </summary>
        public int NumberOfInstallments { get; set; }

        /// <summary>
        /// Gets or sets the purchase date that payment plan will be started.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the Purchase amount.
        /// </summary>
        public decimal PurchaseAmount { get; set; }
    }

}
