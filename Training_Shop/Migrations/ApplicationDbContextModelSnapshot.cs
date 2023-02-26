﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training_Shop.Data;

#nullable disable

namespace Training_Shop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Training_Shop.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Zabrze",
                            Country = "Poland",
                            Street = "Hermisza",
                            UserId = 1
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Warszawa",
                            Country = "Poland",
                            Street = "Mokotowska",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Training_Shop.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            TotalPrice = 4.0,
                            TotalQuantity = 3,
                            UserId = 1
                        },
                        new
                        {
                            CartId = 2,
                            TotalPrice = 5.0,
                            TotalQuantity = 6,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Training_Shop.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            CartItemId = 1,
                            CartId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            CartItemId = 2,
                            CartId = 1,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            CartItemId = 3,
                            CartId = 1,
                            ProductId = 3,
                            Quantity = 10
                        },
                        new
                        {
                            CartItemId = 4,
                            CartId = 2,
                            ProductId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            CartItemId = 5,
                            CartId = 2,
                            ProductId = 5,
                            Quantity = 6
                        });
                });

            modelBuilder.Entity("Training_Shop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Available = true,
                            Price = 44.990000000000002,
                            ProductName = "Piłka"
                        },
                        new
                        {
                            ProductId = 2,
                            Available = true,
                            Price = 10.0,
                            ProductName = "Deska"
                        },
                        new
                        {
                            ProductId = 3,
                            Available = false,
                            Price = 13999.0,
                            ProductName = "Auto"
                        },
                        new
                        {
                            ProductId = 4,
                            Available = true,
                            Price = 80.989999999999995,
                            ProductName = "Krzesło"
                        },
                        new
                        {
                            ProductId = 5,
                            Available = false,
                            Price = 2500.0,
                            ProductName = "Laptop"
                        },
                        new
                        {
                            ProductId = 6,
                            Available = true,
                            Price = 5.9900000000000002,
                            ProductName = "Koszyk"
                        },
                        new
                        {
                            ProductId = 7,
                            Available = false,
                            Price = 699.99000000000001,
                            ProductName = "Tabica"
                        },
                        new
                        {
                            ProductId = 8,
                            Available = true,
                            Price = 19.989999999999998,
                            ProductName = "Kawiatek"
                        });
                });

            modelBuilder.Entity("Training_Shop.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Dawid"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Agata"
                        });
                });

            modelBuilder.Entity("Training_Shop.Models.Address", b =>
                {
                    b.HasOne("Training_Shop.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Training_Shop.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Training_Shop.Models.Cart", b =>
                {
                    b.HasOne("Training_Shop.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Training_Shop.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Training_Shop.Models.CartItem", b =>
                {
                    b.HasOne("Training_Shop.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training_Shop.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Training_Shop.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Training_Shop.Models.Product", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Training_Shop.Models.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
