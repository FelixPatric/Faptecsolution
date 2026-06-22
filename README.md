# Faptecsolution

Faptecsolution is a C# solution for a Caritas CRM domain, organized with a clean separation between the core application and domain layers.

## Overview

This repository currently contains:

- **Application layer** — service registration, feature modules, contracts, and mapping profiles
- **Domain layer** — CRM entities, enums, and shared domain types
- **Solution file** — `Faptecsolution.slnx`

The project structure suggests a modular CRM backend focused on core business objects such as:

- Leads
- Contacts
- Accounts
- Opportunities
- Quotes
- Invoices
- Products
- Activities

## Solution Structure

```text
Faptecsolution/
├── Faptecsolution.CaritasCRM.Application/
│   ├── ApplicationServiceRegistration.cs
│   ├── Contracts/
│   ├── Features/
│   └── MappingProfiles/
├── Faptecsolution.CaritasCRM.Domain/
│   ├── Common/
│   ├── Entities/
│   └── Enums/
└── Faptecsolution.slnx
```

## Architecture

The solution follows a layered application architecture:

- **Domain** contains the business entities and domain enums.
- **Application** contains use-case logic, feature modules, persistence contracts, and object mapping.
- Dependency injection is configured through `AddApplicationServices(...)`.

## Technologies

- C#
- .NET
- MediatR
- AutoMapper

## Getting Started

### Prerequisites

- .NET SDK compatible with the solution

### Build

```bash
dotnet build Faptecsolution.slnx
```

### Run

This repository currently appears to contain the core solution layers only. If an API or UI project is added later, run that project from the solution after restoring dependencies:

```bash
dotnet restore
```

## Extending the Project

When adding new CRM features, place them in the appropriate layer:

- **Domain** for new entities, enums, and business rules
- **Application** for feature handlers, contracts, and mapping profiles
- **API/UI** projects for presentation and delivery concerns

## License

No license file is currently present.

## Status

This project is in an early scaffolding stage and is ready for further implementation of CRM features and infrastructure.
