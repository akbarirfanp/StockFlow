namespace StockFlow.Dtos
{
    public class SuccessResponse<T>
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

    public class ErrorResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string[]> Errors { get; set; } = new();

    }
}
