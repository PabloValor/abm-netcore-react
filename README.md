## ABM hecho con .NET core, mysql y react 16.0.0 


**Requerimientos:**

    * Mysql 14.14

    * Netcore 2.1.302

    * React script 1.0.17



1) instalar DB:

    * `create database QualytABM`

    * Actualizar el connectionstring con las credenciales correctas

    * restore script `Dump20180726.sql`

2) Correr app

    * `dotnet restore`

    * `cd /web && dotnet run`

    * ir a localhost:5001

**Test**

`cd /test && dotnet test`