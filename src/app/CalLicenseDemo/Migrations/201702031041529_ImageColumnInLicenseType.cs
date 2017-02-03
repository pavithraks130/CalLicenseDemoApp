namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageColumnInLicenseType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LicenseType", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LicenseType", "ImageUrl");
        }
    }
}
