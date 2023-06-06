using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Application.User.Common
{
    public record UserResult
    (
        Domain.User.User User
    );
}
