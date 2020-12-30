namespace MatrixTest.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeroName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "Name", c => c.String(maxLength: 256, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "Name");
        }
    }
}
