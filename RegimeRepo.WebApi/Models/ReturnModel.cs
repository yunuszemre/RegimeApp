namespace RegimeRepo.WebApi.Models
{
    public class ReturnModel<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = "";
        public T? Data { get; set; }
    }
}
