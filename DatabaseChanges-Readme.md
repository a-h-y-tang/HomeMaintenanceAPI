# Instructions for use

Within Package Manager Console in Visual studio

Select in 'Default project' the value 'HomeMaintenance' in the drop down menu

Steps to changing the database schema:
1. Modify the model classes
1. Add-Migration V(Number)Description eg. V2AddFeatureColumn
1. Script-Migration -Context EntityContext -Idempotent -Output \Scripts\DatabaseSchema.sql
1. Run update-database
1. Check that the database is as per your expectations in your local SQL Server database
1. Check in the code