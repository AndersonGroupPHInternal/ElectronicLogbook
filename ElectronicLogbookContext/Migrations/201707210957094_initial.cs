namespace ElectronicLogbookContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        CompanyName = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        PersonToVisit = c.String(maxLength: 50),
                        IdNumber = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitor");
        }
    }
}
