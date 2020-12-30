namespace MatrixTest.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOG_AuditLogs",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 256, unicode: false),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512, unicode: false),
                        RecordId = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.LOG_AuditLogDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256, unicode: false),
                        OriginalValue = c.String(maxLength: 2000, unicode: false),
                        NewValue = c.String(maxLength: 2000, unicode: false),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOG_AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.LOG_LogMetadata",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuditLogId = c.Long(nullable: false),
                        Key = c.String(maxLength: 256, unicode: false),
                        Value = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOG_AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GuidID = c.Guid(nullable: false),
                        Ability = c.Int(nullable: false),
                        SuitColor = c.String(maxLength: 256, unicode: false),
                        StartingPower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTrainingDate = c.DateTimeOffset(precision: 7),
                        LastTrainingDate = c.DateTimeOffset(precision: 7),
                        TrainingSessionsToday = c.Byte(),
                        TrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trainers", t => t.TrainerID, cascadeDelete: true)
                .Index(t => t.TrainerID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(maxLength: 256, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        Password = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.LOG_LogMetadata", "AuditLogId", "dbo.LOG_AuditLogs");
            DropForeignKey("dbo.LOG_AuditLogDetails", "AuditLogId", "dbo.LOG_AuditLogs");
            DropIndex("dbo.Heroes", new[] { "TrainerID" });
            DropIndex("dbo.LOG_LogMetadata", new[] { "AuditLogId" });
            DropIndex("dbo.LOG_AuditLogDetails", new[] { "AuditLogId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Heroes");
            DropTable("dbo.LOG_LogMetadata");
            DropTable("dbo.LOG_AuditLogDetails");
            DropTable("dbo.LOG_AuditLogs");
        }
    }
}
