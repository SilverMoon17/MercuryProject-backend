using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MercuryProject.Application.User.Commands
{
    public record UpdateUserInfoCommand
        (
            string Username,
            string Fullname,
            string Email,
            string Mobile
        ) : IRequest;
}
