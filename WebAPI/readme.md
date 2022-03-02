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
