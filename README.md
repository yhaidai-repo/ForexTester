# Test Project: Dual API Containerized App

This project demonstrates a system with two ASP.NET Core APIs communicating via Docker containers. Each API uses a different database:

- `UserAPI`: ASP.NET Core + PostgreSQL
- `ProjectAPI`: ASP.NET Core + MongoDB

---

### Running the System

From the root folder:

```bash
docker compose up --build
