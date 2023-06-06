using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.User
{
    public record UpdateUserInfoRequest
    (
        string Username,
        string Fullname,
        string Email,
        string Mobile
    );
}
