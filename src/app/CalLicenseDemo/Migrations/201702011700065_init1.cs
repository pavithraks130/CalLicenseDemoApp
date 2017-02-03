using System.Data.Entity.Migrations;

namespace CalLicenseDemo.Migrations
{
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.UserModel", "User");
        }

        public override void Down()
        {
            RenameTable("dbo.User", "UserModel");
        }
    }
}