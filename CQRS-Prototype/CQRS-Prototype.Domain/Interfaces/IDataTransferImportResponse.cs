using CQRS_Prototype.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IDataTransferImportResponse<T> : IActionResponse<List<T>> where T : class
    {
        int RecordsInserted { get; set; }
        int RecordsUpdated { get; set; }
        int RecordsProcessed { get; set; }
    }
}
