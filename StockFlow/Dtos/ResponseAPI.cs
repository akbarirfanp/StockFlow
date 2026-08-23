namespace StockFlow.Dtos
{
    public class ResponseAPI<T>
    {
        public bool Error { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; }
        public T? Data { get; set; }
    }
    
    public class PaginatedResponse<T>
    {
        public int Page { get; set; }
    }
}
