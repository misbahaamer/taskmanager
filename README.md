# taskmanager

1. update the connection string to your server and database with user id and password if applicable. my db doesnot have password.
change connection string in taskmanager/taskmanager/Services/Task.API/appsettings.json

"ConnectionStrings": {
    "TaskConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDb;Integrated Security=True"
  },

2. run the sql script in taskmanager/taskmanager/ CreateDbTable.sql to create tables(program.cs is set to creating db and table automatically and also seeding 1 record in the table. tun this script if the context seeder doesnot run in your environment )
3. visual studio start/debug profile must be changed from IISExpress to Task.API. i have changed it in taskmanager/taskmanager/Services/Task.API/Properties/launchSettings.json and updated the port to 3867 

"Task.API": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "dotnetRunMessages": "true",
      "applicationUrl": "https://localhost:3867;http://localhost:3866"
    }

please change if required.

4. run the app and start testing at https://localhost:3867/swagger/index.html

5. Task requirement 1:

taskmanager/taskmanager/Services/Task.Application/Features/Tasks/Commands/AddTask/AddTaskValidator.cs /

RuleFor(x => x.DueDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.Today).WithMessage("{DueDate} is required");

6. Task requirement 2:

taskmanager/taskmanager/Services/Task.Infrastructure/Repositories/TaskRepository.cs 

public async Task<Dictionary<string, int>> GetTasksCountForPriorityAndStatusOnADate()



