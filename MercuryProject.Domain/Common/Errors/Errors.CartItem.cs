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
        public static class CartItem
        {
            public static Error Stock =>
                Error.NotFound("CartItem.Stock", "Unfortunately, this quantity is not in stock.");
            public static Error NotFound =>
                Error.NotFound("CartItem.NotFound", "CartItem with this id was not found");
            public static Error CorrectId =>
                Error.Conflict(code: "CartItem.CorrectId", description: "Specify the correct format of id");
        }
    }
}
