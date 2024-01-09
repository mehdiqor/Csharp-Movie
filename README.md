### Project structure:

MovieWatchlist
│  Program.cs
│  StartupTasks.cs
│
└───Contracts
│  │  CreateMovieRequest.cs
│  │  MovieResponse.cs
│  
└───Controllers
│  │  ApiController.cs
│  │  ErrorsController.cs
│  │  MovieController.cs
│
└───Helpers
│  │  DatabaseConnectionVerifier.cs
│  
└───Middlewares
│  │  TimingMiddleware.cs
│  
└───Models
│  │  Movie.cs
│  
└───ServiceErrors
│  │  Errors.Movie.cs
│  
└───Services
│  └───Movie
│     │  IMovieService.cs
│     │  MovieService.cs
│     │  UpsertedMovieResult.cs
│     │
│  └───User
│     │
