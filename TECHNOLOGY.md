![BloodCore GitHub Header](https://raw.githubusercontent.com/wow-bloodcore/image-assets/master/github-header.png)

# Technology

This document outlines the technology leveraged by **BloodCore**.

## ORM

The ORM that is implemented by the software is the [Dapper](https://github.com/StackExchange/dapper-dot-net) micro ORM. This is used in conjunction with a customer **ADO.NET** wrapper that manages the connection.

The custom **ADO.NET** wrapper resides in the `BloodCore.Persistence` namespace.

## Dependency injection

The dependency injection library that is implemented by the software is **Microsoft**'s **Unity** library.

## Web framework

The web framework that is implemented by the software is **Microsoft**'s **ASP.NET MVC 5**. Once **ASP.NET Core** is deemed stable, we will begin the migration process over to the new framework.

## Web framework modularity

In order to provide modularity for the software we utilize **MvcCodeRouting** as it allows us to namespace controllers in a much more logical way. It also allows us to split the application into multiple libraries.