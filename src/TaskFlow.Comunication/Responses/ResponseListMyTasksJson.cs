using TaskFlow.Data.Entities;

namespace TaskFlow.Comunication.Responses
{
    public class ResponseListMyTasksJson
    {
        public List<MyTask> MyTasks { get; set; } = [];
    }
}
