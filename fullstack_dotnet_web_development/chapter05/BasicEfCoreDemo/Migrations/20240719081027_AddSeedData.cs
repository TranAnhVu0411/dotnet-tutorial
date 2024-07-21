using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicEfCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("373d0e1b-98fa-4997-a354-dffe87fd5c9f"), 100m, "Alex", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-003", 1 },
                    { new Guid("e12f135c-2dc6-4f25-a13c-d7ec6d362637"), 100m, "Andrew", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", 1 },
                    { new Guid("e1320f45-3b15-4bbe-bfe2-368e531884a6"), 100m, "Adam", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-004", 1 },
                    { new Guid("f0172da5-0dd2-45a3-8f09-2283c586d0a9"), 100m, "John", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-002", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("373d0e1b-98fa-4997-a354-dffe87fd5c9f"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("e12f135c-2dc6-4f25-a13c-d7ec6d362637"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("e1320f45-3b15-4bbe-bfe2-368e531884a6"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("f0172da5-0dd2-45a3-8f09-2283c586d0a9"));
        }
    }
}
