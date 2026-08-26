namespace StockFlow.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Category Category { get; set; } = null!;
        public Guid CategoryId { get; set; } // FK
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string Status { get; set; } = string.Empty; // Status Could be "Out of Stock", "Available", "Need Restock"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }

}
