namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLicPropNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLicense", "ExpirationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserLicense", "ExpireLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLicense", "ExpireLicense", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserLicense", "ExpirationDate");
        }
    }
}
