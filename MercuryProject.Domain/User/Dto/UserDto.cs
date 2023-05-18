using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Domain.User.Dto
{
    public record UserDto
    (
        string Username,
        string FullName,
        string Role,
        string Email,
        string Mobile
    );
}
