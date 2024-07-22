using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EfCoreRelationshipDemo.Models
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Guid InvoiceId { get; set; }

        // Reference navigation Property
        // Refrence Related Entity
        [JsonIgnore] // Ignore this property when running GET query
        public Invoice? Invoice { get; set; }
    }
}