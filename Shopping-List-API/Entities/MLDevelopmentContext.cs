﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account", "rcp");
            modelBuilder.Entity<Category>().ToTable("Category", "rcp");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient", "rcp")
                .Property(i => i.Seperator)
                .HasDefaultValue(false);
            modelBuilder.Entity<MethodItem>().ToTable("MethodItem", "rcp")
                .Property(i => i.Seperator)
                .HasDefaultValue(false); ;
            modelBuilder.Entity<Recipe>().ToTable("Recipe", "rcp");
            modelBuilder.Entity<List>().ToTable("List", "rcp");
            modelBuilder.Entity<ListItem>().ToTable("ListItem", "rcp");
        }

    }
}
