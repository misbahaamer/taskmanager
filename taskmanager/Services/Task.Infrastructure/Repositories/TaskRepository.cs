using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Infrastructure.Persistance;

namespace Task.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<MyTask>, ITaskRepository
    {
        public TaskRepository(TaskContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<MyTask>> GetTasksByDueDate(DateTime date)
        {
            var taskList = await _dbContext.Tasks
                                .Where(o => o.DueDate == date)
                                .ToListAsync();
            return taskList;
        }

        public async Task<IEnumerable<MyTask>> GetTasksByName(string name)
        {
            var taskList = await _dbContext.Tasks
                                .Where(o => o.Name == name)
                                .ToListAsync();
            return taskList;
        }

        public async Task<IEnumerable<MyTask>> GetTasksByPriorityType(string priority)
        {
            var taskList = await _dbContext.Tasks
                                .Where(o => o.Priority == priority)
                                .ToListAsync();
            return taskList;
        }

        public async Task<IEnumerable<MyTask>> GetTasksByStatus(string status)
        {
            var taskList = await _dbContext.Tasks
                                .Where(o => o.Status == status)
                                .ToListAsync();
            return taskList;
        }

        //get the no of tasks grouped by due date having priority high and status not finished
        public async Task<Dictionary<string, int>> GetTasksCountForPriorityAndStatusOnADate()
        {
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            var data = await GetAsync(x => x.Priority.ToLower() == "High".ToLower() && x.Status.ToLower() != "Finished".ToLower());
            if (data == null || data.Count == 0)
            {
                return null;
            }
            var groupedData = from items in data
                              group items by items.DueDate into dueDateGroup
                              select new
                              {
                                  Date = dueDateGroup.Key,
                                  Count = dueDateGroup.Count()
                              };
            var maxData = groupedData.OrderByDescending(x => x.Count).FirstOrDefault();
            keyValues.Add(maxData.Date.ToString(), maxData.Count);

            return keyValues;

        }
    }
}
