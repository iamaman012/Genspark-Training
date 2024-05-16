﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaShopAPI.Contexts;

#nullable disable

namespace PizzaShopAPI.Migrations
{
    [DbContext(typeof(PizzaShopContext))]
    [Migration("20240516104217_CustomerDetail_Table_Addedd")]
    partial class CustomerDetail_Table_Addedd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaShopAPI.Models.Customer", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.CustomerDetail", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<byte[]>("HashPasswordKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Order", b =>
                {
                    b.Property<int>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OId"), 1L, 1);

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("OId");

                    b.HasIndex("CId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("OdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OdId"), 1L, 1);

                    b.Property<int>("OId")
                        .HasColumnType("int");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("OdId");

                    b.HasIndex("OId");

                    b.HasIndex("PId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Pizza", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PId = 101,
                            Description = "Spicy With Loaded Cheese",
                            Name = "Chilli Cheese Pizza",
                            Price = 100,
                            Quantity = 10
                        },
                        new
                        {
                            PId = 102,
                            Description = "Panner With Loaded Cheese",
                            Name = "Panner Cheese Pizza",
                            Price = 200,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("PizzaShopAPI.Models.CustomerDetail", b =>
                {
                    b.HasOne("PizzaShopAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Order", b =>
                {
                    b.HasOne("PizzaShopAPI.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("PizzaShopAPI.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PizzaShopAPI.Models.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("PizzaShopAPI.Models.Pizza", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
