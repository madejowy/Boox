using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.Models
{
    public class BooxContext : DbContext
    {
        public BooxContext(DbContextOptions<BooxContext> options)
:       base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
