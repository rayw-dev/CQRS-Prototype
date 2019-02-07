using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IActionResponse
    {
        bool Success { get; set; }
        bool HasErrors { get; }
        List<string> ErrorMessages { get; set; }
        bool HasInfo { get; }
        List<string> InfoMessages { get; set; }
        bool HasWarnings { get; }
        List<string> WarningMessages { get; set; }
        void MergeResponse(IActionResponse response);
    }

    public interface IActionResponse<T> : IActionResponse
    {
        T Data { get; set; }
    }
}
