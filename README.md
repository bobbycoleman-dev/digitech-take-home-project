# Digitech Take Home Project

## Overview
- Create project using C#, ASP.NET (in place of Winforms), and SQL Server (Azure)
- Create "Patients" table with specified fields
- Develop controller methods for creating a new patient (CreatePatient) and updating patient information (UpdatePatient)
- Display all patients data in a grid (table)
- Create a "Patient Detail Form" for multi-use (component)

## Features
- Patient data tables shows all patients in the database
- Table includes an "Add New Patient" button to navigate to the "Patient Detail Form" for use #1, creating a new patient
- Double-clicking on a patients data row navigates to the "Patient Detail Form" for use #2, viewing patient data
- Clicking the "Edit" button on a single patient row navigates to "Patient Detail Form" for use #3, editing patient data
- On "Add New Patient" and "Edit Patient" views, buttons include "Save" and "Exit"
- On "View Patient", buttons include "Edit" to edit the current patient
- Form has active validation based on schema and Patient model


## Run Locally
### Prerequisites
- Micrsoft Azure account
- Azure SQL Server
- SQL Database created within that server
- One of the database connection strings
    - Entra passwordless
    - SQL authorization
    - Entra password
    - or Entra integrated

### Next Steps
- Pull the repository
- Run `dotnet restore`
- Replace AZURE_SQL_CONNECTIONSTRING in `appsettings.Development.json`
- Run `dotnet ef migrations add InitialMigration`
- Run `dotnet ef database update`
- Run `dotnet watch run` to run project and begin adding data into the databse
