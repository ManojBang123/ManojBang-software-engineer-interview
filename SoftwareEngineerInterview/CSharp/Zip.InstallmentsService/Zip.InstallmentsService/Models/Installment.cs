using System;
using System.ComponentModel.DataAnnotations;

namespace Zip.InstallmentsService.Models
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment
    {
        /// <summary>
        /// Gets or sets the unique identifier for each installment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date in specific date format that the installment payment is due.
        /// </summary>
        /// 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public String DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
