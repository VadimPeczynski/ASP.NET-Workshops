using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportsStore.Domain.Database;

namespace SportsStore.Domain.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20170622125027_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsStore.Domain.Entities.CartLine", b =>
                {
                    b.Property<int>("CartLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineId");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("SportsStore.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<bool>("GiftWrap");

                    b.Property<string>("Line1")
                        .IsRequired();

                    b.Property<string>("Line2");

                    b.Property<string>("Line3");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Shipped");

                    b.Property<string>("Zip");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SportsStore.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsStore.Domain.Entities.CartLine", b =>
                {
                    b.HasOne("SportsStore.Domain.Entities.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("SportsStore.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
