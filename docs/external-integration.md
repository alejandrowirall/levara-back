# Levara — External Integration API

## Overview

This document describes how to integrate an external application with the Levara property management platform. The integration exposes a single endpoint that allows creating or retrieving the three core entities required to set up a rental contract: **Owner**, **Tenant**, and **Property**.

The operation is **idempotent**: each entity is identified by an `externalId` provided by the calling application. If the entity already exists in Levara, it is returned as-is. If it does not exist, it is created. This means the same request can be safely retried without creating duplicates.

---

## Base URL

| Environment | URL |
|---|---|
| Development | `https://localhost:7183` |
| Production | _(provided separately by Levara team)_ |

---

## Authentication

All requests must include a static API Key in the request header:

```
X-API-KEY: <your-api-key>
```

The API Key is provisioned by the Levara team. There is no token exchange or expiry — include the key directly on every request.

**If the key is missing or invalid, the API returns `403 Forbidden`.**

---

## Endpoint

### `POST /api/external/sync-entities`

Creates or retrieves an Owner, a Tenant, and a Property in a single atomic operation.

---

## Request

### Headers

| Header | Value |
|---|---|
| `Content-Type` | `application/json` |
| `X-API-KEY` | _(your API key)_ |

### Body

```json
{
  "owner": {
    "externalId": "string (required, max 100)",
    "name": "string",
    "surname": "string",
    "companyName": "string",
    "identification": "string",
    "identificationType": 1,
    "personType": 1,
    "mobilePhone": "string",
    "email": "string",
    "street": "string",
    "additionalLine": "string (optional)",
    "city": "string",
    "state": "string",
    "postalCode": "string"
  },
  "tenant": {
    "externalId": "string (required, max 100)",
    "name": "string",
    "surname": "string",
    "companyName": "string",
    "identification": "string",
    "identificationType": 1,
    "personType": 1,
    "mobilePhone": "string",
    "email": "string",
    "street": "string",
    "additionalLine": "string (optional)",
    "city": "string",
    "state": "string",
    "postalCode": "string"
  },
  "property": {
    "externalId": "string (required, max 100)",
    "street": "string",
    "additionalLine": "string (optional)",
    "city": "string",
    "state": "string",
    "postalCode": "string",
    "price": 0.00,
    "roomsQuantity": 0,
    "bathroomQuantity": 0,
    "areaQuantity": 0.0,
    "hasPool": false,
    "hasBalcony": false,
    "hasGarage": false,
    "availableFrom": "2025-01-01T00:00:00Z",
    "ownerBankAccountId": null
  }
}
```

### Field Reference

#### `owner` and `tenant` — same structure

