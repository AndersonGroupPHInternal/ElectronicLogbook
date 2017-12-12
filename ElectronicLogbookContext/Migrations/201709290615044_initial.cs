namespace ElectronicLogbookContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        ApplyingFor = c.String(),
                        Designation = c.String(maxLength: 50),
                        TypeOfId = c.String(maxLength: 50),
                        IdNumber = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        Comment = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicantID);
            
            CreateTable(
                "dbo.InternHistory",
                c => new
                    {
                        InternHistoryID = c.Int(nullable: false, identity: true),
                        InternID = c.Int(nullable: false),
                        Date = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        School = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        IdNumber = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InternHistoryID)
                .ForeignKey("dbo.Intern", t => t.InternID, cascadeDelete: true)
                .Index(t => t.InternID);
            
            CreateTable(
                "dbo.Intern",
                c => new
                    {
                        InternID = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        School = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Supervisor = c.String(maxLength: 50),
                        IdNumber = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InternID);
            
            CreateTable(
                "dbo.VisitorHistory",
                c => new
                    {
                        VisitorHistoryID = c.Int(nullable: false, identity: true),
                        VisitorID = c.Int(nullable: false),
                        Date = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorHistoryID)
                .ForeignKey("dbo.Visitor", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID);
            
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
                        Designation = c.String(maxLength: 50),
                        IdNumber = c.String(maxLength: 50),
                        KindOfId = c.String(maxLength: 50),
                        TimeIn = c.String(maxLength: 50),
                        TimeOut = c.String(maxLength: 50),
                        Comment = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorID);

            CreateTable(
                "dbo.EmployeeLog",
                c => new
                {
                    EmployeeLogId = c.Int(nullable: false, identity: true),
                    EmployeeId = c.Int(nullable: false),
                    EmployeNumber = c.Int(nullable: false),
                    LogTypeId = c.Int(nullable: false),
                    LogDate = c.String(maxLength: 50)
                })
                .PrimaryKey(t => t.EmployeeId);

            CreateTable(
                "dbo.LogType",
                c => new
                {
                    LogTypeId = c.Int(nullable: false, identity: true)
                })
                .PrimaryKey(t => t.LogTypeId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitorHistory", "VisitorID", "dbo.Visitor");
            DropForeignKey("dbo.InternHistory", "InternID", "dbo.Intern");
            DropIndex("dbo.VisitorHistory", new[] { "VisitorID" });
            DropIndex("dbo.InternHistory", new[] { "InternID" });
            DropTable("dbo.Visitor");
            DropTable("dbo.VisitorHistory");
            DropTable("dbo.Intern");
            DropTable("dbo.InternHistory");
            DropTable("dbo.Applicant");
            DropTable("dbo.EmployeeLog");
            DropTable("dbo.LogType");
        }
    }
}
