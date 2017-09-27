namespace MVCCRUDWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddageInTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer2", "Age", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer2", "Age");
        }
    }
}