| Field | Type | Required | Notes |
|---|---|---|---|
| `externalId` | string (max 100) | **Always** | Your system's unique identifier for this entity |
| `name` | string | Only if creating new | First name |
| `surname` | string | Only if creating new | Last name |
| `companyName` | string | Only if creating new | Legal company name. Use `"-"` for individuals |
| `identification` | string | Only if creating new | SSN, Passport or EIN number |
| `identificationType` | integer | Only if creating new | See [Identification Types](#identification-types) |
| `personType` | integer | Only if creating new | See [Person Types](#person-types) |
| `mobilePhone` | string | Only if creating new | Include country code, e.g. `+14155552671` |
| `email` | string | Only if creating new | Used to create the login user in Levara |
| `street` | string | Only if creating new | Street address |
| `additionalLine` | string | Optional | Apt, suite, floor, etc. |
| `city` | string | Only if creating new | |
| `state` | string | Only if creating new | |
| `postalCode` | string | Only if creating new | |

> **"Only if creating new"** means: if `externalId` already exists in Levara, all other fields are ignored. If `externalId` is new, these fields are required to create the entity.

#### `property`

| Field | Type | Required | Notes |
|---|---|---|---|
| `externalId` | string (max 100) | **Always** | Your system's unique identifier for this property |
| `street` | string | Only if creating new | |
| `additionalLine` | string | Optional | |
| `city` | string | Only if creating new | |
| `state` | string | Only if creating new | |
| `postalCode` | string | Only if creating new | |
| `price` | decimal | Optional | Monthly rent amount |
| `roomsQuantity` | integer | Optional | |
| `bathroomQuantity` | integer | Optional | |
| `areaQuantity` | decimal | Optional | Area in square meters/feet |
| `hasPool` | boolean | Optional | Default: `false` |
| `hasBalcony` | boolean | Optional | Default: `false` |
| `hasGarage` | boolean | Optional | Default: `false` |
| `availableFrom` | ISO 8601 datetime | Optional | e.g. `"2025-06-01T00:00:00Z"` |
| `ownerBankAccountId` | integer | Optional | Internal Levara bank account ID to link. Send `null` if not applicable |

> The property is automatically linked to the **Owner** resolved in the same request. You do not need to send `ownerId` explicitly.

---

## Enumerations

### Identification Types

| Value | Name | Description |
|---|---|---|
| `1` | SSN | Social Security Number |
| `2` | Passport | Passport |
| `3` | EIN | Employer Identification Number |

### Person Types

| Value | Name |
|---|---|
| `1` | Individual |
| `2` | Company |

---

## Response

### Success — `200 OK`

```json
{
  "result": {
    "ownerId": 5,
    "ownerCreated": true,
    "tenantId": 3,
    "tenantCreated": true,
    "propertyId": 12,
    "propertyCreated": true
  },
  "success": true,
  "error": null
}
```

| Field | Type | Description |
|---|---|---|
| `ownerId` | integer | Levara internal ID for the Owner |
| `ownerCreated` | boolean | `true` = newly created, `false` = already existed |
| `tenantId` | integer | Levara internal ID for the Tenant |
| `tenantCreated` | boolean | `true` = newly created, `false` = already existed |
| `propertyId` | integer | Levara internal ID for the Property |
| `propertyCreated` | boolean | `true` = newly created, `false` = already existed |

> Store the returned `ownerId`, `tenantId`, and `propertyId` in your system. You will need them if you later create a lease via separate API calls.

### Error — `400 Bad Request`

Returned when a new entity is being created but required fields are missing.

```json
{
  "result": null,
  "success": false,
  "error": {
    "statusCode": 400,
    "message": "Required fields missing for new Owner: Owner.Name, Owner.Email"
  }
}
```

### Error — `403 Forbidden`

Returned when the `X-API-KEY` header is missing or contains an invalid key.

```
Invalid API Key.
```

---

## Idempotency

The operation is fully idempotent. The `externalId` of each section controls behavior:

| Scenario | Result |
|---|---|
| `externalId` not found in Levara | Entity is created; `xCreated: true` |
| `externalId` already exists in Levara | Existing entity is returned; `xCreated: false` |
| All three `externalId`s already exist | No writes to DB; all `xCreated: false` |
| Only one `externalId` is new | Only that entity is created |

This means you can safely re-send the same payload on retries, network failures, or re-syncs without causing duplicates.

---

## Complete Example

### Request

```bash
curl --location 'https://localhost:7183/api/external/sync-entities' \
--header 'X-API-KEY: bdba5e2a-8c4e-4675-903a-5414c1b6ccf3' \
--header 'Content-Type: application/json' \
--data-raw '{
  "owner": {
    "externalId": "EXT-OWNER-001",
    "name": "John",
    "surname": "Smith",
    "companyName": "Smith Properties LLC",
    "identification": "123456789",
    "identificationType": 1,
    "personType": 2,
    "mobilePhone": "+14155550001",
    "email": "john.smith@smithproperties.com",
    "street": "742 Evergreen Terrace",
    "additionalLine": null,
    "city": "Springfield",
    "state": "IL",
    "postalCode": "62701"
  },
  "tenant": {
    "externalId": "EXT-TENANT-001",
    "name": "Jane",
    "surname": "Doe",
    "companyName": "-",
    "identification": "987654321",
    "identificationType": 1,
    "personType": 1,
    "mobilePhone": "+14155550002",
    "email": "jane.doe@email.com",
    "street": "100 Main Street",
    "additionalLine": "Apt 4B",
    "city": "Springfield",
    "state": "IL",
    "postalCode": "62701"
  },
  "property": {
    "externalId": "EXT-PROP-001",
    "street": "55 Oak Avenue",
    "additionalLine": null,
    "city": "Springfield",
    "state": "IL",
    "postalCode": "62702",
    "price": 1500.00,
    "roomsQuantity": 3,
    "bathroomQuantity": 2,
    "areaQuantity": 95.0,
    "hasPool": false,
    "hasBalcony": true,
    "hasGarage": true,
    "availableFrom": "2025-07-01T00:00:00Z",
    "ownerBankAccountId": null
  }
}'
```

### Response (first call — all created)

```json
{
  "result": {
    "ownerId": 5,
    "ownerCreated": true,
    "tenantId": 3,
    "tenantCreated": true,
    "propertyId": 12,
    "propertyCreated": true
  },
  "success": true,
  "error": null
}
```

### Response (second call — all existing)

```json
{
  "result": {
    "ownerId": 5,
    "ownerCreated": false,
    "tenantId": 3,
    "tenantCreated": false,
    "propertyId": 12,
    "propertyCreated": false
  },
  "success": true,
  "error": null
}
```

---

## Notes

- **User accounts**: When an Owner or Tenant is created for the first time, Levara automatically creates a login account using the provided `email`. The initial password is set internally and can be reset via the Levara portal.
- **ExternalId uniqueness**: Each `externalId` must be unique within its entity type. An Owner and a Tenant can share the same `externalId` value without conflict.
- **Partial creation**: If Owner and Tenant already exist but Property is new, only the Property will be created. The response will reflect `ownerCreated: false`, `tenantCreated: false`, `propertyCreated: true`.
- **Atomicity**: All three entities are created within a single database transaction. If any creation fails, none of the changes are persisted.
