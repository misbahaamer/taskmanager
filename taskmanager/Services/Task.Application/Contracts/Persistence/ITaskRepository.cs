using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface ITaskRepository : IAsyncRepository<MyTask>
    {
        Task<IEnumerable<MyTask>> GetTasksByName(string userName);
        Task<IEnumerable<MyTask>> GetTasksByPriorityType(string priority);
        Task<IEnumerable<MyTask>> GetTasksByStatus(string status);
        Task<IEnumerable<MyTask>> GetTasksByDueDate(DateTime date);
        Task<int> GetTasksCountForPriorityAndStatusOnADate();
    }
}
