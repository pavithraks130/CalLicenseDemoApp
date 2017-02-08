namespace CalLicense.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMaxLengthUniqueKeyToEmailInUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 500));
            CreateIndex("dbo.User", "Email", unique: true, name: "Ix_EmailUniqueKey");
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", "Ix_EmailUniqueKey");
            AlterColumn("dbo.User", "Email", c => c.String());
        }
    }
}
