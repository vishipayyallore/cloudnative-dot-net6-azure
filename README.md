# cloudnative-dot-net6-azure
Deploy .NET 6 Cloud Native Apps to Azure


## CI CD Pipelines
[![BooksDataStore CICD](https://github.com/vishipayyallore/cloudnative-dot-net6-azure/actions/workflows/booksdatastore-cicd.yml/badge.svg)](https://github.com/vishipayyallore/cloudnative-dot-net6-azure/actions/workflows/booksdatastore-cicd.yml)

## Resources in Azure

> 1. rg-cloudnative-dot-net6-azure `resource group`
> 1. sql-datastore-cndn6-azure `Azure SQL Server`
> 1. sqldb-books-cndn6-azure `Azure SQL Database`
> 1. appi-cloudnative-dotnet6-azure `Application Insights`


## What are we going to do today?

In this session, speakers will talk about building cloud-native .NET 6 applications on Azure. You will get to know how to architect, design, develop and deploy Full Stack .NET 6 applications on Azure. 

> 1. Some security practices.
> 1. Deploy `.sqlproj` Azure SQL Server
> 1. `Redis cache` to store data in memory
> 1. `Azure Key Vault` to store secrets of `Azure SQL Server` and `Redis Cache`
> 1. Deploy `.NET 6 Web API` on Azure App Service
> 1. Modify the Web API's Configuration to use secrets from `Azure Key Vault`
> 1. Verify the Web API using Postman
> 1. Integrate `.NET 6 Blazor WASM` based Single Page Application with Web API
> 1. Deploy .NET 6 Blazor WASM based Single Page Application on Azure App Service
> 1. SUMMARY / RECAP / Q&A

![Seat Belt | 100x100](./documentation/images/SeatBelt.PNG)

---

**Note:**
> 1. All the Azure Resources are created in `rg-cloudnative-dot-net6-azure` resource group.
> 1. All the Azure Resources are at its default state.

## 1. Some security practices.

> 1. Discussion on security practices. This is will be as part of all sections.

## 2. Deploy `.sqlproj` Azure SQL Server

> 1. Discussion
> 1. Deploy `.sqlproj` Azure SQL Server using GitHub Actions

## 3. `Redis cache` to store data in memory
> 1. Discussion
> 1. Cache Aside Pattern

## 4. Azure `Key Vault` to store secrets of Azure `SQL Server` and `Redis Cache`

> 1. Discussion
> 1. Show casing the `Purge protection` of Redis Cache
> 1. We will store the Azure `SQL Server` and `Redis Cache` secrets in Azure `Key Vault`.

```
Code sinppet:
```

## 5. Deploy `.NET 6 Web API` on Azure App Service

> 1. Discussion
> 1. Deploy `.NET 6 Web API` on Azure App Service using Visual Studio 2022/GitHub Actions

## 6. Modify the Web API's Configuration to use secrets from Azure `Key Vault`

> 1. Discussion
> 1. Modify the Web API's Configuration to use secrets from `Azure Key Vault`
> 1. Verify the Web API endpoint using Chrome. It `will NOT work`.
> 1. Enable the IP address of the Web API inside the `SQL Server Fire Wall Rule`.
> 1. Verify the Web API endpoint using Chrome. It `will work`.


```
Code sinppet:
```

## 7. Verify the Web API using Postman

> 1. Discussion
> 1. Verify the Web API using Postman

## 8. Integrate `.NET 6 Blazor WASM` based Single Page Application with Web API

> 1. Discussion
> 1. Integrate `.NET 6 Blazor WASM` based Single Page Application with Web API

## 9. Deploy .NET 6 Blazor WASM based Single Page Application on Azure App Service

> 1. Discussion
> 1. Deploy .NET 6 Blazor WASM based Single Page Application on Azure App Service

---

## 10. SUMMARY / RECAP / Q&A

> 1. SUMMARY / RECAP / Q&A
> 2. Any open queries, I will get back through meetup chat/twitter.
