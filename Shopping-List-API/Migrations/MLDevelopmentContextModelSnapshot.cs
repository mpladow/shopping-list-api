﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_List_API.Entities;

namespace Shopping_List_API.Migrations
{
    [DbContext(typeof(MLDevelopmentContext))]
    partial class MLDevelopmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

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
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Measure");

                    b.Property<string>("Name");

                    b.Property<int>("PositionNo");

                    b.Property<decimal>("Quantity");

                    b.Property<int?>("RecipeId");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.List", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.HasKey("ListId");

                    b.HasIndex("AccountId");

                    b.ToTable("List","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.ListItem", b =>
                {
                    b.Property<int>("ListItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("IsComplete");

                    b.Property<DateTime?>("IsDeleted");

                    b.Property<int?>("ListId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("Quantity");

                    b.HasKey("ListItemId");

                    b.HasIndex("ListId");

                    b.ToTable("ListItem","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.MethodItem", b =>
                {
                    b.Property<int>("MethodItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecipeId");

                    b.Property<int>("StepNo");

                    b.Property<string>("Text");

                    b.HasKey("MethodItemId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MethodItem","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DescriptionMain");

                    b.Property<string>("DescriptionSecondary");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("PublishedAt");

                    b.HasKey("RecipeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipe","rcp");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.Ingredient", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.List", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.ListItem", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.List", "List")
                        .WithMany("ListItems")
                        .HasForeignKey("ListId");
                });

            modelBuilder.Entity("Shopping_List_API.Entities.MethodItem", b =>
                {
                    b.HasOne("Shopping_List_API.Entities.Recipe", "Recipe")
                        .WithMany("MethodItems")
                        .HasForeignKey("RecipeId");
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
