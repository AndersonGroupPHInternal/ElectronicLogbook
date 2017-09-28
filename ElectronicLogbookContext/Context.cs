using ElectronicLogbookEntity;
using System.Data.Entity;

namespace ElectronicLogbookContext
{
    public class Context : DbContext
    {

        public Context() : base("ElectronicLogbook")
        {
            Database.SetInitializer(new DbInitializer());

            if (Database.Exists())
            {
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DbInitializer());
            }
        }

        public DbSet<EVisitor> Visitors { get; set; }
        public DbSet<EIntern> Interns { get; set; }
        public DbSet<EVisitorHistory> VisitorHistory { get; set; }
        public DbSet<EInternHistory> InternHistory { get; set; }

    }
}
