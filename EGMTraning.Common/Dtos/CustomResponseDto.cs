using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMTraning.Common.Dtos
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
            };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
            };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
