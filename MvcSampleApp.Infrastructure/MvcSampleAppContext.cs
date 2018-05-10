using MvcSampleApp.Core;
using System.Data.Entity;
using MvcSampleApp.Core.Entities;


namespace MvcSampleApp.Infrastructure
{
    public class MvcSampleAppContext : DbContext
    {

        #region Constructors
        public MvcSampleAppContext()
            : base("name=MvcAppContextConnectionString")
        {
        }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasRequired(t => t.Company)
                .WithMany(t => t.Employees)
                .HasForeignKey(d => d.CompanyId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
        #region DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        #endregion
    }
}
