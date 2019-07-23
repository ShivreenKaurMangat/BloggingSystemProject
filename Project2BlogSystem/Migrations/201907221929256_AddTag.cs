namespace Project2BlogSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TAGId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        blog_ID = c.Int(),
                    })
                .PrimaryKey(t => t.TAGId)
                .ForeignKey("dbo.Blogs", t => t.blog_ID)
                .Index(t => t.blog_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "blog_ID", "dbo.Blogs");
            DropIndex("dbo.Tags", new[] { "blog_ID" });
            DropTable("dbo.Tags");
        }
    }
}
