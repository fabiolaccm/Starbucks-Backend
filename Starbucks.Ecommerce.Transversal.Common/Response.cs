namespace Starbucks.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Response<T> Ok(T data, string message = null)
        {
            return new Response<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T>
            {
                Data = default(T),
                IsSuccess = false,
                Message = message
            };
        }
    }
}
