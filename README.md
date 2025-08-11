# ApplicationRoleManagementSystem1

A centralized role management system built in ASP.NET Core MVC with Entity Framework Core.

## Features

- Application self-registration via public UI.
- Unique Application ID and Key generation for each registered app.
- Applications grouped into customizable categories.
- Role assignments for applications (e.g., AddEmployee, AddRole, PermitUser).
- Admin approval workflow for application registrations.
- Secure API endpoints to query roles assigned to applications.
- Uses SQL Server for data storage via Entity Framework Core.

## Technologies

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (local or remote)
- C#

## Setup

1. Update connection string in `appsettings.json`.
2. Run EF Core migrations to create database.
3. Run the project.
4. Access `/Application/Register` to register new applications.
5. Admin can approve/reject applications via admin dashboard (work in progress).

