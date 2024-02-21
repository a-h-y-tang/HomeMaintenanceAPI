using HomeMaintenance.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HomeMaintenance.Repositories
{
    public class EntityContext : DbContext
    {

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            
        }

        public required DbSet<MaintenanceCycleTask> MaintenanceCycleTasks { get; set; }

        public required DbSet<TaskExecutionHistory> TaskExecutionHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceCycleTask>().ToTable("MaintenanceCycleTask");
            modelBuilder.Entity<TaskExecutionHistory>().ToTable("TaskExecutionHistory");

            modelBuilder.Entity<MaintenanceCycleTask>().HasIndex(t => t.Id).IsUnique();
            modelBuilder.Entity<TaskExecutionHistory>().HasIndex(t => t.TaskExecutionKey).IsUnique();

            modelBuilder.Entity<TaskExecutionHistory>().HasOne<MaintenanceCycleTask>().WithMany(t => t.TaskExecutionHistory).HasForeignKey(t => t.TaskKey);

            modelBuilder.Entity<TaskExecutionHistory>().Property(t => t.RowVersion).IsConcurrencyToken();
        }
    }

}