This article is written for www.devcurry.com

Join us on FaceBook at www.facebook.com/DevCurry

Before you Start
----------------
Using Nuget Package Restore.
- Some dependencies may be broken because we do not check in the packages folder
- Please open the Package Explorer and click on the Restore Packages button to retrieve all the missing packages

This Article uses EntityFramework DB First.
- Please create a DB Called Company
- Execute the MOdels\CompanyEDMX.edmx.sql script
- Update the Connection string "Company" so that the Data Source points to your SQL Server. Currently it points to .\SQLEXPRESS