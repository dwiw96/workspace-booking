# Workspace Booking

## Overview
A workspace booking application for organizations. The MVP focuses on room bookings.

## Tech Stack
- .NET SDK 10.x
- ASP.NET Core Web API
- EF Core
- PostgreSQL
- xUnit
- Docker

## Prerequisites
- Git
- Docker
- Docker Compose

## Getting Started

### Local Database Setup

#### 1. Clone the Repository
1. Clone the project:
```bash
git clone https://github.com/dwiw96/workspace-booking.git
```
2. Go to the project directory:
```bash
cd workspace-booking
```

#### 2. Set Up Environment Variables
1. Copy `.env.example` to `.env`:
```bash
cp .env.example .env
```
2. Replace the placeholder values with your local values:
    - `POSTGRES_DB`: database name
    - `POSTGRES_USER`: database username
    - `POSTGRES_PASSWORD`: database password
3. Save `.env`.
4. Do not commit `.env`. It is ignored by `.gitignore`.

#### 3. Run PostgreSQL
1. Start PostgreSQL:
```bash
docker compose up -d
```
2. Check database readiness:
```bash
docker compose ps
```
3. The db service should show a `healthy` status.

#### 4. Stop the Service
1. Stop the service:
```bash
docker compose down
```
2. Database data is stored in a named volume and persists after `docker compose down`. Running `docker compose down -v` also removes the volume and deletes the local database data.
