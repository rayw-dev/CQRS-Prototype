using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IActionResponse
    {
        bool Success { get; set; }
        List<string> ErrorMessages { get; set; }
        void MergeResponse(IActionResponse response);
    }

    public interface IActionResponse<T> : IActionResponse
    {
        T Data { get; set; }
    }
}
