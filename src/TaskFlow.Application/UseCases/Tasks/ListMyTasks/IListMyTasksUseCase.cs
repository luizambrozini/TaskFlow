using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Comunication.Responses;

namespace TaskFlow.Application.UseCases.Tasks.ListMyTasks
{
    public interface IListMyTasksUseCase
    {
        ResponseListMyTasksJson Execute();
    }
}
