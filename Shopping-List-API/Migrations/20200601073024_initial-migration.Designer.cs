﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_List_API.Entities;

namespace Shopping_List_API.Migrations
{
    [DbContext(typeof(MLDevelopmentContext))]
    [Migration("20200601073024_initial-migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shopping_List_API.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("AccountId");

                    b.ToTable("Account","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Ingredient", b =>
                {
                    b.Property<long>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Measure");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Quantity");

                    b.Property<string>("RecipeId");

                    b.Property<long?>("RecipeId1");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId1");

                    b.ToTable("Ingredient","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.MethodItem", b =>
                {
                    b.Property<long>("MethodItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipeId");

                    b.Property<long?>("RecipeId1");

                    b.Property<string>("StepNo");

                    b.Property<string>("Text");

                    b.HasKey("MethodItemId");

                    b.HasIndex("RecipeId1");

                    b.ToTable("MethodItem","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Recipe", b =>
                {
                    b.Property<long>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("RecipeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipe","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Ingredient", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId1");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.MethodItem", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Recipe", "Recipe")
                        .WithMany("MethodItems")
                        .HasForeignKey("RecipeId1");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Recipe", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
