using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MercuryProject.Application.Authentication.Queries.Login;

namespace MercuryProject.Application.Authentication.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address").NotEmpty();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field is required");
        }
    }
}
