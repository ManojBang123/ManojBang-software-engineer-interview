using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Contracts
{
    public class InstallmentResponse
    {
        /// <summary>
        /// Gets or sets the installment amount 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the installment GUID identifier
        /// </summary>
        public Guid InstallmentId { get; set; }
    }
}
