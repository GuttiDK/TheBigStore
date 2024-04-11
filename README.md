# TheBigStore

## Description

TheBigStore is a web application that allows users to view, create, edit, and delete products. The application is built using the ASP.NET Core framework and Entity Framework Core. The application uses a SQL Server database to store product data.

## The Maker
Made by Christian C. Høttges

Last updated: 11-04-2024

# How to Use

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Run the application.

**Requirements:**

* <a href="https://code.visualstudio.com/" target="_blank">Visual Studio IDE</a> (recommend Code) to compile.
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">Microsoft SQL</a> (recommend Express) to run the database for testing.

**Technologies:** 
* <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">C#</a> (back-end)
* <a href="https://www.javascript.com/" target="_blank">JavaScript</a> 
* <a href="https://html.com/" target="_blank">Html</a> (front-end)
* <a href="https://www.w3schools.com/css/" target="_blank">CSS</a>
* <a href="" target="_blank">Bootstrap</a> (front-end styling)
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">SQL</a> (data storage)


# Features
- **Front-end**: Allows users to view, create, edit, and delete products and use all the frontend features of the application thru it.
- **Back-end**: Allows users can use all the features of the application thru the repository and services.
- **Repository pattern**: Allows users to use the repository pattern to get data from the database.
- **Service pattern**: Allows users to use the service pattern to get data from the repository.

# Updates
**Version 2.0.0** (11/04/2024 - Current version)
1. **Namespace Refactoring**:
   - Organized namespaces for better code organization, enhancing readability and maintainability.
2. **Dependency Injection and Logging**:
   - Added the `Microsoft.Extensions.Options` namespace and a static `Create` method to `TheBigStoreContext.cs`, enabling configuration options and simplified context creation.
   - Integrated `Autofac` for dependency injection and `AutoMapper` for object-object mapping, improving modularity and abstraction.
3. **Asynchronous Operations**:
   - Modified the `GetById` method in various interfaces and classes to be asynchronous, enhancing performance and responsiveness.
4. **Database Structure**:
   - Implemented significant changes to the database structure, including the addition of new models for entities and seed data, enhancing data integrity and consistency.
4. **Unit Testing**:
   - Added comprehensive unit testing, including creation of new unit test files and removal of redundant test classes, ensuring robustness and reliability.
5. **DTO Integration**:
   - Introduced DTO classes for multiple entities, facilitating data transfer and abstraction between layers.
6. **Service Layer Enhancements**:
   - Added new service classes and interfaces, improving encapsulation and separation of concerns.
7. **Role Management**:
   - Introduced role management features, enabling role-based access control and enhancing security.
   - Updated user session management to store user ID and role, improving authentication and authorization mechanisms.
8. **User Account Management**:
    - Enhanced user account creation process, setting default roles and implementing error handling for user creation.
9. **Removal of Redundant Code**:
    - Removed unnecessary files, methods, and dependencies, streamlining the codebase and reducing complexity.
10. **Database Migration**:
    - Implemented a new database migration to establish the initial database schema, ensuring database consistency and compatibility.


**Version 1.0.0** (02/04/2024)
- Updated `TheBigStoreContext` class and various model classes.
- Removed the `DbContextOptions<TheBigStoreContext>` parameter from the constructor.
- Added new `DbSet` properties for entities to `TheBigStoreContext`.
- Updated the `OnModelCreating` method to define relationships and seed data.
- Updated model classes with new properties and navigation properties.
- Updated `Program` and `UnitTheBigStoreContext` classes.
- Removed the connection string for the SQL Server database from `UnitTheBigStoreContext`.

**Version 0.0.5** (02/04/2024)
- Added new model classes for various entities.
- Updated `TheBigStoreContext` with `DbSet` properties for the new models.
- Overrode the `OnModelCreating` method in `TheBigStoreContext`.
- Created a new instance of `TheBigStoreContext` in `Program.cs`.
- Added a new enum for order statuses.
- Removed the folder include for "Models" from `TheBigStore.Repository.csproj`.

**Version 0.0.4** (01/04/2024)
- Added `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Logging` namespaces.
- Modified the connection string and included `EnableSensitiveDataLogging` method in `TheBigStoreContext`.
- Created a new `ILoggerFactory` instance in the `OnConfiguring` method.

**Version 0.0.3** (01/04/2024)
- Added a new unit testing project named `TheBigStore.UnitTesting`.
- Included configurations for unit testing in the solution file.
- Added package references for `coverlet.collector`, `Microsoft.NET.Test.Sdk`, `xunit`, and `xunit.runner.visualstudio`.
- Added project references to `TheBigStore.Repository` and `TheBigStore.Service`.
- Introduced five new unit test files.
- Added a utility class for unit testing.
- Implemented a new method in the `TheBigStoreContext` class.

**Version 0.0.2** (30/03/2024)
- Added the structure of the application.
- Added the repository and service pattern.
- Added the database connection.

**Version 0.0.1** (30/03/2024)
- Initial pre-release of The Big Store Application.
- Features include Backend templete.

## In progress
 - Stucture of the application.

## Tags
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-2.0.0">Comprehensive Update and Refinement - v2.0.0</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-1.0.0">Testing and Database Structure - v1.0.0</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-0.0.2">Repo and service pattern - v0.0.2</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-0.0.1">Structure - v0.0.1</a>

# Bugs & Known Bugs and Bug Reporting
We are constantly working to improve this application. If you encounter any bugs or errors, please report them to us.

## Contact Info
**Phone number:** +45 28 78 34 14  
**Email:** [GuttiDK@gmail.com](mailto:GuttiDK@gmail.com)

## License
This project is licensed under the MIT license. See the `LICENSE` file for further details.