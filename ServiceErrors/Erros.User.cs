// using UserAuthentication.Models;
// using ErrorOr;

// namespace UserAuthentication.UserErrors;

// public static class Errors
// {
//     public static class UserErros
//     {
//         public static Error InvalidFulname => Error.Validation(
//             code: "User.InvalidFulname",
//             description: $"Fullname must be at least {UserAuth.MinFullnameLength} " +
//             $"characters long and at most {UserAuth.MaxFullnameLength} characters long"
//         );

//         public static Error InvalidPassword => Error.Validation(
//             code: "User.InvalidPassword",
//             description: $"Password must be at least {UserAuth.MinPasswordLength} " +
//             $"characters long and at most {UserAuth.MaxPasswordLength} characters long"
//         );

//         public static Error InvalidEmail => Error.Validation(
//             code: "User.InvalidEmail",
//             description: "Email format is not valid"
//         );

//         public static Error NotFound => Error.NotFound(
//             code: "User.NotFound",
//             description: "User NotFound!!!"
//         );
//     }
// }
