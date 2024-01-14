# C# Movie Watchlist API

## Overview

This project is a .NET 6.0 application designed to provide a CRUD service for managing a movie watchlist.
It is built with a focus on Hexagonal Architecture principles to ensure maintainability and scalability.

## Features

- **User Authentication**: Secure user registration and authentication using JWT tokens.
- **CRUD Operations**: Create, read, update, and delete operations for managing movies.
- **Database Migrations**: Easy database schema evolution with `Entity Framework Core` migrations.
- **Swagger Documentation**: Auto-generated API documentation and testing interface with Swagger.
- **Input Validation**: Robust input validation using `FluentValidation`.
- **Logging**: Application logging with `Serilog`.
- **Dependency Injection**: Built-in support for dependency injection to promote loose coupling.
- **Custom Middleware**: Custom middleware for exception handling, JWT authorization, and request timing.

## Architecture

The project adheres to Hexagonal Architecture, organizing the code into the following layers:

- **Controllers**: API endpoints for handling HTTP requests.
- **Managers**: Interfaces defining contracts for operations related to movies and user management.
This layer serves as a bridge between the `Controllers` and `Services`,
ensuring a separation of concerns and facilitating easier testing and maintenance.
- **Services**: Business logic implementation.
- **Repositories**: Data access layer for interacting with the database.
- **Models**: Entity representations.
- **DTOs**: Data transfer objects for encapsulating request and response data.
- **Validators**: Validation rules for incoming data.
- **Middlewares**: HTTP request processing.
- **Helpers**: Utility classes.
- **Exceptions**: Custom exception types for error handling.

Each layer has its own responsibility and is designed to be loosely coupled with the others,
promoting a maintainable and scalable codebase.

## Getting Started

### Prerequisites

- .NET 6.0 SDK
- A supported SQL-Server database
- You can use `Docker Compose` to run the SQL-Server database:

```docker
   docker-compose up -d
```

### Setup

1. Clone the repository:
    ```shell
      git clone https://github.com/mehdiqor/csharp-movie.git
    ```

2. Navigate to the project directory:
    ```shell
      cd csharp-movie
    ```

3. Restore the .NET packages:
    ```shell
      dotnet restore
    ```

4. Update the database connection string in `appsettings.json` to point to your SQL database.

5. Apply the database migrations:
    ```shell
      dotnet ef database update
    ```

### Running the Application

Run the application using the following command:

```shell
  dotnet run
```

The API will be hosted by default at `http://localhost:7048`.

### Using the API

Access the Swagger UI to test the API endpoints at `http://localhost:7048/swagger`.

## Repository Structure

- This structure provides a high-level overview of the project's organization,
making it easier for new contributors to understand where different types of files are located.

Below is a tree structure of the main directories and files in this repository:

|<br>
│ Program.cs<br>
│ StartupTasks.cs<br>
│<br>
└───Contexts<br>
│ DatabaseConnectionVerifier.cs<br>
│ MovieDbContext.cs<br>
│<br>
└───Controllers<br>
│ ApiController.cs<br>
│ ErrorsController.cs<br>
│ MovieController.cs<br>
│ UserController.cs<br>
│<br>
└───Dtos<br>
│ CreateMovieRequest.cs<br>
│ CreateMovieResponse.cs<br>
│ ...Other Dtos<br>
│<br>
└───Exceptions<br>
│ BadRequestException.cs<br>
│ NotFoundException.cs<br>
│ ValidationException.cs<br>
│ ForbiddenException.cs<br>
│ CustomResponse.cs<br>
│<br>
└───Helpers<br>
│ Cryptography.cs<br>
│ IRequestCounter.cs<br>
│ RequestCounter.cs<br>
│ SwaggerConfig.cs<br>
│<br>
└───Managers<br>
│ IMovieManager.cs<br>
│ MovieManager.cs<br>
│ IUserManager.cs<br>
│ UserManager.cs<br>
│<br>
└───Middlewares<br>
│ ExceptionHandlerMiddleware.cs<br>
│ IJwtValidator.cs<br>
│ JwtAuthorizationMiddleware.cs<br>
│ JwtAuthorizeAttribute.cs<br>
│ TimingMiddleware.cs<br>
│<br>
└───Models<br>
│ MovieModel.cs<br>
│ UserModel.cs<br>
│<br>
└───Repositories<br>
│ IMovieRepository.cs<br>
│ IUserRepository.cs<br>
│ MovieRepository.cs<br>
│ UserRepository.cs<br>
│<br>
└───Services<br>
│ IMovieService.cs<br>
│ MovieService.cs<br>
│ IUserService.cs<br>
│ UserService.cs<br>
│<br>
└───Validators<br>
│ CreateMovieValidator.cs<br>
│ ...Other Validators<br>
│<br>
