using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Domain
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier .
        /// </summary>
        public Guid Id { get; set; }


     
    }
}
