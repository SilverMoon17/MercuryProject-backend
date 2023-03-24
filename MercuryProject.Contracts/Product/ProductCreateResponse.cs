using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Contracts.Product
{
    public record ProductCreateResponse
    (
        Guid Id,
        UserId UserId,
        string Name,
        string Description,
        double Price,
        int Stock,
        string Category,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}
