using System.Data.Entity;

namespace ElectronicLogbookContext
{
    public class DbInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DbInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}