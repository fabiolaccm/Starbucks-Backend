using Microsoft.AspNetCore.Mvc;

namespace Starbucks.Ecommerce.Services.Api.Common
{
    public class ApiException
    {
        public string Message { get; set; }

        public static ApiException Build(string message)
        {
            return new ApiException
            {
                Message = message
            };
        }

        public static ObjectResult Build412(string target)
        {
            return BuildErrorResult(412, target);
        }

        public static ObjectResult Build500(string target)
        {
            return BuildErrorResult(500, target);
        }

        public static ObjectResult Build500(Exception ex)
        {
            return Build500(ex.Message);
        }

        private static ObjectResult BuildErrorResult(int errorCode, string target) {
            var result = new ObjectResult(Build(target));
            result.StatusCode = errorCode;
            return result;
        }

        public static ApiException Build(Exception ex)
        {
            return new ApiException
            {
                Message = ex.Message
            };
        }
    }
}
