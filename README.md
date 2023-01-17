# phone-operator
<img src="https://media1.giphy.com/media/vx9YFNa9ePYWLNnh0X/giphy.gif" width="100%" />

A Server-Side (Back-End) for a Phone Operator which catalogs Phone Operators Name, Brand, Flag and Code.\
Created with C# (.NET 5), MySQL and Docker focused in using Domain-Driven Design (DDD), Unit Test, Clean Code and Clean Architecture.

# Dependencies
* .NET 5 SDK
* EntityFramework Core
* Docker
* xUnit
* Moq

# Environments
Instead of using the default `appsettings.json` for setting up connectionString (DSN - Data Source Name) and server-side host (localhost).\
This project has implemented the usage of a `.env` file for settings. Which you can copy from `.env.example` and then fulfill it with the actual data.

# Running (Locally)
To quickly run and create our Docker container run:
```bash
docker-compose up -d
```

### (Visual Studio Code)
After passed the required data into your `.env`. It must run our project migrations. Do it by run the following command into your CLI:
```bash
dotnet dotnet-ef database update
```

Then run to check if the project is building right:
```bash
dotnet build
```

And finally:
```bash
dotnet run
```
#
