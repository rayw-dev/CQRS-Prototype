using CQRS_Prototype.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Core.Models
{
    public class ActionResponse : IActionResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }

        public ActionResponse()
        {
            ErrorMessages = new List<string>();
        }

        public void MergeResponse(IActionResponse response)
        {
            if (!response.Success)
                Success = false; //set false if passed response failed
            response.ErrorMessages.ForEach(m =>
            {
                if (!ErrorMessages.Contains(m))
                    ErrorMessages.Add(m); //add any new messages
            });
        }
    }

    public class ActionResponse<T> : ActionResponse, IActionResponse<T>
    {
        public T Data { get; set; }
    }
}
