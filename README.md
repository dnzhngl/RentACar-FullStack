# Rent A Car - FullStack Project

It is a full stack car rental web site project.

## Back-End

On the back-end side, asp.net entity framework core 5.0 version is used.
The project has 3 basic layers, that are data access, business logic and API, and a core layer for shared needs.

The project was created based on the use of interfaces as reference holders in order to make changes easily in case of need, considering the possibility of change in the technologies used.


## Core Layer
The core layer, created for to be used in every project.

### Data Access
It has [base repository interface](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/DataAccess/IEntityRepository.cs) that can be implemented by base repository that uses an ORM technology. In this project, entity framework core is used to create the [base repository](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/DataAccess/EntityFramework/EfEntityRepositoryBase.cs).

### Entities
All of the entities must have to implement the IEntity interface so that the entity can be used with generic repository operations. Also, Dto's (data access objects) must have to implement the IDto interface.
Users, OperationClaims, and UserOperationClaims entities have been created on this layer. Operation claims, stand for authorizations (roles) based on operations. User operations laims are held in UserOperationClaims.


### Aspects

#### Validation
[ValidationTool](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/CrossCuttingConcerns/Validation/FluentValidation/ValidationTool.cs) created by using FluentValidation and the tool used in [ValidationAspect](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Aspects/Autofac/Validation/ValidationAspect.cs) to check whether the entity sent by client is valid.
For the entity that needs validaiton checks, a validator must be created by using FluentValidation. e.g. [CarValidator](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/ValidationRules/FluentValidation/CarValidator.cs). And then, validation aspect can be used on top of the desired methods' like [[ValidationAspect(typeof(CarValidator)]](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarManager.cs).

#### Caching
For caching, microsoft's in-memory cache used. [MemoryCacheManager](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/CrossCuttingConcerns/Caching/Microsoft/MemoryCacheManager.cs) implements, ICacheManager. [ICacheManager](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/CrossCuttingConcerns/Caching/ICacheManager.cs) enables us to use other caching technologies by just implementing from it. Cache manager used in Cache Aspect and Cache Remove Aspect. 

[Cache ascpect](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Aspects/Autofac/Caching/CacheAspect.cs), caches the returned data from tha database as a result of an operation. [CacheAspect] must be placed on top of the desired operation to cache data. [Look for example usage](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarManager.cs) It caches data with a specified key that indludes, related service name and operation type(Get, Post etc.). E.g. ICarService.Get 

[Cache remove aspect](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Aspects/Autofac/Caching/CacheRemoveAspect.cs), removes from the cache when an operation runs. Cache remove aspect mostly used with operations that manipulates data, such as add, remove and update. Explained usage: [CacheRemoveAspect("ICarService.Get")] can be placed on top off the operations that are adds, deletes or updates the data. It removes the data that has the key as ICarService.Get from the cache, when the operation runs.

#### Performance Management
To monitor the performance of the related operation, the [Performance aspect](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Aspects/Autofac/Performance/PerformanceAspect.cs) can be used. If the operations runtime exceeds the given interval it writes to the specified place. Performance asspect must be placed on top of the related operartion with the time interval of type integer. E.g. [[PerformanceAspect(5)]](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarManager.cs)

#### Transaction Scope
Instead of creating transaction scope in the operation, the [Transaction scope aspect](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Aspects/Autofac/Transaction/TransactionScopeAspect.cs) can be placed on top of the operation. In this way, the operation placed into the transaction scope. If an error occurs while the operation runs, all of the transactions undone. E.g. [[TransactionScopeAspect]](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarImageManager.cs)


### Dependency Resolvers
#### [CoreModule](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/DependencyResolvers/CoreModule.cs)
It involves IoC injections that are related with the Core layer and loads general dependencies for the project.


### Utilities

#### [Business Rules](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Business/BusinessRules.cs)
An operations business logics can be transformed into a method and then sent Business Rules as a parameter. If any of the business logic method returns error, business rules returns that error too. E.g. [CarImageManager - Add](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarImageManager.cs)

#### Results
Result structure helps us to create a standardized return type for the operations.
For the operations that are void, [IResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/IResult.cs) can be used. For the successful results, [SuccessResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/SuccessResult.cs), for the failed results [ErrorResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/ErrorResult.cs) can be used. Also, for operations that are not void, the [IDataResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/IDataResult.cs) type can be used. [SuccessDataResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/SuccessDataResult.cs) and [ErrorDataResult](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Results/ErrorDataResult.cs) are the return types for operations. For the example usages, look into the [manager classes](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Concrete/CarManager.cs).

#### Security
[Hashing Helper](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Security/Hashing/HashingHelper.cs)
For the security purposes, clients password first salted and then hashed with the security algorithm of HmacSha512.

[Jwt Helper](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Core/Utilities/Security/Jwt/JwtHelper.cs)
Json web token helper, creates token that includes issuer, audiencee, expires, claims with client name identifier, e-mail, name, and roles, and signing credentials.


## Business Layer
Services and Manager placed on this layer. 

### Business Aspect
[Secured operation](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/BusinessAspect/SecuredOperation.cs) handles operation-based authorizations. Compares user's role claims with the role permissions assigned to the related operation.

### [Messages](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Constants/Messages.cs)
As a result of an operation, a message can be returned. To manage all of the messages in one place, static messages class created.

### Dependency Resolvers
#### [Autofac Business Module](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/DependencyResolvers/Autofac/AutofacBusinessModule.cs) is an IoC container created by using Autofac.

### Helpers
#### [Automapper Helper](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.Business/Helpers/AutoMapperHelper.cs)
Automapper to map between entities and dtos.


## Entities Layer
That includes entities and Dtos.
There is an inheritance between User, Customer, and Individual customers and Corporate Customer entities. Individual Customer and Corporate Customer entities inherit from Customer entity and Customer entity inherit from User entity.


## Data Access Layer
That includes fluent api configurations, context and entities' repositories.


## WebApi
.NET 5.0 web api has been used to create rest api. All of the operations checks through postman. 
Token options placed into the [appsettings.json](#https://github.com/dnzhngl/RentACar-FullStack/blob/851a2ee17f/CarRental.WebApi/appsettings.json) file.


## Front-End
On the front-end Angular framework -version 11.2.3- used. 
There is an admin panel to control entities. Admin can execute CRUD operations over cars, colors, brands, rentals, and customers.
People can register the website, and the users can search through cars and rent a car that is available.
There is also a fake payment component and credit card save function.
