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
            _taskFlowDbContext.MyTasks.Add(task);
        }

        public bool Delete(long id)
        {
            var task = _taskFlowDbContext.MyTasks.Find(id);
            if (task == null)
            {
                return false;
            }

            _taskFlowDbContext.MyTasks.Remove(task);
            return true;
        }

        public MyTask Get(long id)
        {
            return _taskFlowDbContext.MyTasks.Find(id) ?? null!;
        }

        public List<MyTask> GetAll()
        {
            return _taskFlowDbContext.MyTasks.ToList();
        }

        public void Update(MyTask task)
        {
            _taskFlowDbContext.Entry(task).State = EntityState.Modified;
        }
    }
}
