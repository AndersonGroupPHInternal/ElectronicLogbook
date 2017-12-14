using ElectronicLogbookEntity;
using System;
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
            context.LogType.Add(
                new ELogType
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Time In"
                });
            context.LogType.Add(
                new ELogType
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Time Out"
                });
            base.Seed(context);
        }
    }
}