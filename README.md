# Angular - .NET Core APP

> Angular v13

> .Net 5.0
> 
![.NET Build](https://github.com/rakesh-kumar-t/AngularDotnetCore/actions/workflows/dotnet.yml/badge.svg)
![Angular Build](https://github.com/rakesh-kumar-t/AngularDotnetCore/actions/workflows/angular.yml/badge.svg)


### Angular app with dotnet core web api and mssql as backend (Code first approach)
##### Some major Components Used
> Angular Material

> Swagger UI

> ngx-toastr

##### _points to note_

- Migration Commands (in Nuget console)
  - `add migration <name>`
  - `update-database`
- Use inbuilt Swagger or else postman and use the APIs to add some dummy data to table
- Run the WebAPI first(recommeneded to run from visual studio)
- Then run the angular app

  - `npm i`
  - `ng serve`

- If converting to db first approach
  - SQL Commands for creating the tables are provided in dbcommands folder

### Known Errors

- If any error pops up regarding namespaces, add the reference to the DataAccess project or dll from the webapi project
- If angular app is giving any compilation error, run npm i again

#### Extras

- If you are planning on a db first approach to modify the project
  - Command for creating models from db
    - `scaffold-dbcontext "Data Source=.;Initial Catalog=CompanyDB; Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models`

# Creator
* [Rakesh Kumar T](https://github.com/rakesh-kumar-t)
