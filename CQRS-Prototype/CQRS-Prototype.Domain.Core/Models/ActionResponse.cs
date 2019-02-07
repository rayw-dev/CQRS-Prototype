using CQRS_Prototype.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Core.Models
{
    public class ActionResponse : IActionResponse
    {
        public bool Success { get; set; }
        public bool HasErrors => ErrorMessages != null && ErrorMessages.Count > 0;
        public List<string> ErrorMessages { get; set; }
        public bool HasInfo => InfoMessages != null && InfoMessages.Count > 0;
        public List<string> InfoMessages { get; set; }
        public bool HasWarnings => WarningMessages != null && WarningMessages.Count > 0;
        public List<string> WarningMessages { get; set; }

        public ActionResponse()
        {
            ErrorMessages = new List<string>();
            InfoMessages = new List<string>();
            WarningMessages = new List<string>();
        }

        public void MergeResponse(IActionResponse response)
        {
            if (!response.Success)
                Success = false; //set false if passed response failed
            if (response.HasErrors)
            {
                response.ErrorMessages.ForEach(m =>
                {
                    if (!ErrorMessages.Contains(m))
                        ErrorMessages.Add(m); //add any new messages
                });
            }
            if (response.HasWarnings)
            {
                response.WarningMessages.ForEach(m =>
                {
                    if (!WarningMessages.Contains(m))
                        WarningMessages.Add(m); //add any new messages
                });
            }
            if (response.HasInfo)
            {
                response.InfoMessages.ForEach(m =>
                {
                    if (!InfoMessages.Contains(m))
                        InfoMessages.Add(m); //add any new messages
                });
            }
        }
    }

    public class ActionResponse<T> : ActionResponse, IActionResponse<T>
    {
        public T Data { get; set; }
    }
}
