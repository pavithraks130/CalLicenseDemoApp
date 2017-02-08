namespace CalLicense.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpireDateTouserLicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLicense", "ExpireLicense", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLicense", "ExpireLicense");
        }
    }
}
