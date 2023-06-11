using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.Models.ViewModels
{
    public class OperationResultVM<T>
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public object AnotherData { get; set; }

        public OperationResultVM(bool success, IEnumerable<string> messages, HttpStatusCode statusCode)
        {
            Success = success;
            Messages = messages;
            StatusCode = statusCode;
        }
        public OperationResultVM(bool success, string message, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }

        public OperationResultVM(bool success, string message, HttpStatusCode statusCode, T data)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

        public OperationResultVM(bool success, string message, HttpStatusCode statusCode, T data, object anotherData)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
            AnotherData = anotherData;
        }

        public OperationResultVM(bool success, IEnumerable<string> messages, HttpStatusCode statusCode, IEnumerable<string> errors)
        {
            Success = success;
            Messages = messages;
            StatusCode = statusCode;
            Errors = errors;
        }

        public OperationResultVM(bool success, string message, HttpStatusCode statusCode, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Errors = errors;
        }

        public OperationResultVM(bool success, string message, HttpStatusCode statusCode, IEnumerable<string> errors, T data)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Errors = errors;
            Data = data;
        }
    }
}
