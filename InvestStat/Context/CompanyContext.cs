using InvestStat.model;
using System.Data.Entity;


namespace InvestStat.Context
{
    class CompanyContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public CompanyContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>();
        }

    }
}
