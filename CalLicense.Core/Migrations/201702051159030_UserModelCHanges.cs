namespace CalLicense.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelCHanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PasswordHash", c => c.String());
            AddColumn("dbo.User", "ThumbPrint", c => c.String());
            DropColumn("dbo.User", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Password", c => c.String());
            DropColumn("dbo.User", "ThumbPrint");
            DropColumn("dbo.User", "PasswordHash");
        }
    }
}
