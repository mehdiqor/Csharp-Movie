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
|
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
