using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string Role { get; set; } = "User";
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmedPassword { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }


        private User
        (UserId userId, string role, string username, string firstName, string lastName, string email,
            string password, string confirmedPassword
        , DateTime createdDateTime, DateTime updatedDateTime) : base(userId)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ConfirmedPassword = confirmedPassword;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create
        (string username, string firstName, string lastName, string email, string password,
            string confirmedPassword, string role = "User"
        )
        {
            return new(UserId.CreateUnique(), role: role, username: username, firstName: firstName, lastName: lastName,
                email: email, password: password, confirmedPassword: confirmedPassword,
                createdDateTime: DateTime.UtcNow, updatedDateTime: DateTime.UtcNow);
        }
        public User() {}
    }
}
