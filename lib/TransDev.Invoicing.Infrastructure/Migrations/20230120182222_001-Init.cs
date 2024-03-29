﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransDev.Invoicing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _001Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.UniqueConstraint("AK_Client_PublicId", x => x.PublicId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemState",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AuditTrailId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAuditTrailId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemHistory_AuditTrail_AuditTrailId",
                        column: x => x.AuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemHistory_AuditTrail_UpdatedAuditTrailId",
                        column: x => x.UpdatedAuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemHistory_Item_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemStateId = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemAddress_SystemState_SystemStateId",
                        column: x => x.SystemStateId,
                        principalTable: "SystemState",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PrimarySystemAddressId = table.Column<long>(type: "bigint", nullable: false),
                    BillingSystemAddressId = table.Column<long>(type: "bigint", nullable: false),
                    PrimaryContactId = table.Column<int>(type: "int", nullable: false),
                    PrimaryBillingContactId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    AuditTrailId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAuditTrailId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientHistory_AuditTrail_AuditTrailId",
                        column: x => x.AuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientHistory_AuditTrail_UpdatedAuditTrailId",
                        column: x => x.UpdatedAuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientHistory_Client_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Contact_PrimaryBillingContactId",
                        column: x => x.PrimaryBillingContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientHistory_Contact_PrimaryContactId",
                        column: x => x.PrimaryContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientHistory_SystemAddress_BillingSystemAddressId",
                        column: x => x.BillingSystemAddressId,
                        principalTable: "SystemAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientHistory_SystemAddress_PrimarySystemAddressId",
                        column: x => x.PrimarySystemAddressId,
                        principalTable: "SystemAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    SystemAddressId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AuditTrailId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAuditTrailId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactHistory_AuditTrail_AuditTrailId",
                        column: x => x.AuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactHistory_AuditTrail_UpdatedAuditTrailId",
                        column: x => x.UpdatedAuditTrailId,
                        principalTable: "AuditTrail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactHistory_Contact_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactHistory_SystemAddress_SystemAddressId",
                        column: x => x.SystemAddressId,
                        principalTable: "SystemAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SystemState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "AK", "Alaska" },
                    { "AL", "Alabama" },
                    { "AR", "Arkansas" },
                    { "AS", "American Samoa" },
                    { "AZ", "Arizona" },
                    { "CA", "California" },
                    { "CO", "Colorado" },
                    { "CT", "Connecticut" },
                    { "DC", "District Of Columbia" },
                    { "DE", "Delaware" },
                    { "FL", "Florida" },
                    { "FM", "Federated States Of Micronesia" },
                    { "GA", "Georgia" },
                    { "GU", "Guam" },
                    { "HI", "Hawaii" },
                    { "IA", "Iowa" },
                    { "ID", "Idaho" },
                    { "IL", "Illinois" },
                    { "IN", "Indiana" },
                    { "KS", "Kansas" },
                    { "KY", "Kentucky" },
                    { "LA", "Louisiana" },
                    { "MA", "Massachusetts" },
                    { "MD", "Maryland" },
                    { "ME", "Maine" },
                    { "MH", "Marshall Islands" },
                    { "MI", "Michigan" },
                    { "MN", "Minnesota" },
                    { "MO", "Missouri" },
                    { "MP", "Northern Mariana Islands" },
                    { "MS", "Mississippi" },
                    { "MT", "Montana" },
                    { "NC", "North Carolina" },
                    { "ND", "North Dakota" },
                    { "NE", "Nebraska" },
                    { "NH", "New Hampshire" },
                    { "NJ", "New Jersey" },
                    { "NM", "New Mexico" },
                    { "NV", "Nevada" },
                    { "NY", "New York" },
                    { "OH", "Ohio" },
                    { "OK", "Oklahoma" },
                    { "OR", "Oregon" },
                    { "PA", "Pennsylvania" },
                    { "PR", "Puerto Rico" },
                    { "PW", "Palau" },
                    { "RI", "Rhode Island" },
                    { "SC", "South Carolina" },
                    { "SD", "South Dakota" },
                    { "TN", "Tennessee" },
                    { "TX", "Texas" },
                    { "UT", "Utah" },
                    { "VA", "Virginia" },
                    { "VI", "Virgin Islands" },
                    { "VT", "Vermont" },
                    { "WA", "Washington" },
                    { "WI", "Wisconsin" },
                    { "WV", "West Virginia" },
                    { "WY", "Wyoming" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_AuditTrailId",
                table: "ClientHistory",
                column: "AuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_BillingSystemAddressId",
                table: "ClientHistory",
                column: "BillingSystemAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_ParentId",
                table: "ClientHistory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_PrimaryBillingContactId",
                table: "ClientHistory",
                column: "PrimaryBillingContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_PrimaryContactId",
                table: "ClientHistory",
                column: "PrimaryContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_PrimarySystemAddressId",
                table: "ClientHistory",
                column: "PrimarySystemAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_UpdatedAuditTrailId",
                table: "ClientHistory",
                column: "UpdatedAuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ClientId",
                table: "Contact",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_AuditTrailId",
                table: "ContactHistory",
                column: "AuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_ParentId",
                table: "ContactHistory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_SystemAddressId",
                table: "ContactHistory",
                column: "SystemAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_UpdatedAuditTrailId",
                table: "ContactHistory",
                column: "UpdatedAuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistory_AuditTrailId",
                table: "ItemHistory",
                column: "AuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistory_ParentId",
                table: "ItemHistory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistory_UpdatedAuditTrailId",
                table: "ItemHistory",
                column: "UpdatedAuditTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAddress_SystemStateId",
                table: "SystemAddress",
                column: "SystemStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientHistory");

            migrationBuilder.DropTable(
                name: "ContactHistory");

            migrationBuilder.DropTable(
                name: "ItemHistory");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "SystemAddress");

            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "SystemState");
        }
    }
}
