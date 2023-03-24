using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProductName =>
                Error.Conflict(code: "Product.DuplicateProductName", description: "This name is already in use.");
        }
    }
}
