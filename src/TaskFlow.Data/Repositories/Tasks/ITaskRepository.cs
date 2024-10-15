using TaskFlow.Data.Entities;

namespace TaskFlow.Data.Repositories.Tasks
{
    public interface ITaskRepository
    {
        void Add(MyTask task);
        List<MyTask> GetAll();
        MyTask Get(int id);
        void Update(MyTask task);
        bool Delete(int id);
    }
}
