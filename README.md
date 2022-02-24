# Angular - .NET Core APP

> Angular v13

> .Net 5.0

### Angular app with dotnet core web api and mssql as backend (Code first approach)

##### _points to note_

- Migration Commands (in Nuget console)
  - `add migration <name>`
  - `update database`
- Use postman and use the APIs to add some dummy data to table
- Run the WebAPI first(recommeneded to run from visual studio)
- Then run the angular app

  - `npm i`
  - `ng serve`

- If converting to db first approach
  - SQL Commands for creating the tables are provided in dbcommands folder

### Known Errors

- If any error pops up regarding namespaces, add the reference to the DataAccess project or dll from the webapi project

#### Extras

- If you are planning on a db first approach
  - Command for creating models from db
    - `scaffold-dbcontext "Data Source=.;Initial Catalog=CompanyDB; Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models`
