using TaskFlow.Comunication.Enums;

namespace TaskFlow.Comunication.Requests
{
    public class RequestCreateTaskJson
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public DateTime TimeToEnd { get; set; }
        public TaskFlow.Comunication.Enums.TaskStatus Status { get; set; }
    }
}
