using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.Authentication
{
    public record RegisterRequest(
        string Username, 
        string FirstName, 
        string LastName, 
        string Email, 
        string Password,
        string ConfirmedPassword);
}
