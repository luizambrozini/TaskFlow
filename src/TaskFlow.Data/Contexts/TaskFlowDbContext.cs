using Microsoft.EntityFrameworkCore;
using TaskFlow.Data.Entities;

namespace TaskFlow.Data.Contexts
{
    internal class TaskFlowDbContext : DbContext
    {
        public TaskFlowDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MyTask> MyTasks { get; set; }

    }
}
