using ErrorOr;

namespace MercuryProject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProductName =>
                Error.Conflict(code: "Product.DuplicateProductName", description: "This product name is already in use.");
            public static Error TooLongDescription =>
                Error.Conflict(code: "Product.TooLongDescription", description: "Description too long (only 500 characters available)");
            public static Error ProductNotFound =>
                Error.NotFound(code: "Product.NotFound", description: "Product with this id doesn't exists");
            public static Error CorrectId =>
                Error.Conflict(code: "Product.CorrectId", description: "Specify the correct format of id");
        }
    }
}
