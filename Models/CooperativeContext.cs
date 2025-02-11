using Microsoft.EntityFrameworkCore;
namespace Cooperative_Financing.Models
{
    public class CooperativeContext : DbContext
    {
        public CooperativeContext(DbContextOptions<CooperativeContext> options)
            : base(options)
        {
        }
        public DbSet<Members> Members { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<DataUsers> DataUsers { get; set; }

    }
}
