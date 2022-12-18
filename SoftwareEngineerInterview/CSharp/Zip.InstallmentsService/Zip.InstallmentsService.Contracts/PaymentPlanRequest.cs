using System.Text.Json;

namespace Zip.InstallmentsService.Contracts
{
    public class PaymentPlanRequest
    {
        /// <summary>
        /// Gets or sets  Frequency
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the number of installments
        /// </summary>
        public int NumberOfInstallments { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// Gets or sets the purchase date
        /// </summary>
        public DateTime PurhcaseDate { get; set; }


      

    }
}