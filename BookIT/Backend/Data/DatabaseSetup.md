In order to set up the database connection you need to have Microsoft SQL Server

Configure the database to accept SQL authetication:
* Go to Server properties
* Go to Security
* Select **SQL Server and Windows Authentication mode**

Create a Database named: **BookIT**

Go to appsettings.json and change the datasource to match the source of your sql server in the 
connection string.

install dotnet ef migrations:
**dotnet tool install --global dotnet-ef**

run the migrations: **dotnet ef database update**

(if this results in an error try to delete the migrations folder and add a new migration with the 
following command: **dotnet ef migrations add initial**. Then update the migrations)

Then the app should be linked to the db.

For further references you can visit this link to configure the database on your local computer:
https://docs.driveworkspro.com/topic/HowToConfigureWindowsFirewallForSQLServer


migrations commands:
* **dotnet tool install --global dotnet-ef**                   : install migration tool
* **dotnet ef database update 0**                              : sets the dat of migration to 0
* **dotnet ef migrations add [name]**                          : add a new migration
* **dotnet ef migrations remove**                              : remove previous migration
