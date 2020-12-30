
using MatrixTest.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.Contracts;

using TrackerEnabledDbContext;
using TrackerEnabledDbContext.Common.Models;

namespace MatrixTest.DAL.Implementation
{
    public class MainContext : TrackerContext
    {
        // Your context has been configured to use a 'PersonContext' connection string from your application's 
        // configuration file (Web.config). By default, this connection string targets the 
        // 'MatrixTest.DAL.PersonContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PersonContext' 
        // connection string in the application configuration file.
        public MainContext() : base("name=MainContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Contract.Requires(modelBuilder != null);

            // setting default length of all strings instead of VarChar(max) - each property can be overwritten later
            modelBuilder.Properties<string>().Configure(s => s.IsUnicode(false).HasMaxLength(256));

            #region Logs
            modelBuilder.Entity<AuditLog>().ToTable("LOG_AuditLogs");

            EntityTypeConfiguration<AuditLogDetail> auditLogBuilder = modelBuilder.Entity<AuditLogDetail>().ToTable("LOG_AuditLogDetails");
            auditLogBuilder.Property(l => l.OriginalValue).HasMaxLength(2000);
            auditLogBuilder.Property(l => l.NewValue).HasMaxLength(2000);

            modelBuilder.Entity<LogMetadata>().ToTable("LOG_LogMetadata");
            #endregion

            modelBuilder.Entity<Hero>()
            .HasRequired(h => h.Trainer)
            .WithMany(t => t.Heroes)
            .HasForeignKey(h => h.TrainerID);

            // set email as unique
            modelBuilder
            .Entity<Trainer>()
            .HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}