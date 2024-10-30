# GridScanner

## Installation guide
*Prerequisits:*
* This project uses Telerik UI, download trial version of telerik form: https://www.telerik.com/blazor-ui
* This project uses .NET Aspire
* This project uses an SQL Server

After downloading "TelerikUIForBlazorSetup" from "https://www.telerik.com/blazor-ui" run the installer and select Telerik UI for Blazor and Telerik UI for ASP.NET Core *Visual studio needs to be closed for this step* -> NEXT -> "Accept the license agreement" -> NEXT -> Log into telerik... again -> INSTALL -> AGREE :)
*NOTE Telerik will call about the trial period in a day or two since they are super invested in making sales and providing support :D

### When Proxy Authentication Required pops up -> Its Telerik... yes it wants your email and passowrd again!

For .NET Aspire search from NuGet: Aspire.Hosting.AppHost Make sure to be on __All__ or __nuget.org__

If you do not have an SQL server locally running, you can grab the "developer edition" from: "https://www.microsoft.com/en-us/sql-server/sql-server-downloads" (no sign up required).
"Basic" installation will suffice.

# Update Database
Easyest way to spin up a database is to run the "Update-Database" via Package Manager Console. *Make sure to first select GridScanner.ApiService* as the launch project and GridScanner.Data as the default project*
![image](https://github.com/user-attachments/assets/61b2813c-6785-412d-98bd-b47463084d40)


Once Aspire and Telerik is installed and DB is updated, launch the application by running GridScanner.AppHost on https
![image](https://github.com/user-attachments/assets/90a17b10-e535-4dca-83e0-a0806b16ef05)

Once the application is running you can see 2 Projects running along side each other. "apiservice" and "webforntend". Endpoints are clickable.

# API
### Simple one endpoint API that takes in a DateTime request and returns 25 hourly electricity prices (€/MWh) for gived date starting from 00:01 of given date UTC.

# UI
A simple dashboard with the functionality of searching for *past and same day* electricity prices.
UI Should look like this or very similar: ![image](https://github.com/user-attachments/assets/b9d24196-94fe-4bf6-93b3-6e3534ba4bbe)
