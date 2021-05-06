using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RistoGest.Data
{
    public class DataBase : DbContext
    {
        public DbSet<Piatto> Piatti { get; set; }

        public DataBase(DbContextOptions options) : base(options) { }
    }
}
