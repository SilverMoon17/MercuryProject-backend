using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.Product
{
    public record ProductCreateRequest(string Name, string Description, double Price, int Stock, string Category, string IconUrl);
}
