
# 8a.nu REST API

8a.nu new super site REST API

Sample Call:
https://path.to.api/api/v1.0/values/get

Swagger API:
https://path.to.api/api/swagger

## Swagger API
swagger is configured to generate on Development and Test environments. more information on the implementation:

https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml

https://swagger.io/

https://github.com/RSuter/NSwag

## Templates

You can use the templates in the /templates folder to generate code 
> more info on dotnet new
> docs: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore2x
> wiki: https://github.com/dotnet/templating/wiki
> samples: https://github.com/dotnet/dotnet-template-samples
> tips: https://www.jerriepelser.com/blog/tips-for-developing-dotnet-new-templates/

### repositoryModel 

This template creates all the necessary files for creating api controller, business, data, migrations and seeding for a given data type

to use this first install template to dotnet new:

	cd /8a.nu-rest-api
    dotnet new -i templates/repositoryModel/

you can see how to run this template with:

	dotnet new 8anurepmodel -h

to create a new model for example for Cars, run:

	dotnet new 8anurepmodel -s Car -p Cars

where:
-s = singular camelcase name of the class
-p = plural camelcase name of the class	

after running the template. please see the instructions commented in the constructor for the class:
>/8anu.Api/Controllers/CarsController.cs

When you run the api, all migrations that are not yet executed will be run. after you have run your migration and realize it was shitty and something went wrong, you can first undo the migration in the DB (rollback):
	
	dotnet ef database update LASTGOODMIGRATION

and then by removing the generated migration

	dotnet ef migrations remove