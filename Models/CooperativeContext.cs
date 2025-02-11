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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Ensure Correct Foreign Key for Payments Table
            modelBuilder.Entity<Payments>()
                .HasOne<Members>()
                .WithMany()
                .HasForeignKey(p => p.Member_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payments>()
                .HasOne<Loans>()
                .WithMany()
                .HasForeignKey(p => p.Loan_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Remove the reference to `l.Member`
            modelBuilder.Entity<Loans>()
                .HasOne<Members>()
                .WithMany()
                .HasForeignKey(l => l.Member_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Ensure Correct Foreign Key for DataUsers Table
            modelBuilder.Entity<DataUsers>()
                .HasOne<Members>()
                .WithMany()
                .HasForeignKey(d => d.Member_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
