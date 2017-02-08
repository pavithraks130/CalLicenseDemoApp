namespace CalLicense.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LicenseModelCHanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.License", "LicenseType_TypeId", "dbo.LicenseType");
            DropIndex("dbo.License", new[] { "LicenseType_TypeId" });
            RenameColumn(table: "dbo.License", name: "LicenseType_TypeId", newName: "LicenseTypeId");
            AlterColumn("dbo.License", "LicenseTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.License", "LicenseTypeId");
            AddForeignKey("dbo.License", "LicenseTypeId", "dbo.LicenseType", "TypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.License", "LicenseTypeId", "dbo.LicenseType");
            DropIndex("dbo.License", new[] { "LicenseTypeId" });
            AlterColumn("dbo.License", "LicenseTypeId", c => c.Int());
            RenameColumn(table: "dbo.License", name: "LicenseTypeId", newName: "LicenseType_TypeId");
            CreateIndex("dbo.License", "LicenseType_TypeId");
            AddForeignKey("dbo.License", "LicenseType_TypeId", "dbo.LicenseType", "TypeId");
        }
    }
}
