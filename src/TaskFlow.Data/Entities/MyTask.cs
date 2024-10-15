using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskFlow.Data.Enums;

namespace TaskFlow.Data.Entities
{
    [Table("MyTasks")]
    public class MyTask
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public DateTime TimeToEnd { get; set; }
        public TaskFlow.Data.Enums.TaskStatus Status { get; set; }
    }
}
