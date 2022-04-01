# taskmanager

1. update the connection string to your server and database with user id and password if applicable. my db doesnot have password.
change connection string in taskmanager/taskmanager/Services/Task.API/appsettings.json

"ConnectionStrings": {
    "TaskConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDb;Integrated Security=True"
  },

2. run the sql script in taskmanager/taskmanager/ CreateDbTable.sql to create tables
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

