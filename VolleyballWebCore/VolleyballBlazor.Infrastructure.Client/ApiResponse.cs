using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolleyballDomain.Shared;

namespace VolleyballBlazor.Infrastructure.Client
{
    public class ApiResponse<T> : ApiResponse
    {
        public new static readonly ApiResponse<T> NetworkErrorResponse = new ApiResponse<T>(500, "Nie udało się połączyć z serwerem. Spróbuj ponownie później lub zgłoś błąd.") { Success = false };
        public T? Data { get; set; }

        public ApiResponse(T data, int statusCode, string message = "") : base(statusCode, message)
        {
            Data = data;
        }

        private ApiResponse(int statusCode, string message = "") : base(statusCode, message)
        {
        }

        public ApiResponse(HttpResponseMessage response) : base(response)
        {
            StatusCode = (int)response.StatusCode;
            Message = response.ReasonPhrase ?? "";
            try
            {
                if (StatusCode >= 500)
                {
                    Success = false;
                    Message = $"Błąd serwera ({response.StatusCode}). Spróbuj ponownie później lub zgłoś błąd.";

                    return;
                }
                
                if (StatusCode >= 300)
                {
                    Success = false;
                    Message = $"Błąd klienta ({response.StatusCode}). Spróbuj ponownie później lub zgłoś błąd.";

                    return;
                }

                string stringResponse = response.Content.ReadAsStringAsync().Result;
                ServiceResponse<T>? serviceResponse = JsonSerializer.Deserialize<ServiceResponse<T>>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (serviceResponse != null)
                {
                    Data = serviceResponse.Data;
                    Success = serviceResponse.Success;
                    Message = serviceResponse.Message ?? "";
                }
                else
                {
                    Success = false;
                    Message = "Błąd serwera. Spróbuj ponownie później lub zgłoś błąd.";
                }
            }
            catch (Exception e)
            {
                Success = false;
                Message = e.Message;
            }
        }
    }

    public class ApiResponse
    {
        public static readonly ApiResponse ServerErrorResponse = new ApiResponse(500, "Błąd serwera. Spróbuj ponownie później lub zgłoś błąd.") { Success = false };

        public static readonly ApiResponse NetworkErrorResponse = new ApiResponse(500, "Nie udało się połączyć z serwerem. Spróbuj ponownie później lub zgłoś błąd.") { Success = false };
        public bool Success { get; set; }
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

            try
            {
                if (StatusCode >= 300)
                {
                    Success = false;
                    Message = $"Błąd serwera ({response.StatusCode}). Spróbuj ponownie później lub zgłoś błąd.";

                    return;
                }

                Message = response.ReasonPhrase ?? "";
                string stringResponse = response.Content.ReadAsStringAsync().Result;
                ServiceResponse? serviceResponse = JsonSerializer.Deserialize<ServiceResponse>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                StatusCode = (int)response.StatusCode;
                if (serviceResponse != null)
                {
                    Success = serviceResponse.Success;
                    Message = serviceResponse.Message ?? "Ok";
                }
                else
                {
                    Message = "Błąd serwera. Spróbuj ponownie później lub zgłoś błąd.";
                }
            } catch (Exception)
            {
                Success = false;
                Message = "Wystąpił nieoczekiwany błąd.";
            }
        }
    }
}
