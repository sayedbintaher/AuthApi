using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetAuthApi.Models;
using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetAuthApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}