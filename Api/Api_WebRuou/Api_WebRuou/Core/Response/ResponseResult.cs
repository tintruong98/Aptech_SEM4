using Microsoft.AspNetCore.Mvc;
using static Api_WebRuou.Core.Enums.Enums;

namespace Api_WebRuou.Core.Response
{
    public class ResponseResult
    {
        public static OkResult<T> Success<T>(T data)
        {
            return new OkResult<T>()
            {
                Status = 200,
                Data = data
            };
        }

        public static OkResult<T> Erorr<T>(T data)
        {
            return new OkResult<T>()
            {
                Status = 400,
                Data = data
            };
        }
    }

    public class OkResult<T>
    {
        public int Status { get; set; }

        public T? Data { get; set; }
    }
}
