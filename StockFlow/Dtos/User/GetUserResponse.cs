using StockFlow.Models;

namespace StockFlow.Dtos.User
{
    /*Dto used to separate database model/entity from the data used in the API layer.
    Acting as boundary between the database and the API layer,
    it helps to prevent exposing sensitive information and allows for more control
    over the data being sent to the client. */
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid RoleId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
