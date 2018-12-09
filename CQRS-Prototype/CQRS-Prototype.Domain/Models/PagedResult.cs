using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Models
{
    public class PagedResult
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;

        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
        public List<int> PageSizes => new List<int> { 20, 50, 100, 200 };
    }
    public class PagedResult<T> : PagedResult where T : class
    {
        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
