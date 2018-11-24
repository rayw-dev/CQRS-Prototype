using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IRequest
    {
    }

    public interface IResponse
    {
        bool Success { get; set; }
        List<string> Errors { get; set; }
    }

    public interface IRequestBody
    {
        IResponse InvokeRequest(IRequest request);
    }
}
