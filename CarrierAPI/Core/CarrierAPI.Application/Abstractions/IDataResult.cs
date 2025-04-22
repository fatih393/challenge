using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions
{
      public interface IDataResult<out T>
    {
        bool Success { get; }
        string Message { get; }
        T Data { get; }
    }
}
