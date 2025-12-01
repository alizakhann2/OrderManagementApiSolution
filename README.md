# OrderManagementApiSolution

Order Management API – ASP.NET Core + Identity + JWT

This project is a secure Order Management API built using ASP.NET Core Web API, Identity, JWT Authentication, EF Core, and SQL Server. It allows users to register, log in, obtain a JWT token, and perform CRUD operations on orders. Each user can access only their own orders, ensuring data privacy and security.

-> Features

User Registration & Login (ASP.NET Core Identity)

JWT-based Authentication

SQL Server + Entity Framework Core

Secure CRUD on Orders

Automatic calculation of Total Amount

Per-user data isolation (orders belong to logged-in user)

-> Tech Stack

ASP.NET Core Web API

Identity + JWT Authentication

EF Core + SQL Server

Swagger for API testing

API Endpoints Auth Method Endpoint Description POST /api/auth/register Register new user POST /api/auth/login Login and receive JWT token Orders (Authorization Required) Method Endpoint Description GET /api/orders Get all orders of logged-in user GET /api/orders/{id} Get specific order POST /api/orders Create a new order PUT /api/orders/{id} Update an order DELETE /api/orders/{id} Delete an order
