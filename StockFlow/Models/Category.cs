namespace StockFlow.Models
{
    public class Category
    {
        // Relation 1 to many ( Category 1----->* Product)
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
