# Vertical Slice Architecture Template

A .NET 10 Web API template built with Vertical Slice Architecture, FastEndpoints, and Entity Framework Core.

## Live Deployment

- Swagger UI: https://particular-irene-verticalslicearctemplate-eae7263f.koyeb.app/swagger/index.html#
- API base URL: https://particular-irene-verticalslicearctemplate-eae7263f.koyeb.app/

## Overview

This project demonstrates a Vertical Slice Architecture where each feature (slice) contains its own endpoints, models, validators, and mappers. It uses FastEndpoints for high?performance HTTP endpoints and Swagger for API documentation.

## Tech Stack

- .NET 10
- C# 14.0
- FastEndpoints
- FastEndpoints.Swagger
- Entity Framework Core
- Docker

## Project Structure

```
src/
  Vsa.Api/           # API host (entry point, DI, middleware)
    Extensions/
    Program.cs
  Vsa.Application/   # Application layer (features, business logic)
    Features/
      Users/
        Endpoints/
        Models/
        Validators/
        Mappers/
      Settings/
        Endpoints/
        Models/
        Validators/
        Mappers/
    Common/
  Vsa.Domain/        # Domain entities and interfaces
  Vsa.Infra/         # Infrastructure (DB, extensions, etc.)
    Database/
    Extensions/
Dockerfile
README.md
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- (Optional) Docker

### Run Locally

```
dotnet restore
dotnet run --project src/Vsa.Api/Vsa.Api.csproj
```

Then open Swagger at `https://localhost:<port>/swagger`.

## Docker

```
docker build -t vsa-template .
docker run -p 8080:8080 vsa-template
```

Then open `http://localhost:8080/swagger`.

## Notes

- FastEndpoints are registered via `RegisterFastEndpoints()` in `src/Vsa.Api/Extensions/ServiceCollectionExtensions.cs`.
- Auto discovery is disabled and the `Vsa.Application` assembly is registered explicitly.
