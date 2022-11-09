namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldincourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Credit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Credit");
        }
    }
}
