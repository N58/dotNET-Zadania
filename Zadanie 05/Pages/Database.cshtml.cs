using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zadanie_5.Models;
using Zadanie_5.Services;

namespace Zadanie_5.Pages
{
    public class DatabaseModel : PageModel
    {
        public DatabaseProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        public DatabaseModel(DatabaseProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
