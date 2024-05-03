# TheBigStore

## Description

TheBigStore is a web application that allows users to view, create, edit, and delete products. The application is built using the ASP.NET Core framework and Entity Framework Core. The application uses a SQL Server database to store product data.

## The Maker
Made by Christian C. Høttges

Last updated: 17-04-2024

# How to Use

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Update the connection string in the `appsettings.json` file to point to your SQL Server instance.
4. Open the Package Manager Console and run the following commands:
   - `Add-Migration InitialCreate`
   - `Update-Database`
5. Run the application.

**Requirements:**

* <a href="https://code.visualstudio.com/" target="_blank">Visual Studio IDE</a> (recommend Code) to compile.
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">Microsoft SQL</a> (recommend Express) to run the database for testing.

**Technologies:** 
* <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">C#</a> (back-end)
* <a href="https://www.javascript.com/" target="_blank">JavaScript</a> 
* <a href="https://html.com/" target="_blank">Html</a> (front-end)
* <a href="https://www.w3schools.com/css/" target="_blank">CSS</a>
* <a href="https://getbootstrap.com/" target="_blank">Bootstrap</a> (front-end styling)
* <a href="https://blazor.radzen.com/" target="_blank">Radzen Blazor</a> (styling)
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">SQL</a> (data storage)
* <a href="https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0" target="_blank">ASP.NET Core</a> (framework)
* <a href="https://docs.microsoft.com/en-us/ef/core/" target="_blank">Entity Framework Core</a> (data access)
* <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio" target="_blank">Identity</a> (user management)
* <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-6.0&tabs=visual-studio" target="_blank">Roles</a> (role-based access control)
* <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0" target="_blank">Logging</a> (error handling)
* <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0" target="_blank">Session</a> (user session management)
* <a href="https://automapper.org/" target="_blank">AutoMapper</a> (object-object mapping)


# Features
- **Front-end**: Allows users to view, create, edit, and delete products and use all the frontend features of the application thru it.
- **Back-end**: Allows users can use all the features of the application thru the repository and services.
- **Repository pattern**: Allows users to use the repository pattern to get data from the database.
- **Service pattern**: Allows users to use the service pattern to get data from the repository.
- **Database**: Uses a SQL Server database to store product data.
- **Unit Testing**: Includes comprehensive unit testing for various components of the application.
- **Dependency Injection**: Utilizes dependency injection for improved modularity and abstraction.
- **Logging**: Implements logging for better error handling and debugging.
- **Security**: Includes role management features for role-based access control.
- **User Account Management**: Enhanced user account creation process with default roles and error handling.
- **Database Migration**: Implements a new database migration to establish the initial database schema.
- **DTO Integration**: Introduces DTO classes for multiple entities, facilitating data transfer and abstraction between layers.
- **Asynchronous Operations**: Modifies the `GetById` method in various interfaces and classes to be asynchronous, enhancing performance and responsiveness.

# Updates

**Version 2.2.2** (03/05/2024 - Current version)
**Major Changes and Refactoring**
- **Blazor Application**: A new Blazor project, `TheBigStore.Blazor`, was added to the solution. This project includes pages for Home, Counter, and Weather, along with a navigation menu and main layout. This marks a significant addition to the solution, introducing Blazor as a new framework.
- **Solution File Modification**: The solution file `TheBigStore.sln` was updated to include the new Blazor project, indicating a broader scope for the solution. The project type for `TheBigStore.WebAPI` was also changed.
- **Launch Settings and Icons**: Updated the `launchSettings.json` file with new configurations for launching the Blazor application. Additionally, updated `favicon.png`, and added new icon files (`icon-192.png`, `icon-512.png`) and a web manifest file (`manifest.webmanifest`), providing additional resources for the application.
- **Blazor Project Configuration**: The `Program.cs` file was updated to initialize the Blazor WebAssembly host and set up various services, including `HttpClient`. This change indicates a shift towards Blazor and enhances dependency injection support.
- **New Components and Services**: Added new components such as `MainLayout.razor`, `NavMenu.razor`, and `App.razor`, structuring the Blazor application. The `service-worker.js` file was added to provide offline support through service workers.
- **Additional Refactoring and Cleanup**: Removed obsolete files, updated existing components to align with the new Blazor structure, and deleted unused methods and properties to streamline the codebase.

