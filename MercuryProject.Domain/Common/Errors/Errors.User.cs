using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace MercuryProject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail =>
                Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");

            public static Error DuplicateUsername =>
                Error.Conflict(code: "User.DuplicateUsername", description: "Username is already in use.");
            public static Error PasswordConfirmation =>
                Error.Conflict(code: "User.PasswordConfirmation", description: "Password and confirmation password must be the same");
            public static Error UserNotFoundError =>
                Error.Conflict(code: "User.UserNotFound", description: "User not found");
        }
    }
}
