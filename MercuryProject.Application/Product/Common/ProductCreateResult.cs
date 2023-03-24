using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Application.Product.Common
{
    public record ProductCreateResult
    (
        Domain.Product.Product Product
    );
}
