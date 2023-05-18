using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        private readonly List<Idea.Idea> _ideas = new();
        private readonly List<ShoppingCart.ShoppingCart> _shoppingCarts = new();
        private readonly List<Order.Order> _orders = new();

        public string Role { get; set; } = "User";
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string? Mobile { get; set; } 
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmedPassword { get; set; } = null!;
        public IReadOnlyList<Idea.Idea> Ideas => _ideas.AsReadOnly();
        public IReadOnlyList<ShoppingCart.ShoppingCart> ShoppingCarts => _shoppingCarts.AsReadOnly();
        public IReadOnlyList<Order.Order> Orders => _orders.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }


        public User
        (UserId userId, string role, string username, string firstName, string lastName, string email,
            string password, string confirmedPassword
        , DateTime createdDateTime, DateTime updatedDateTime) : base(userId)
        {
            Username = username;
            Fullname = $"{firstName} {lastName}";
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
        public User() { }
    }
}
