namespace MvcSampleApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        CompanyLogo = c.Binary(),
                        ConceptionDate = c.DateTimeOffset(precision: 7),
                        CreatedBy = c.Guid(),
                        CreatedDateTime = c.DateTimeOffset(precision: 7),
                        UpdatedBy = c.Guid(),
                        UpdatedDateTime = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        MaritalStatus = c.String(),
                        NationalIdNo = c.String(),
                        Image = c.Binary(),
                        CompanyId = c.Guid(),
                        CreatedBy = c.Guid(),
                        CreatedDateTime = c.DateTimeOffset(precision: 7),
                        UpdatedBy = c.Guid(),
                        UpdatedDateTime = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
