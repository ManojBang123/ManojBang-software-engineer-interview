using System;
using System.ComponentModel.DataAnnotations;
using Zip.InstallmentsService.Domain;

namespace Zip.InstallmentsService.Domain
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment : BaseEntity
    {
       
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }


        /// <summary>
        /// Gets or sets the date in specific date format that the installment payment is due.
        /// </summary>
        /// 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public String DueDate { get; set; }
    }
}
