using FarmerApp.Data.Entities;
using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmerApp.Data.DAO
{
    public class FarmerDbContext : DbContext
    {
        public FarmerDbContext(DbContextOptions<FarmerDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<InvestorEntity> Investors { get; set; }
        public DbSet<InvestmentEntity> Investments { get; set; }
        public DbSet<TreatmentEntity> Treatments { get; set; }
        public DbSet<TargetEntity> Targets { get; set; }
        public DbSet<MeasurementUnitEntity> MeasurementUnits { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).LastUpdatedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyGlobalFilter("IsDeleted", false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
