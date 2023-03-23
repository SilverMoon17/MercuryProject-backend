using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Role,
        string Username, 
        string FirstName, 
        string LastName, 
        string Email,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime,
        string Token);
}
