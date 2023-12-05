# Assessmnet_SKU

#Run app locally
Run ```dotnet run --property:Configuration=Debug```
Open a browser and navigate to the following URL https://localhost:7079/swagger/index.html

#Design Pattern
Repository and Service Pattern
1. Separates the DataAccess and Business logic. To make the code more maintainable
2. Simplifies Unit testing through dependency injection
3, Minimal knock on effects of changes to individual Services/Repositories
Con: Does require boilder plate code to be able to follow the design pattern.

#Framework
.Net 6: Robust and simple to use while allowing comfortable scaling as the size of the code base increases

#Packages
1. Automapper: Simplifies the Mapping of 1 model to another
2. EntityFramework: Allows Code first migrations to create an Update the database and keep track of the changes.
3. SQLite: Simple SQL-like database that can be run locallyand is more lightweight that SQL server.

#Packages for Unit Testing
1. Mock: Allows mimicnig of dependencies and provides full control of the behavious
2. AutoFixture: Generates Payloads with populated data that can be used for Unit testing purposes