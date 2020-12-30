namespace MatrixTest.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailToUniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Trainers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainers", new[] { "Email" });
        }
    }
}