**Code Refactoring and Database Updates**
- **Data Type Refactoring**: Updated data types from `ObservableCollection` to `List` in various `.cshtml.cs` files to improve performance and reduce overhead.
- **Asynchronous Operations**: Replaced synchronous `GetById` methods with asynchronous `GetByIdAsync`, improving application responsiveness.
- **Database Update Operations**: Updated how entities are updated in the database by directly passing the updated entity to the `UpdateAsync` method.
- **Package Additions**: Added `Newtonsoft.Json` and `Microsoft.AspNetCore.Mvc.NewtonsoftJson` to `TheBigStore.Application.csproj` for improved JSON serialization and deserialization.
- **Repository Updates**: Updated `IGenericRepository` to include methods for adding and updating lists of entities. Updated several repository files to support CRUD operations and reflect changes in the database schema.
- **DTO and Entity Property Updates**: Added new properties and navigation properties to `Customer`, `Image`, `ItemOrder`, and `User` classes to enhance relationships between entities.
- **Service Layer Enhancements**: Updated `IGenericService.cs` and `GenericService.cs` with new methods for creating and updating lists of entities.
- **Controller Updates**: Updated various controller files to use more RESTful conventions and refactored `Checkout.cshtml.cs` to improve item quantity handling in the cart.
- **Database Schema Changes**: Implemented a new migration `FixedVersion` to update the database schema and maintain consistency with the refactored entity models.


**Version 2.1.1** (17/04/2024 - Current version)
 **Code Files and Database Structure Updates**
- The code files related to the checkout process, item search, and customer and item services have been updated to reflect these changes. The checkout form now includes fields for first name, last name, phone number, street name, street number, city, country, and zip code. The `AddToCart` method has been moved from the item services to the customer services. A `Quantity` property has been added to the `Item` and `ItemDto` classes.
- The database schema has been updated to include a `Quantity` field in the `Products` table. A new migration has been added to implement this change.

 **Overall Changes**
- **Redesigned Checkout Form and Shopping Cart Display**: The checkout form and shopping cart display have been significantly redesigned for improved user experience.
- **Updated Code Files**: Several code files have been updated to reflect the changes in the checkout process, item search, and customer and item services.
- **Database Structure Updates**: The database schema has been updated to include a `Quantity` field in the `Products` table.

 **File Changes**
- **Checkout.cshtml.cs**: Added new properties for handling checkout form inputs and a new method for handling form submission. Updated the `OnGet` method to retrieve cart items from the session. Added new methods for increasing and decreasing item quantity and removing items from the cart.
- **Products.cshtml**: Removed old layout and added a new one with enhanced user authorization check, item display, and pagination form. Added an alert message for no items found.
- **Login.cshtml.cs**: Corrected the form's `asp-page-handler` attribute value from "login" to "Login". Added logic to clear the cart on login with a different user ID.
- **Logout.cshtml.cs**: Updated to store the user's last ID in the session before removing the current ID.
- **_Layout.cshtml**: Added a search form and updated the cart link's href attribute.
- **SessionHelper.cs**: Added new extension methods for setting and getting complex objects in the session using JSON serialization.


**Version 2.0.0** (11/04/2024)
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
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-2.1.1">Checkout Form and Shopping Cart - v2.1.1</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-2.0.0">Comprehensive Update and Refinement - v2.0.0</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-1.0.0">Testing and Database Structure - v1.0.0</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-0.0.2">Repo and service pattern - v0.0.2</a>
- <a href="https://github.com/GuttiDK/TheBigStore/releases/tag/version-0.0.1">Structure - v0.0.1</a>

# Bugs & Known Bugs and Bug Reporting
We are constantly working to improve this application. If you encounter any bugs or errors, please report them to us.

## ER-Diagram

![ERDiagram](https://github.com/GuttiDK/TheBigStore/assets/93974633/9914de78-07e0-4b93-884d-e260d47c354e)

## Contact Info
**Phone number:** +45 28 78 34 14  
**Email:** [GuttiDK@gmail.com](mailto:GuttiDK@gmail.com)

## License
This project is licensed under the MIT license. See the `LICENSE` file for further details.