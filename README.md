# 🛒 E-Commerce RESTful API

A modular E-Commerce Backend API built with **ASP.NET Core Web API**, following **Onion Architecture** and applying several software design patterns and best practices to achieve clean, maintainable, and scalable code.

The project covers essential e-commerce functionalities, including product management, shopping baskets, authentication, order processing, and payment integration.

## 🏗️ Architecture & Design Patterns

The project follows **Onion Architecture**, separating responsibilities into independent layers to improve maintainability, testability, and separation of concerns.

### Design Patterns & Principles

- **Onion Architecture** – Separation of concerns and dependency inversion.
- **Repository Pattern** – Abstracting data access logic.
- **Unit of Work Pattern** – Managing database transactions and coordinating repositories.
- **Specification Pattern** – Encapsulating reusable query conditions and filtering logic.
- **Result Pattern** – Handling operation results and errors consistently.
- **Dependency Injection** – Managing dependencies between application components.
- **Separation of Concerns** – Keeping business logic independent from infrastructure and presentation layers.

## 🛠️ Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Redis
- Stripe Payment Gateway
- RESTful API
- LINQ

## 📁 Project Structure

```text
E_Commerce/
│
├── E_Commerce.API/
│   └── Controllers, API Configuration
│
├── E_Commerce.Application/
│   └── Application Logic, Services & Specifications
│
├── E_Commerce.Domain/
│   └── Entities, Interfaces & Business Rules
│
├── E_Commerce.Infrastructure/
│   └── Database, Repositories & External Services
│
└── E_Commerce.sln
```

## ✨ Core Features

### 1. Product Management

- Retrieve products with their related Brand and Type.
- Filter products by Brand and Type.
- Search products by name.
- Dynamic sorting by Name or Price (Ascending / Descending).
- Pagination with Page Index, Page Size, and Total Count.
- Standardized API response structure.

### 2. Specification Pattern

- Encapsulating reusable query conditions.
- Applying filtering and searching rules.
- Including related entities.
- Supporting dynamic sorting and pagination.
- Keeping query logic separate from repository implementation.

### 3. Shopping Basket

- CustomerBasket and BasketItem entities.
- Create, retrieve, update, and delete baskets.
- Redis integration for in-memory basket storage.
- Time-To-Live (TTL) expiration.
- Key-value storage for temporary shopping basket data.

### 4. Caching

- In-memory and distributed caching concepts.
- Redis integration.
- Cache expiration and TTL management.
- Action Filters for handling caching logic.
- Understanding the execution flow of OnActionExecuting and OnActionExecuted.

### 5. Authentication & Authorization

- ASP.NET Core Identity integration.
- User registration and login.
- JWT-based authentication.
- Token generation and validation.
- Current authenticated user information.
- Email existence validation.

### 6. Order Management

- Order-related entities and business logic.
- Creating orders from customer baskets.
- Retrieving customer orders.
- Managing order details and statuses.

### 7. Payment Integration

- Stripe Payment Gateway integration.
- PaymentIntent creation and updates.
- Payment processing based on basket information.
- Webhook integration for receiving payment events.
- Automatic order status updates based on payment results.

## 🚀 Future Improvements

The project is still under development. The following items represent features and improvements that are planned or require further completion:

- Complete and verify all payment scenarios and Stripe webhook handling.
- Improve distributed caching and cache invalidation strategies.
- Complete remaining authentication and user-management functionality.
- Improve order lifecycle and payment status handling.
- Add comprehensive unit and integration tests.
- Improve API documentation and error handling.
- Add further validation and security improvements.

## 📌 Project Goals

The main goal of this project is to strengthen practical backend development skills by building a real-world E-Commerce API while applying clean architecture principles, reusable design patterns, database optimization techniques, authentication, caching, and third-party payment integration.

---

**Project Status:** Work in Progress 🚧
