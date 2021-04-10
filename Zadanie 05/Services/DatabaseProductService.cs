using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_5.Data;
using Zadanie_5.Models;

namespace Zadanie_5.Services
{
    public class DatabaseProductService
    {
        private readonly ProductsContext _context;

        public DatabaseProductService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
