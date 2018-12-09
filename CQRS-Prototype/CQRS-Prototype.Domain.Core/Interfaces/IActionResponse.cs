using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Core.Interfaces
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
