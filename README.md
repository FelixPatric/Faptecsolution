# Faptecsolution

Faptecsolution is a modular C# solution for a Caritas CRM platform, structured around a clean separation of domain rules, application use cases, and future delivery layers.

The repository currently includes the core solution foundation for modeling and orchestrating CRM workflows such as leads, contacts, accounts, opportunities, quotes, invoices, products, and activities.

## What’s in the repository

- **Domain layer** — CRM entities, enums, and shared domain abstractions
- **Application layer** — use-case orchestration, feature modules, contracts, and object mapping
- **Solution file** — `Faptecsolution.slnx`

## Architecture

The solution follows a layered architecture designed to keep business logic isolated from infrastructure and presentation concerns:

- **Domain** holds the core business model.
- **Application** contains feature-driven application logic and integration points.
- **API / UI / Infrastructure** folders are present in the solution structure and appear intended for future expansion.

Dependency registration for the application layer is centralized in:

- `Faptecsolution.CaritasCRM.Application/ApplicationServiceRegistration.cs`

That setup currently registers:

- **AutoMapper** for object mapping
- **MediatR** for request/handler-based application workflows

## Project structure

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

## Domain focus

Based on the current codebase, the CRM domain includes concepts such as:

- **Leads** — lead capture, rating, source, and status tracking
- **Contacts** — people and communication details
- **Accounts** — customer or organization records
- **Opportunities** — sales pipeline and stage tracking
- **Quotes** — pricing and proposal workflows
- **Invoices** — billing and payment lifecycle
- **Products** — catalog and category management
- **Activities** — task and interaction tracking

## Technology stack

- C#
- .NET
- MediatR
- AutoMapper

## Getting started

### Prerequisites

- .NET SDK compatible with the solution

### Build

```bash
dotnet build Faptecsolution.slnx
```

### Restore dependencies

```bash
dotnet restore
```

## Contributing and extension points

When adding new features, keep responsibilities separated by layer:

- **Domain**: entities, value objects, enums, and business rules
- **Application**: commands, queries, handlers, DTOs, contracts, and mappings
- **Infrastructure**: persistence, external integrations, and implementation details
- **API / UI**: user-facing endpoints and presentation logic

## Notes

- No license file is currently included.
- The repository looks like an early-stage solution foundation, ready for feature expansion.
