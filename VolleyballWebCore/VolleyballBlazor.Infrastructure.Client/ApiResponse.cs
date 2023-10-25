using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballBlazor.Infrastructure.Client
{
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiResponse(T data, int statusCode, string message = "") : base(statusCode, message)
        {
            Data = data;
        }

        public ApiResponse(T data, HttpResponseMessage response) : base(response)
        {
            StatusCode = (int)response.StatusCode;
            Message = response.ReasonPhrase ?? "";
            this.Data = data;
        }
    }

    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = "")
        {
            StatusCode = statusCode;
            Message = message;
        }
        public ApiResponse(HttpResponseMessage response)
        {
            StatusCode = (int)response.StatusCode;
            Message = response.ReasonPhrase ?? "";
        }
    }   
}
