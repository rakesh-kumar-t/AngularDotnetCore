# Angular - .NET Core APP

> Angular v13

> .Net 6.0

### Angular app with dotnet core web api and mssql as backend
##### _points to note_
* SQL Commands for creating the tables are provided in dbcommands folder
* Make sure the database and tables are created before running the application
* Use postman and use the APIs to add some dummy data to table
* Run the WebAPI first(recommeneded to run from visual studio)
* Then run the angular app

* Command for creating models from db
  * ``` scaffold-dbcontext "Data Source=.;Initial Catalog=CompanyDB; Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models ```

