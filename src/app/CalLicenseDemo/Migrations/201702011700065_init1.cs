namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserModel", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.User", newName: "UserModel");
        }
    }
}
