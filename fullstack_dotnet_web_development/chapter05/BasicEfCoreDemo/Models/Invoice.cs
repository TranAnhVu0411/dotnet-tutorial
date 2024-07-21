using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasicEfCoreDemo.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Column("Id")]
        [Key]
        public Guid Id { get; set; }

        [Column(name: "InvoiceNumber", TypeName = "varchar(32)")]
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Column(name: "ContactName")]
        [Required]
        [MaxLength(32)]
        public string ContactName { get; set; } = string.Empty;

        [Column(name: "Description")]
        public string? Description { get; set; }

        [Column("Amount", TypeName = "decimal(18, 2)")]
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }

        [Column(name: "InvoiceDate", TypeName = "datetime")]
        [Required]
        public DateTimeOffset InvoiceDate { get; set; }

        [Column(name: "DueDate", TypeName = "datetime")]
        [Required]
        public DateTimeOffset DueDate { get; set; }

        [Column(name: "Status", TypeName = "varchar(16)")]
        public InvoiceStatus Status { get; set; }
    }
}