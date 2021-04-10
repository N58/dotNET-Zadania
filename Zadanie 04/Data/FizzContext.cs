using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_4.Forms;

namespace Zadanie_4.Data
{
    public class FizzContext : DbContext
    {
        public DbSet<FizzNumber> FizzNumbers { get; set; }

        public FizzContext(DbContextOptions options) : base(options) { }
    }
}
