# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Levara is a .NET 8 property management system built with Clean Architecture principles. The application manages properties, tenants, owners, leases, expenses, maintenance, and financial transactions with integration to Plaid for banking services.

## Architecture

The solution follows Clean Architecture with these layers:

- **Levara.Domain**: Core business entities, enums, interfaces, and domain events
- **Levara.Application**: Application services using CQRS pattern (Commands/Queries/Handlers)
- **Levara.DAL**: Data Access Layer with Entity Framework Core and PostgreSQL
- **Levara.Shared**: Shared components including CQRS infrastructure and domain events
- **Levara.ExternalService**: External service integrations (Email, Plaid)
- **Levara.WebApi**: Web API controllers and hosting configuration for AWS Lambda

## Key Development Commands

### Building and Running
```bash
# Build the entire solution
dotnet build Levara.sln

# Run the web API locally
dotnet run --project Levara.WebApi

# Run in development mode with hot reload
dotnet watch run --project Levara.WebApi
```

### Database Operations
```bash
# Add new migration
dotnet ef migrations add MigrationName --project Levara.DAL --startup-project Levara.WebApi

# Update database
dotnet ef database update --project Levara.DAL --startup-project Levara.WebApi

# Drop database (development only)
dotnet ef database drop --project Levara.DAL --startup-project Levara.WebApi
```

## Core Patterns

### CQRS Implementation
- **Commands**: Use for create, update, delete operations
- **Queries**: Use for read operations
- **Handlers**: Each command/query has a corresponding handler
- **Responses**: Each command/query returns a typed response

Example structure:
```
Feature/
├── Create/
│   ├── CreateFeatureCommand.cs
│   ├── CreateFeatureCommandHandler.cs
│   └── CreateFeatureCommandResponse.cs
├── GetByGrid/
│   ├── GetFeatureByGridQuery.cs
│   ├── GetFeatureByGridQueryHandler.cs
│   └── GetFeatureByGridQueryResponse.cs
```

### Domain Events
- Domain events are automatically processed after database commits
- Events are stored in `DomainEvent` table before processing
- Use `ExecuteOn[EventName]` pattern for event handlers

### Repository Pattern
- Each entity has a dedicated repository interface in `Levara.Domain`
- Repository implementations in `Levara.DAL` extend `Repository<T>`
- Access via `IUnitOfWork` for transaction management

## Database Configuration

The application uses PostgreSQL with Entity Framework Core:
- Connection string configured in `appsettings.json`
- Entity configurations in `Levara.DAL/DbContext/EntityConfigurations/`
- Seed data in `Levara.DAL/DbContext/Seeds/`

## Authentication & Authorization

- JWT Bearer token authentication
- API Key authentication for external services
- Role-based authorization with custom attributes
- User context injection for multi-tenant scenarios

## AWS Lambda Integration

The WebApi is configured for AWS Lambda deployment:
- Uses `Amazon.Lambda.AspNetCoreServer.Hosting`
- Configuration in `aws-lambda-tools-defaults.json`
- Conditional event bus: In-memory for debug, AWS EventBridge for production

## External Integrations

### Plaid Integration
- Bank account linking and transaction synchronization
- Reconciliation system for matching transactions
- Background jobs for data synchronization

### Email Service
- FluentEmail with SMTP configuration
- HTML templates for user notifications
- Confirmation emails for user registration

## Testing

No specific test projects are present. When adding tests:
- Create separate test projects for each layer
- Use Entity Framework In-Memory provider for repository tests
- Mock external services (Plaid, Email) for unit tests

## Common Development Tasks

When adding new features:
1. Define entity in `Levara.Domain/Models/`
2. Create repository interface in `Levara.Domain/DAL/Repositories/`
3. Implement repository in `Levara.DAL/Repositories/`
4. Add entity configuration in `Levara.DAL/DbContext/EntityConfigurations/`
5. Create CQRS handlers in `Levara.Application/[FeatureName]/`
6. Add controller in `Levara.WebApi/Controllers/`
7. Add migration for database schema changes

## Environment Configuration

- `appsettings.json`: Base configuration
- `appsettings.Development.json`: Development overrides
- Environment variables for sensitive data (connection strings, API keys)
- AWS configuration for Lambda deployment

## Clean Architecture Principles

### Strict Layer Separation

**Application Layer (Handlers):**
- NEVER use `using Microsoft.EntityFrameworkCore`
- Create simple queries: `var query = _repo.GetAll().Where(...)` and pass to repository
- Use specialized repository methods instead of direct queries
- Avoid Entity Framework logic in handlers

**Infrastructure Layer (Repositories):**
- Use full power of Entity Framework freely
- Create specialized methods for frequent queries (GetLast*, GetTotal*, etc.)
- Centralize complex query logic
- Methods should be self-descriptive and focused

### Model Evolution Patterns

When refactoring core models:
1. Update factory methods (CreateLeaseCharge, etc.) - remove obsolete parameters
2. Create specialized repository methods to replace complex logic
3. Update handlers to use new methods instead of manual queries
4. Update seeds to reflect new structure
5. Follow principle: entity-specific fields only for relevant types

### Handler Cleanup Principles

When refactoring handlers:
- Replace complex manual queries → repository methods
- Eliminate post-creation entity assignments
- Simplify database transactions by removing intermediate SaveChangesAsync()
- Use specialized repository methods for balances and aggregations
- Keep business logic separate from data access concerns

### Balance and State Architecture

Multiple balance types:
- General Property balance (always present)
- Entity-specific balances (LeaseRunningBalance, etc.)
- Only corresponding entity type manages its specific balance (others use 0)
- Create GetLast*RunningBalance methods in repositories for each balance type
- Specialized repository methods for aggregations (sums, counts, etc.)