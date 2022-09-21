using Agreement_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Data
{
    public class ApplicationDContext:DbContext
    {
       
        public ApplicationDContext(DbContextOptions<ApplicationDContext> Options) : base(Options)
        {
            

        }
        public ApplicationDContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



        }
        public DbSet<User> Users { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
