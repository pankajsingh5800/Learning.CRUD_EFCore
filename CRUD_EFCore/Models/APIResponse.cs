namespace CRUD_EFCore.Models
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public required T? Data { get; set; }  // Generic Type to Hold Any Data
    }

    public class APIPostResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
