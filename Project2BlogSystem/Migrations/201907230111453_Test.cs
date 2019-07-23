namespace Project2BlogSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Tag");
        }
    }
}
