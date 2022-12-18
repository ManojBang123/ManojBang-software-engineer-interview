# Zip Installment Calcualtor Service

## Patterns/Technologies/Packages:
This Solution is built using Repository Pattern and Unit of Work Pattern . Below are technolgies, pattterns,packages involved in this project 

 -  .NET Core
 -  Repository Pattern
 -  Unit of Work
 -  Entity Framework Core 
 -  FluentValidation
 -  AutoMapper
 -  Swagger& Swashbuckle Annotations
 -  NewtonSoft Json
 -  Microsoft.AspNetCore.MVC.Testing
 -  Microsoft.Net.Test.Sdk
 -  Xunit/Moq

## Project Modules 

- #### 1. Zip.InstallmentsRestApi: 
  This holds the controller to expose the endpoints for the api to perform http actions .
- #### 2. Zip.InstallmentsService.Contracts: 
  This project contains request and responses data transfer objects.
- #### 3. Zip.InstallmentsService: 
  This project has core business logic which is responsible for creating payment plan.
- #### 2. Zip.InstallmentsService.Domain: 
- This project has shared interafces and database entities being used across the application 
- #### 4. Zip.InstallmentsService.Persistence: 
  This is built up  for connecting with databases and performing CURD operation on the same.
- #### 5. Zip.InstallmentsService.Api: 
  This is project contains logic for payment plan api.
- #### 6. Zip.InstallmentsService.IntegrationTests
  This is basically to perform Controller web api test by creating web client and verify the Json result with status code.
-  #### 7. Zip.InstallmentsService.UnitTest
    This is unit testing suit to validate the service functionality with valid input and invalid input. also result object should not be Null.

### Steps to run the solution 
- Download or clone code from this repo.
- Open VS 2022.
- Browse solution file from cloned folder.
- Set Zip.InstallmentsRestApi as startup project.
- hit Ctrl+F5 to run the application.
- open the swagger URL in the browser 
- Perform the Post opeartion by providing the request body.  
