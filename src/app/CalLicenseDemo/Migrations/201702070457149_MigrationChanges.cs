namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Organization_TeamId", "dbo.Team");
            DropForeignKey("dbo.UserLicense", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserLicense", "License_LicenseId", "dbo.License");
            DropIndex("dbo.User", new[] { "Organization_TeamId" });
            DropIndex("dbo.UserLicense", new[] { "License_LicenseId" });
            DropIndex("dbo.UserLicense", new[] { "User_UserId" });
            RenameColumn(table: "dbo.User", name: "Organization_TeamId", newName: "TeamId");
            RenameColumn(table: "dbo.UserLicense", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.UserLicense", name: "License_LicenseId", newName: "LicenseId");
            AlterColumn("dbo.User", "TeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLicense", "LicenseId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLicense", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "TeamId");
            CreateIndex("dbo.UserLicense", "UserId");
            CreateIndex("dbo.UserLicense", "LicenseId");
            AddForeignKey("dbo.User", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.UserLicense", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserLicense", "LicenseId", "dbo.License", "LicenseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLicense", "LicenseId", "dbo.License");
            DropForeignKey("dbo.UserLicense", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "TeamId", "dbo.Team");
            DropIndex("dbo.UserLicense", new[] { "LicenseId" });
            DropIndex("dbo.UserLicense", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "TeamId" });
            AlterColumn("dbo.UserLicense", "UserId", c => c.Int());
            AlterColumn("dbo.UserLicense", "LicenseId", c => c.Int());
            AlterColumn("dbo.User", "TeamId", c => c.Int());
            RenameColumn(table: "dbo.UserLicense", name: "LicenseId", newName: "License_LicenseId");
            RenameColumn(table: "dbo.UserLicense", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.User", name: "TeamId", newName: "Organization_TeamId");
            CreateIndex("dbo.UserLicense", "User_UserId");
            CreateIndex("dbo.UserLicense", "License_LicenseId");
            CreateIndex("dbo.User", "Organization_TeamId");
            AddForeignKey("dbo.UserLicense", "License_LicenseId", "dbo.License", "LicenseId");
            AddForeignKey("dbo.UserLicense", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.User", "Organization_TeamId", "dbo.Team", "TeamId");
        }
    }
}
