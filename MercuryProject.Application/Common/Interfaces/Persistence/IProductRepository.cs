using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Product;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<Domain.Product.Product?> GetProductByName(string name);
        void Add(Domain.Product.Product product);
    }
}
