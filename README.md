# Home Maintenance API

The purpose of this API is to provide a backend for the retrieval and creation of home maintenance tasks and their history.

This service is intended to be a simple service.

This API is implemented in C# .NET 8 and uses a SQL Server database and is intended to run in Azure.

Please read the DatabaseChanges-Readme.md for how to make changes to this service's database schema.

Features to go:
Create a history item that a task is completed at a certain time by a certain person.
Use Azure Keyvault to store Database connection string.
Security to check the bearer token