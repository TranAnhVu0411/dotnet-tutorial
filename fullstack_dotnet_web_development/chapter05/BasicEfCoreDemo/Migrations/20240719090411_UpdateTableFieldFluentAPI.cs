using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicEfCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableFieldFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("96d93733-ab0f-416a-b25a-90bca748e5dd"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("ce147751-0ef3-4ed5-8d5a-24057ce99b6b"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("d4855e00-b4d7-4f9c-adb7-1e5a1b9983a1"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("e4ec23fd-850f-435f-b5b5-d84bac2f383a"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Invoices",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("15b4cec7-d249-4cfa-a548-51c11ba0f9de"), 100m, "Andrew", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", "AwaitPayment" },
                    { new Guid("3a0f3cac-b2f9-4ae8-b9aa-456fd0d2a701"), 100m, "John", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-002", "AwaitPayment" },
                    { new Guid("ac6b3d41-98d0-4a87-8deb-4f28f3f01486"), 100m, "Adam", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-004", "AwaitPayment" },
                    { new Guid("c3d0df2b-8114-43aa-ae3d-28ea6efc1d4e"), 100m, "Alex", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-003", "AwaitPayment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("15b4cec7-d249-4cfa-a548-51c11ba0f9de"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("3a0f3cac-b2f9-4ae8-b9aa-456fd0d2a701"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("ac6b3d41-98d0-4a87-8deb-4f28f3f01486"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("c3d0df2b-8114-43aa-ae3d-28ea6efc1d4e"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Invoices",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("96d93733-ab0f-416a-b25a-90bca748e5dd"), 100m, "John", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-002", "AwaitPayment" },
                    { new Guid("ce147751-0ef3-4ed5-8d5a-24057ce99b6b"), 100m, "Adam", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-004", "AwaitPayment" },
                    { new Guid("d4855e00-b4d7-4f9c-adb7-1e5a1b9983a1"), 100m, "Andrew", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", "AwaitPayment" },
                    { new Guid("e4ec23fd-850f-435f-b5b5-d84bac2f383a"), 100m, "Alex", "Invoice for the Second month", new DateTimeOffset(new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-003", "AwaitPayment" }
                });
        }
    }
}
