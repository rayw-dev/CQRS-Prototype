using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IDataTransferImport<T> where T : class
    {
        bool OverwriteExistingRecords { get; set; }
        List<T> Import { get; set; }
    }
}
