using InvestStat.model;
using System.Data.Entity;


namespace InvestStat.Context
{
    class CompanySWOTContext:DbContext
    {
        public DbSet<CompanySWOT> CompanySWOT { get; set; }

        public CompanySWOTContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanySWOT>();
        }

    }
}
