# Edit Sql Server
Edit (username password & database name) defautl cannenction string @ ./appsettings.Json
uncomment and comment configurations @ ./Startup.cs

if SqlServer:
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Database=autosaas; User Id=***User***; Password=**password**;"
  },

if MySql:
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Database=autosaas; Uid=***User***; Pwd=**password**;"
  },