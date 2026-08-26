namespace StockFlow.Dtos.User
{
    public class CreateUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
