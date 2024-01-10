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

MovieWatchlist
│  Program.cs<br>
│  StartupTasks.cs
│
└───Contexts
│  │  DatabaseConnectionVerifier.cs
│  │  MovieDbContext.cs
│  
└───Controllers
│  │  ApiController.cs
│  │  ErrorsController.cs
│  │  MovieController.cs
│  │  UserController.cs
│
└───Dtos
│  │  CreateMovieRequest.cs
│  │  CreateMovieResponse.cs
│  │  CreateUser.cs
│  │  FindUserResponse.cs
│  │  GetMovieResponse.cs
│  │  GetUserProfileResponse.cs
│  │  SigninRequest.cs
│  │  SigninResponse.cs
│
└───Exceptions
│  │  BadRequestException.cs
│  │  NotFoundException.cs
│  │  ValidationException.cs
│  │  CustomResponse.cs
│
└───Helpers
│  │  CryptoGraphy.cs
│  │  IRequestCounter.cs
│  │  RequestCounter.cs
│  │  SwaggerConfig.cs
│  
└───Managers
│  │  MovieManager.cs
│  │  UserManager.cs
│  
└───Middlewares
│  │  ExceptionHandlerMiddleware.cs
│  │  IJwtValidator.cs
│  │  JwtAuthorizationMiddleware.cs
│  │  JwtAuthorizeAttribute.cs
│  │  TimingMiddleware.cs
│  
└───Models
│  │  MovieModel.cs
│  │  UserModel.cs
│  
└───Repositories
│  │  IMovieRepository.cs
│  │  IUserRepository.cs
│  │  MovieRepository.cs
│  │  UserRepository.cs
│  
└───Services
│  │  IMovieService.cs
│  │  MovieService.cs
│  │  IUserService.cs
│  │  UserService.cs
│  
└───Validators
│  │  CreateMovieValidator.cs
│  │  SigninValidator.cs
│  │  SignupValidator.cs
│  │
