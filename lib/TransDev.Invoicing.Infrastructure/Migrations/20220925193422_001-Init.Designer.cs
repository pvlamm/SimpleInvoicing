﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransDev.Invoicing.Infrastructure.Persistance;

#nullable disable

namespace TransDev.Invoicing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220925193422_001-Init")]
    partial class _001Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.AuditTrail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.ToTable("AuditTrail", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ClientHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AuditTrailId")
                        .HasColumnType("bigint");

                    b.Property<long>("BillingSystemAddressId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryBillingContactId")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryContactId")
                        .HasColumnType("int");

                    b.Property<long>("PrimarySystemAddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedAuditTrailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuditTrailId");

                    b.HasIndex("BillingSystemAddressId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PrimaryBillingContactId");

                    b.HasIndex("PrimaryContactId");

                    b.HasIndex("PrimarySystemAddressId");

                    b.HasIndex("UpdatedAuditTrailId");

                    b.ToTable("ClientHistory", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ContactHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AuditTrailId")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("SystemAddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedAuditTrailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuditTrailId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SystemAddressId");

                    b.HasIndex("UpdatedAuditTrailId");

                    b.ToTable("ContactHistory", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ItemHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AuditTrailId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long?>("UpdatedAuditTrailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuditTrailId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UpdatedAuditTrailId");

                    b.ToTable("ItemHistory", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SystemCityId")
                        .HasColumnType("int");

                    b.Property<string>("SystemStateId")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("SystemCityId");

                    b.HasIndex("SystemStateId");

                    b.ToTable("SystemAddress", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("SystemStateId")
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("SystemStateId");

                    b.ToTable("SystemCity", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemState", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.HasKey("Id");

                    b.ToTable("SystemState", (string)null);
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ClientHistory", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "AuditTrail")
                        .WithMany()
                        .HasForeignKey("AuditTrailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemAddress", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingSystemAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Client", "Parent")
                        .WithMany("History")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Contact", "PrimaryBillingContact")
                        .WithMany()
                        .HasForeignKey("PrimaryBillingContactId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemAddress", "PrimaryAddress")
                        .WithMany()
                        .HasForeignKey("PrimarySystemAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "UpdatedAuditTrail")
                        .WithMany()
                        .HasForeignKey("UpdatedAuditTrailId");

                    b.Navigation("AuditTrail");

                    b.Navigation("BillingAddress");

                    b.Navigation("Parent");

                    b.Navigation("PrimaryAddress");

                    b.Navigation("PrimaryBillingContact");

                    b.Navigation("PrimaryContact");

                    b.Navigation("UpdatedAuditTrail");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Contact", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ContactHistory", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "AuditTrail")
                        .WithMany()
                        .HasForeignKey("AuditTrailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Contact", "Parent")
                        .WithMany("History")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemAddress", "Address")
                        .WithMany()
                        .HasForeignKey("SystemAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "UpdatedAuditTrail")
                        .WithMany()
                        .HasForeignKey("UpdatedAuditTrailId");

                    b.Navigation("Address");

                    b.Navigation("AuditTrail");

                    b.Navigation("Parent");

                    b.Navigation("UpdatedAuditTrail");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ItemHistory", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "AuditTrail")
                        .WithMany()
                        .HasForeignKey("AuditTrailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Item", "Parent")
                        .WithMany("History")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "UpdatedAuditTrail")
                        .WithMany()
                        .HasForeignKey("UpdatedAuditTrailId");

                    b.Navigation("AuditTrail");

                    b.Navigation("Parent");

                    b.Navigation("UpdatedAuditTrail");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemAddress", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemCity", "City")
                        .WithMany()
                        .HasForeignKey("SystemCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemState", "State")
                        .WithMany()
                        .HasForeignKey("SystemStateId");

                    b.Navigation("City");

                    b.Navigation("State");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemCity", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.SystemState", "State")
                        .WithMany("Cities")
                        .HasForeignKey("SystemStateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Client", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("History");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Contact", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Item", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.SystemState", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
