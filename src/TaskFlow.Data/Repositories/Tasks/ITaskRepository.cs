using TaskFlow.Data.Entities;

namespace TaskFlow.Data.Repositories.Tasks
{
    public interface ITaskRepository
    {
        void Add(MyTask task);
        List<MyTask> GetAll();
        MyTask Get(long id);
        void Update(MyTask task);
        bool Delete(long id);
    }
}
