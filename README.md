# Test Project: Dual API Containerized App

This project demonstrates a system with two ASP.NET Core APIs communicating via Docker containers.
Each API uses a different database and a different architecture in demonstration purposes:

- `UserAPI`: ASP.NET Core + PostgreSQL (Service architecture)
- `ProjectAPI`: ASP.NET Core + MongoDB (CQRS)

---

### Running the System

From the root folder:

```bash
docker compose up --build
