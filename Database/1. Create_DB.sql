/****** Object:  Database [PayrollSystemDB]    Script Date: 17-03-2020 20:52:38 ******/
-- Code to Sql Server Create Database
IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'PayrollSystemDB'
    )
BEGIN
    SELECT 'Database Name already Exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE [PayrollSystemDB]
    SELECT 'New Database is Created'
END
