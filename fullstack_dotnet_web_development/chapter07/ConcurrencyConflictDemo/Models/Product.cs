using System.ComponentModel.DataAnnotations;

namespace ConcurrencyConflictDemo.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int Inventory { get; set; }
    // // Native database-generated concurrency token
    // [Timestamp] // You can set this data annotation or use Fluent API instead
    // public byte[] RowVersion { get; set; }

    // Application-managed concurrency token
    [ConcurrencyCheck] // You can set this data annotation or use Fluent API instead
    public Guid Version { get; set; }
}