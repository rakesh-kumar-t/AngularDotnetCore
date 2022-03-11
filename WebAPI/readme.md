## Business layered Heirarchy
---

#### DataAccess - Data Layer (Models and Contexts are present here)
  - Migration commands are executed in this layer
#### CompanyService - Service Layer (Business Logic is implemented in here)
  - This layer uses models to access data from db
#### WebApi - Presentation layer (Here the logic is consumed and data is fed to the UI)
  - Controllers are present here
  - We add reference to above two layers in this project 

## Layer Structure

>


    .
    ├── DataAccess
    │   ├── Context
    │   │   └── WorkDBContext.cs                   
    │   ├── Migrations
    │   └── Models
    │       ├── Department.cs
    │       └── Employee.cs
    ├── CompanyService
    │   ├── Interfaces
    │   │   ├── IDepartmentService.cs
    │   │   └── IEmployeeService.cs
    │   └── Services 
    │       ├── DepartmentService.cs
    │       └── EmployeeService.cs
    ├── WebAPI                  
    │   ├── Controllers
    │   │   ├── DepartmentController.cs
    │   │   └── EmployeeController.cs
    │   ├── Photos 
    │   ├── Properties 
    │   │   └── launchSettings.cs
    │   ├── Program.cs
    │   ├── Startup.cs      
    │   └── appsettings.json               
    └── ...

### Observed Issue
  - Build fail because of namespace not found issues
    - Reference the DataAccess.dll and CompanyService.dll for WebAPI Project from RefDll folder inside WebAPI Project   
    - Reference to the DataAccess.dll for CompanyService Project from same folder
  - Database connection error or Object not found error
    - Run Update-database command from nuget package manager console, Selecting the DataAccess Project from Dropdown of the console    
