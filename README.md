# Vidly
> ASP.NET Framework MVC Web Application 

## Table of contents
* [General info](#general-info)
* [Structure](#structure)
* [Features](#features)

## General info
This was written to recap knowledge about programming with course 'The Complete ASP.NET MVC 5 Course' by Mosh Hamedani from www.udemy.com

I done it all, it was good pack of knowledge but on old platform .NET Framework 4.7.

## Structure

`App_Data` - database files.

`App_Start` - classes that are run when the app is starting.

* 'BundleConfig.cs' - combine many files(e.g. .css, .js) into one so compiler would run it faster
* 'FilterConfig.cs' - class where you can add filters, those filters are just code that  can be run before or after piece of code where you declare it.
* 'IdentityConfig.cs' - creates userStore, set ups validators for passwords, users, have mail and sms service.
* 'MappingProfile.cs' - Creates maps for AutoMapper, it wont Map from one type to another if it wont be declared here.
* `RouteConfig.cs` - specify route to write in address for resources.
* 'Startup.Auth.cs' - partial class that will be combine with 'Startup.cs' to one class during startup. Have configs for 2 factors auth, facebook auth, cookie auth, it tells application how it should authenticate users.
* 'WebApiConfig.cs' - it configs 'Newtonsoft.Json' serializerSettings and have configured special route for API calls.

'Controllers' - Controller classes are responsible for data flow between user and data source (not directly) in most cases it connects to context class which is connected to lower layer.

'Dtos' - It have classes that are almost copy of model classes but without fields that you do not want to pass to the client

'Migrations' - Database for application can be created in two ways - code-first or database-first in this scenario (code-first) we register our domain classess in 'ApplicationDbContext.cs', create 'DbSet' - collection of Model items and EntityFramework do rest of the job for us, It follows registered model classes and if there are changes that were not in DB it creates call to database, those call are stored in migrations.

'ViewModels' - you can pass only one class(Model) to view i there is need to take some fields from one and some from other you can create ViewModel class that will have those fields.

'Views' - as the name suggest those are our  '*.cshtml' files. 

'Models' - Models are just classes that represent entities in DB.
'Scripts' - folder with '*.js' scripts used in project
'fonts' - just folder with fonts used in project
'bin' - there are all libraries that you are using in '*.dll' format
'content' - all '*.css' are stored here

