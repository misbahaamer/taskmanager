using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Infrastructure.Persistance
{
    public class TaskContextSeed
    {
        public static async System.Threading.Tasks.Task SeedAsync(TaskContext taskContext, ILogger<TaskContextSeed> logger)
        {
            if (!taskContext.Tasks.Any())
            {
                taskContext.Tasks.AddRange(GetPreconfiguredOrders());
                await taskContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskContext).Name);
            }
        }

        private static IEnumerable<MyTask> GetPreconfiguredOrders()
        {
            List<string> priority = new List<string>() { "High", "Middle", "Low" };
            List<string> status = new List<string>() { "New", "In Progress", "Finished" };
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            return new List<MyTask>
            {
                new MyTask
                {
                    Name = "Name: " + DateTime.Today.Date.ToString(),
                    Description = "Description: " + DateTime.Now.Ticks,
                    DueDate = DateTime.Today,
                    Priority = priority[rnd1.Next(priority.Count)],
                    Status = status[rnd2.Next(status.Count)]
                }
            };
        }
 
    }
}
