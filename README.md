
This is a Command getter CURD app built using GraphQL and DotNet 5

#### Architecture

![alt](assets\GraphQL.PNG)

#### Environmental Setup

Spin up the Docker SQL Server or Use the Local instance
```bash
docker-compose up -d
```
run the docker command at root level, Connection string for docker instance
```bash 
"Server=localhost,1433;Database=GraphQL;User Id=sa;Password=pa55w0rd!"
```
#### Set Up Database
```bash
dotnet ef database update [if using VS Code]
update-database [if using Visual Studio]
```
#### Build and Run
```bash
dotnet build
dotnet run
F5 if using VS
```
####  URL's
```bash
http://localhost:5000/graphql/
http://localhost:5000/graphql-voyager 
```
#### Sample Queries to try
#####  query
```bash
query{
 platform  {
  id
  name
 }
}
```
##### mutation
```bash
mutation{
 addPlatform(input:  {
  name:  "RedHat"
 })
{
 platform  {
   id
   name
  }
 }
}
```
##### subscription
```bash
subscription{
 onPlatformAdded{
  id
  name
 }
}
```
####  Future Scope
1) Implement Data Loader Pattern 
2) Use Relay Pattern



