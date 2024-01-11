# Movie Watchlist
* This project is a .NET 6.0 application that implements a CRUD (Create, Read, Update, Delete) service for managing a movie watchlist. The application uses Entity Framework Core for data access, Identity library for user authentication, FluentValidation for input validation, and Serilog for logging. It also includes Swagger for API documentation and JWT for token-based authentication.

## Features
* CRUD Operations: The application provides full CRUD operations for movies. Users can add new movies, view details of existing movies, update movie details, and delete movies.

* User Authentication: The application uses the Identity library for user authentication. It supports login and registration functionality, and uses JWT for token-based authentication.

* Database Migrations: The application uses Entity Framework Core migrations for database schema management. It includes a sample entity and corresponding migrations for demonstration purposes.

* Swagger Documentation: The application includes Swagger for automatically generating interactive API documentation.

* Input Validation: The application uses FluentValidation for validating input data. It includes validation rules for both format and database logic.

* Logging: The application uses Serilog for logging. It logs important events and errors, which can be useful for troubleshooting and monitoring.

* Interfaces and Dependency Injection: The application follows the principles of SOLID design and uses interfaces for all classes. It also uses the built-in .NET Core dependency injection container for registering services and interfaces.

* Hexagonal Architecture: The application follows the principles of Hexagonal Architecture. It separates concerns into independent layers, making the code easier to maintain and test.

* Middleware: The application includes custom middleware for handling exceptions and authentication.

* Request and Response DTOs: The application uses Data Transfer Objects (DTOs) for requests and responses. This helps in keeping the API clean and organized.


## Getting Started
To get started with the project:
1. Clone the repository to your local machine.
2. Open the project in your preferred Integrated Development Environment (IDE).
3. Ensure that you have the .NET 6.0 SDK installed on your machine.
4. Install Docker on your machine, as the project uses Docker to run the SQL Server.

The project includes a `docker-compose.yml` file that defines a SQL Server service. To start the SQL Server, navigate to the project root directory in your terminal and run the following command:
```yml
docker-compose up -d
```

You can then interact with the API using a tool like Postman or curl.
The API documentation is available at http://localhost:5169/swagger.

## Project Structure:

#### Contexts
* DatabaseConnectionVerifier.cs
* MovieDbContext.cs

#### Controllers
* ApiController.cs
* ErrorsController.cs
* MovieController.cs
* UserController.cs

#### Dtos
* CreateMovieRequest.cs
* CreateMovieResponse.cs
* CreateUser.cs
* FindUserResponse.cs
* GetMovieResponse.cs
* GetUserProfileResponse.cs
* SigninRequest.cs
* SigninResponse.cs

#### Exceptions
* BadRequestException.cs
* NotFoundException.cs
* ValidationException.cs
* CustomResponse.cs

#### Helpers
* CryptoGraphy.cs
* IRequestCounter.cs
* RequestCounter.cs
* SwaggerConfig.cs

#### Managers
* MovieManager.cs
* UserManager.cs

#### Middlewares
* ExceptionHandlerMiddleware.cs
* IJwtValidator.cs
* JwtAuthorizationMiddleware.cs
* JwtAuthorizeAttribute.cs
* TimingMiddleware.cs

#### Models
* MovieModel.cs
* UserModel.cs

#### Repositories
* IMovieRepository.cs
* IUserRepository.cs
* MovieRepository.cs
* UserRepository.cs

#### Services
* IMovieService.cs
* MovieService.cs
* IUserService.cs
* UserService.cs

#### Validators
* CreateMovieValidator.cs
* SigninValidator.cs
* SignupValidator.cs

## Tree structure:
|<br>
│ Program.cs<br>
│ StartupTasks.cs<br>
│<br>
└───Contexts<br>
│   DatabaseConnectionVerifier.cs<br>
│   MovieDbContext.cs<br>
│<br>
└───Controllers<br>
│   ApiController.cs<br>
│   ErrorsController.cs<br>
│   MovieController.cs<br>
│   UserController.cs<br>
│<br>
└───Dtos<br>
│   CreateMovieRequest.cs<br>
│   CreateMovieResponse.cs<br>
│   CreateUser.cs<br>
│   FindUserResponse.cs<br>
│   GetMovieResponse.cs<br>
│   GetUserProfileResponse.cs<br>
│   SigninRequest.cs<br>
│   SigninResponse.cs<br>
│<br>
└───Exceptions<br>
│   BadRequestException.cs<br>
│   NotFoundException.cs<br>
│   ValidationException.cs<br>
│   CustomResponse.cs<br>
│<br>
└───Helpers<br>
│   CryptoGraphy.cs<br>
│   IRequestCounter.cs<br>
│   RequestCounter.cs<br>
│   SwaggerConfig.cs<br>
│<br>
└───Managers<br>
│   MovieManager.cs<br>
│   UserManager.cs<br>
│<br>
└───Middlewares<br>
│   ExceptionHandlerMiddleware.cs<br>
│   IJwtValidator.cs<br>
│   JwtAuthorizationMiddleware.cs<br>
│   JwtAuthorizeAttribute.cs<br>
│   TimingMiddleware.cs<br>
│<br>
└───Models<br>
│   MovieModel.cs<br>
│   UserModel.cs<br>
│<br>
└───Repositories<br>
│   IMovieRepository.cs<br>
│   IUserRepository.cs<br>
│   MovieRepository.cs<br>
│   UserRepository.cs<br>
│<br>
└───Services<br>
│   IMovieService.cs<br>
│   MovieService.cs<br>
│   IUserService.cs<br>
│   UserService.cs<br>
│<br>
└───Validators<br>
│   CreateMovieValidator.cs<br>
│   SigninValidator.cs<br>
│   SignupValidator.cs<br>
│<br>
