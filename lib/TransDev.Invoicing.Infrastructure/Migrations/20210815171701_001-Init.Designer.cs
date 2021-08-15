﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransDev.Invoicing.Infrastructure.Persistance;

namespace TransDev.Invoicing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210815171701_001-Init")]
    partial class _001Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.AuditTrail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ItemHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("ItemHistory");
                });

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.ItemHistory", b =>
                {
                    b.HasOne("TransDev.Invoicing.Domain.Entities.AuditTrail", "AuditTrail")
                        .WithMany()
                        .HasForeignKey("AuditTrailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransDev.Invoicing.Domain.Entities.Item", "Parent")
                        .WithMany("ItemHistories")
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

            modelBuilder.Entity("TransDev.Invoicing.Domain.Entities.Item", b =>
                {
                    b.Navigation("ItemHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
