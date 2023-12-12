# TodoApp

**Technologies**: React JS, .Net 6.0, MS SQL 

**IDE**: Visual Studio Code, Visual Studio 2022, MS SQL Server, SSMS

**Changes required before run the application:**

**1.	Database**
   
    •	Execute below scripts to create the database and table. 

    CREATE DATABASE taskdb
    GO

    use taskdb
    GO

    create table todo(
    id int primary key identity(1,1),
    name nvarchar(50) NOT NULL,
    duedate date,
    completed bit NOT NULL default 0,
    createdon date default getdate()
    )

**2.	Web API**
   
    Update the connection string inside TaskAPI\TaskAPI\appsettings.json with your server’s name, user and password.
    "TaskDBConnection": "Server=xxxxx;Database=TaskDB;User=xxxxx;Password=xxxxx;Integrated Security=True;TrustServerCertificate=True"

**3.	React App**

    •	You need to install Node.js 
    **Navigate to the project folder and run:**
    •	npm install 
    •	Update the Web API URL in todov1\src\App.js with the port of web api
    apiUrl = "https://localhost:xxxx/api/Todos"
    •	Npm start

**Screenshots**

<img width="455" alt="image" src="https://github.com/GBBhat/TodoApp/assets/141651856/e870b765-914a-4361-bbaf-83809f584534">




