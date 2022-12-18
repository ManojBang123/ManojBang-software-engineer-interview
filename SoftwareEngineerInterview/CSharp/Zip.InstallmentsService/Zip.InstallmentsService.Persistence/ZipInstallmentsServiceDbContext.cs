using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Domain;
namespace Zip.InstallmentsService.Persistence
{
    /// <summary>
    /// Used to hold database context for installment service
    /// </summary>
    public class ZipInstallmentsServiceDbContext : DbContext
    {
    

        /// <summary>
        /// Creates instance of ZipInstallmentsServiceDbContext
        /// </summary>
        /// <param name="options"><see cref="DbContextOptions"/></param>
        public ZipInstallmentsServiceDbContext(DbContextOptions options) : base(options)
        {
        }

   



        /// <summary>
        /// Gets or sets the database set forInstallment
        /// </summary>
        public DbSet<Installment> Installments { get; set; }

        /// <summary>
        /// Gets or sets the database set for PaymentPlan
        /// </summary>
        public DbSet<PaymentPlan> PaymentPlans { get; set; }

    
    }
}
