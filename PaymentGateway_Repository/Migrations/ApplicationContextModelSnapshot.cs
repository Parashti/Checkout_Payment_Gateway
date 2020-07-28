﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentGateway_Repository;

namespace PaymentGateway_Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentGateway_DataAccess.Bank", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("Date");

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<decimal>("AmountRemaining")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Name", "CardNumber", "ExpiryDate", "CVV");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("PaymentGateway_DataAccess.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("PaymentSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("PaymentId");

                    b.HasIndex("Name", "CardNumber", "ExpiryDate", "CVV");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("PaymentGateway_DataAccess.Payment", b =>
                {
                    b.HasOne("PaymentGateway_DataAccess.Bank", "Bank")
                        .WithMany("Payments")
                        .HasForeignKey("Name", "CardNumber", "ExpiryDate", "CVV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
