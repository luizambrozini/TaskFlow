using TaskFlow.Data.Contexts;

namespace TaskFlow.Data.Repositories
{
    internal class UnitOfwork : IUnitOfwork
    {
        private readonly TaskFlowDbContext _taskFlowDbContext;
        public UnitOfwork(TaskFlowDbContext taskFlowDbContext)
        {
            _taskFlowDbContext = taskFlowDbContext;
        }

        public void Commit() => _taskFlowDbContext.SaveChanges();
    }
}
