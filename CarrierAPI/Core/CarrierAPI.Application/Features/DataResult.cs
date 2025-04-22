using CarrierAPI.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarrierAPI.Application.Features
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }
        public bool Success { get; }
        public string Message { get; }
        public DataResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) { }
        public SuccessDataResult(T data) : base(data, true, null) { }
    }
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message) : base(default, false, message) { }
        public ErrorDataResult() : base(default, false, "Bir hata oluştu.") { }
    }
}
