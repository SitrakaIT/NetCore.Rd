# NetCore.Rd
A mini-Netcore Research &amp; Development based on SOA architecture

https://github.com/SitrakaIT/NetCore.Rd.git

This project takes in all of basic concept of a solid and efficiency project as to better maintain it in the future.

We can see there design pattern principles like :
  - Dependency Injection (Built-in service provided in asp.net core)
  - Singleton (Built-in service provided)
  - Factory Method
  - Builder pattern
  
Also, the project highlights :
  - Asynchronous programming using Task
  - Importance of using IQueryable than IEnumerable in some cases.
  - Best practice for WebAPI return

It relies on services oriented architecture (SOA) including (Core, Business, Repository, Data) and Web Infrastructure (Web).

Clone repository, and after in NetCore.Rd.Web folder change your specific connectionstring database at appsettings.json file.
Open CLI at the same folder and run the following commands :

  - dotnet restore (restore all dependencies)
  - dotnet ef database update. (applies migration already added)
  - Then run your project.

Content :

The project contains two related data (Owner and Apartment) as a one-to-many relation (a Owner can owns many apartments).

  - There's a CRUD operation for Apartment (Create, Read, Update, Delete) and Details
  - A List operation for Owner (based on singleton design pattern)

Link :

  - Apartments :
    - List : ~/api/apartments
    - Details : ~/api/apartments/{id}
    - Add : ~/api/apartments/create
    - Update : ~/api/apartments/edit/{id}
    - Delete : ~/api/apartments/delete/{id}
    - SearchByName : ?/api/apartment/{name} where name is string part of apartment name (Query based on stored procedure SP_QueryFind.sql)
    [Note : Don't forget executing SP_QueryFind.sql file to run SearchByName query link]
    
  - Owner : (List) ~/api/owners

Version : 
  - ASP.NET Core 2.2
  - SDK .NET Core 2.2.103
  - EntityFrameworkCore 2.2.1
