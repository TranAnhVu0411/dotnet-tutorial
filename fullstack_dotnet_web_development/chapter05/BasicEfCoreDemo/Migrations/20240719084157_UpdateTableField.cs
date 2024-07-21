using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicEfCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Invoices",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Invoices",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Invoices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Invoices",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
