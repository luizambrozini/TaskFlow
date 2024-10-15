using TaskFlow.Comunication.Enums;

namespace TaskFlow.Comunication.Requests
{
    public class RequestCreateTaskJson
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public MyTaskPriority TaskPriority { get; set; }
        public DateTime TimeToEnd { get; set; }
        public MyTaskStatus Status { get; set; }
    }
}
