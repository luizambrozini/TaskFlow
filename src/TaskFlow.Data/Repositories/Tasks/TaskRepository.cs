using TaskFlow.Data.Contexts;
using TaskFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Data.Repositories.Tasks
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly TaskFlowDbContext _taskFlowDbContext;

        public TaskRepository(TaskFlowDbContext taskFlowDbContext)
        {
            _taskFlowDbContext = taskFlowDbContext;
        }

        public void Add(MyTask task)
        {
            _taskFlowDbContext.Tasks.Add(task);
        }

        public bool Delete(int id)
        {
            var task = _taskFlowDbContext.Tasks.Find(id);
            if (task == null)
            {
                return false;
            }

            _taskFlowDbContext.Tasks.Remove(task);
            return true;
        }

        public MyTask Get(int id)
        {
            return _taskFlowDbContext.Tasks.Find(id) ?? null!;
        }

        public List<MyTask> GetAll()
        {
            return _taskFlowDbContext.Tasks.ToList();
        }

        public void Update(MyTask task)
        {
            _taskFlowDbContext.Entry(task).State = EntityState.Modified;
        }
    }
}
