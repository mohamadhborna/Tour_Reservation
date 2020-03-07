# How  to install and connect to sql server

## Step 1 :  Install Microsoft SQL Server 2017 Developer Edition 

   Go to [Step by step instruction to install Microsoft SQL Server 2017 Developer Edition on Windows 10](http://www.catgovind.com/mssqlserver/step-by-step-instruction-to-install-microsoft-sql-server-2017-developer-edition-on-windows-10-part-1/) and  Follow steps
## Step 2 : Install SQL Server Management Studio (SSMS)

   Go to [Download SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) 
   and Follow steps.
##  Step 3 : Create Database (Tour)

1.  Right-click your server instance in Object Explorer, and then select New Query
2.  Into the query window, paste the following T-SQL code snippet:
```SQL
USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'Tour'
)
CREATE DATABASE [Tour]
GO
```
3.To execute the query, select Execute (or select F5 on your keyboard).
##  Step 4 : Change Connection string 
 .Go to Project : Academy Tour/src/Api/appsetting.json  and change username and password to your own username and password 
## Step 5 : Update data base with available migration
 . Go to : Academy Tour/src and run command
```Command
dotnet ef database update --startup-project ./Api/ --project ./Infrastructure/
```
## Step 6 Check DataBase Tables name
1.  Right-click your server instance in Object Explorer, and then select New Query
2.  Into the query window, paste the following T-SQL code snippet:

```SQL
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='Tour'
```
3. To execute the query, select Execute (or select F5 on your keyboard)

4. you should see Tabales we defined in configuration files


