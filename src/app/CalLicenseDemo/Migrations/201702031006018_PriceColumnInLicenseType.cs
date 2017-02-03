namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceColumnInLicenseType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LicenseType", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LicenseType", "Price");
        }
    }
}
