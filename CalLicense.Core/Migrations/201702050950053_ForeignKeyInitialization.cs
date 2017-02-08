namespace CalLicense.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyInitialization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLicense", "UserId", "dbo.User");
            DropIndex("dbo.UserLicense", new[] { "UserId" });
            RenameColumn(table: "dbo.UserLicense", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.License", "LicenseType_TypeId", c => c.Int());
            AddColumn("dbo.User", "Organization_TeamId", c => c.Int());
            AddColumn("dbo.UserLicense", "License_LicenseId", c => c.Int());
            AlterColumn("dbo.UserLicense", "User_UserId", c => c.Int());
            CreateIndex("dbo.License", "LicenseType_TypeId");
            CreateIndex("dbo.User", "Organization_TeamId");
            CreateIndex("dbo.UserLicense", "License_LicenseId");
            CreateIndex("dbo.UserLicense", "User_UserId");
            AddForeignKey("dbo.License", "LicenseType_TypeId", "dbo.LicenseType", "TypeId");
            AddForeignKey("dbo.UserLicense", "License_LicenseId", "dbo.License", "LicenseId");
            AddForeignKey("dbo.User", "Organization_TeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.UserLicense", "User_UserId", "dbo.User", "UserId");
            DropColumn("dbo.License", "LicenseTypeId");
            DropColumn("dbo.User", "TeamID");
            DropColumn("dbo.UserLicense", "LicenseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLicense", "LicenseId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "TeamID", c => c.Int(nullable: false));
            AddColumn("dbo.License", "LicenseTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserLicense", "User_UserId", "dbo.User");
            DropForeignKey("dbo.User", "Organization_TeamId", "dbo.Team");
            DropForeignKey("dbo.UserLicense", "License_LicenseId", "dbo.License");
            DropForeignKey("dbo.License", "LicenseType_TypeId", "dbo.LicenseType");
            DropIndex("dbo.UserLicense", new[] { "User_UserId" });
            DropIndex("dbo.UserLicense", new[] { "License_LicenseId" });
            DropIndex("dbo.User", new[] { "Organization_TeamId" });
            DropIndex("dbo.License", new[] { "LicenseType_TypeId" });
            AlterColumn("dbo.UserLicense", "User_UserId", c => c.Int(nullable: false));
            DropColumn("dbo.UserLicense", "License_LicenseId");
            DropColumn("dbo.User", "Organization_TeamId");
            DropColumn("dbo.License", "LicenseType_TypeId");
            RenameColumn(table: "dbo.UserLicense", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.UserLicense", "UserId");
            AddForeignKey("dbo.UserLicense", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
