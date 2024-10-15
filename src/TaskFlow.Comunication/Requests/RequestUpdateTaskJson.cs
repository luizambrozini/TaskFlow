using TaskFlow.Comunication.Enums;

namespace TaskFlow.Comunication.Requests
{
    public class RequestUpdateTaskJson
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public MyTaskPriority? TaskPriority { get; set; }
        public DateTime? TimeToEnd { get; set; }
        public MyTaskStatus? Status { get; set; }
    }
}
