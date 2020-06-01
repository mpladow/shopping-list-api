using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    public class MLDevelopmentContext: DbContext
    {
        public MLDevelopmentContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MethodItem> MethodItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>().ToTable("Account", "rcp");
            modelBuilder.Entity<Category>().ToTable("Category", "rcp");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient", "rcp");
            modelBuilder.Entity<MethodItem>().ToTable("MethodItem", "rcp");
            modelBuilder.Entity<Recipe>().ToTable("Recipe", "rcp");

        }

    }
}
