## Project structure:

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


## new:
                 
.
├── appsettings.Development.json
├── appsettings.json
├── bin
│   └── Debug
│       └── net6.0
│           ├── appsettings.Development.json
│           ├── appsettings.json
│           ├── Azure.Core.dll
│           ├── Azure.Identity.dll
│           ├── cs
│           │   └── FluentValidation.resources.dll
│           ├── da
│           │   └── FluentValidation.resources.dll
│           ├── de
│           │   └── FluentValidation.resources.dll
│           ├── ErrorOr.dll
│           ├── es
│           │   └── FluentValidation.resources.dll
│           ├── fi
│           │   └── FluentValidation.resources.dll
│           ├── FluentValidation.dll
│           ├── fr
│           │   └── FluentValidation.resources.dll
│           ├── Humanizer.dll
│           ├── it
│           │   └── FluentValidation.resources.dll
│           ├── ko
│           │   └── FluentValidation.resources.dll
│           ├── Microsoft.AspNetCore.Authentication.JwtBearer.dll
│           ├── Microsoft.Bcl.AsyncInterfaces.dll
│           ├── Microsoft.Data.SqlClient.dll
│           ├── Microsoft.EntityFrameworkCore.Abstractions.dll
│           ├── Microsoft.EntityFrameworkCore.Design.dll
│           ├── Microsoft.EntityFrameworkCore.dll
│           ├── Microsoft.EntityFrameworkCore.Relational.dll
│           ├── Microsoft.EntityFrameworkCore.SqlServer.dll
│           ├── Microsoft.Identity.Client.dll
│           ├── Microsoft.Identity.Client.Extensions.Msal.dll
│           ├── Microsoft.IdentityModel.Abstractions.dll
│           ├── Microsoft.IdentityModel.JsonWebTokens.dll
│           ├── Microsoft.IdentityModel.Logging.dll
│           ├── Microsoft.IdentityModel.Protocols.dll
│           ├── Microsoft.IdentityModel.Protocols.OpenIdConnect.dll
│           ├── Microsoft.IdentityModel.Tokens.dll
│           ├── Microsoft.OpenApi.dll
│           ├── Microsoft.SqlServer.Server.dll
│           ├── Microsoft.Win32.SystemEvents.dll
│           ├── mk
│           │   └── FluentValidation.resources.dll
│           ├── MovieWatchlist
│           ├── MovieWatchlist.deps.json
│           ├── MovieWatchlist.dll
│           ├── MovieWatchlist.pdb
│           ├── MovieWatchlist.runtimeconfig.json
│           ├── Newtonsoft.Json.dll
│           ├── nl
│           │   └── FluentValidation.resources.dll
│           ├── pl
│           │   └── FluentValidation.resources.dll
│           ├── pt
│           │   └── FluentValidation.resources.dll
│           ├── ru
│           │   └── FluentValidation.resources.dll
│           ├── runtimes
│           │   ├── unix
│           │   │   └── lib
│           │   │       ├── net6.0
│           │   │       │   ├── Microsoft.Data.SqlClient.dll
│           │   │       │   └── System.Drawing.Common.dll
│           │   │       ├── netcoreapp3.0
│           │   │       └── netcoreapp3.1
│           │   ├── win
│           │   │   └── lib
│           │   │       ├── net6.0
│           │   │       │   ├── Microsoft.Data.SqlClient.dll
│           │   │       │   ├── Microsoft.Win32.SystemEvents.dll
│           │   │       │   ├── System.Drawing.Common.dll
│           │   │       │   ├── System.Runtime.Caching.dll
│           │   │       │   ├── System.Security.Cryptography.ProtectedData.dll
│           │   │       │   └── System.Windows.Extensions.dll
│           │   │       ├── netcoreapp3.0
│           │   │       ├── netcoreapp3.1
│           │   │       └── netstandard2.0
│           │   ├── win-arm
│           │   │   └── native
│           │   │       └── Microsoft.Data.SqlClient.SNI.dll
│           │   ├── win-arm64
│           │   │   └── native
│           │   │       └── Microsoft.Data.SqlClient.SNI.dll
│           │   ├── win-x64
│           │   │   └── native
│           │   │       └── Microsoft.Data.SqlClient.SNI.dll
│           │   └── win-x86
│           │       └── native
│           │           └── Microsoft.Data.SqlClient.SNI.dll
│           ├── sv
│           │   └── FluentValidation.resources.dll
│           ├── Swashbuckle.AspNetCore.Swagger.dll
│           ├── Swashbuckle.AspNetCore.SwaggerGen.dll
│           ├── Swashbuckle.AspNetCore.SwaggerUI.dll
│           ├── System.Configuration.ConfigurationManager.dll
│           ├── System.Drawing.Common.dll
│           ├── System.IdentityModel.Tokens.Jwt.dll
│           ├── System.Memory.Data.dll
│           ├── System.Runtime.Caching.dll
│           ├── System.Security.Cryptography.ProtectedData.dll
│           ├── System.Security.Permissions.dll
│           ├── System.Windows.Extensions.dll
│           ├── tr
│           │   └── FluentValidation.resources.dll
│           └── zh-CN
│               └── FluentValidation.resources.dll
├── commands.txt
├── Contexts
│   ├── DatabaseConnectionVerifier.cs
│   └── MovieDbContext.cs
├── Controllers
│   ├── ApiController.cs
│   ├── ErrorsController.cs
│   ├── MovieController.cs
│   └── UserController.cs
├── docker-compose.yml
├── Dtos
│   ├── CreateMovieRequest.cs
│   ├── CreateMovieResponse.cs
│   ├── CreateUser.cs
│   ├── FindUserResponse.cs
│   ├── GetMovieResponse.cs
│   ├── GetUserProfileResponse.cs
│   ├── SigninRequest.cs
│   └── SigninResponse.cs
├── Exceptions
│   ├── BadRequestException.cs
│   ├── CustomResponse.cs
│   ├── NotFoundException.cs
│   └── ValidationException.cs
├── Helpers
│   ├── CryptoGraphy.cs
│   ├── IRequestCounter.cs
│   ├── RequestCounter.cs
│   └── SwaggerConfig.cs
├── Managers
│   ├── MovieManager.cs
│   └── UserManager.cs
├── Middlewares
│   ├── ExceptionHandlerMiddleware.cs
│   ├── IJwtValidator.cs
│   ├── JwtAuthorizationMiddleware.cs
│   ├── JwtAuthorizeAttribute.cs
│   └── TimingMiddleware.cs
├── Migrations
│   ├── 20240110072608_InitialCreate.cs
│   ├── 20240110072608_InitialCreate.Designer.cs
│   ├── 20240110080631_RemoveGeneresField.cs
│   ├── 20240110080631_RemoveGeneresField.Designer.cs
│   ├── 20240110112444_AddUsers.cs
│   ├── 20240110112444_AddUsers.Designer.cs
│   └── MovieDbContextModelSnapshot.cs
├── Models
│   ├── MovieModel.cs
│   └── UserModel.cs
├── MovieWatchlist.csproj
├── MovieWatchlist.sln
├── obj
│   ├── Debug
│   │   └── net6.0
│   │       ├── apphost
│   │       ├── MovieWatchlist.AssemblyInfo.cs
│   │       ├── MovieWatchlist.AssemblyInfoInputs.cache
│   │       ├── MovieWatchlist.assets.cache
│   │       ├── MovieWatchlist.csproj.AssemblyReference.cache
│   │       ├── MovieWatchlist.csproj.CopyComplete
│   │       ├── MovieWatchlist.csproj.CoreCompileInputs.cache
│   │       ├── MovieWatchlist.csproj.FileListAbsolute.txt
│   │       ├── MovieWatchlist.dll
│   │       ├── MovieWatchlist.GeneratedMSBuildEditorConfig.editorconfig
│   │       ├── MovieWatchlist.genruntimeconfig.cache
│   │       ├── MovieWatchlist.GlobalUsings.g.cs
│   │       ├── MovieWatchlist.MvcApplicationPartsAssemblyInfo.cache
│   │       ├── MovieWatchlist.MvcApplicationPartsAssemblyInfo.cs
│   │       ├── MovieWatchlist.pdb
│   │       ├── ref
│   │       │   └── MovieWatchlist.dll
│   │       ├── refint
│   │       │   └── MovieWatchlist.dll
│   │       ├── staticwebassets
│   │       └── staticwebassets.build.json
│   ├── MovieWatchlist.csproj.EntityFrameworkCore.targets
│   ├── MovieWatchlist.csproj.nuget.dgspec.json
│   ├── MovieWatchlist.csproj.nuget.g.props
│   ├── MovieWatchlist.csproj.nuget.g.targets
│   ├── project.assets.json
│   ├── project.nuget.cache
│   └── staticwebassets.pack.sentinel
├── Program.cs
├── Properties
│   └── launchSettings.json
├── README.md
├── Repositories
│   ├── IMovieRepository.cs
│   ├── IUserRepository.cs
│   ├── MovieRepository.cs
│   └── UserRepository.cs
├── Services
│   ├── IMovieService.cs
│   ├── IUserService.cs
│   ├── MovieService.cs
│   └── UserService.cs
├── StartupTasks.cs
└── Validators
    ├── CreateMovieValidator.cs
    ├── SigninValidator.cs
    └── SignupValidator.cs
