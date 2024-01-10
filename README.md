### Project structure:

MovieWatchlist
│  Program.cs
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
│  │  MovieResponse.cs
│  │  CreateUserDto.cs
│  │  CreateUserResponse.cs
│  │  SigninDto.cs
│
└───Helpers
│  │  CryptoGraphy.cs
│  │  IRequestCounter.cs
│  │  RequestCounter.cs
│  
└───Middlewares
│  │  IJwtValidator.cs
│  │  JwtAuthorizationMiddleware.cs
│  │  JwtAuthorizeAttribute.cs
│  │  TimingMiddleware.cs
│  
└───Models
│  │  Movie.cs
│  │  User.cs
│  
└───ServiceErrors
│  │  Errors.Movie.cs
│  │  Errors.User.cs
│  
└───Services
│  └───Movie
│     │  IMovieService.cs
│     │  MovieService.cs
│     │
│  └───User
│     │  IUserService.cs
│     │  UserService.cs
│     │


MovieWatchlist
│ Program.cs
│ StartupTasks.cs
│
└───Controllers
│ │ ApiController.cs
│ │ ErrorsController.cs
│ │ MovieController.cs
│ │ UserController.cs
│
└───Managers
│ │ MovieManager.cs
│ │ UserManager.cs
│
└───Services
│ │ MovieService.cs
│ │ UserService.cs
│
└───Repositories
│ │ MovieRepository.cs
│ │ UserRepository.cs
│
└───Models
│ │ Movie.cs
│ │ User.cs
