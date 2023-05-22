namespace Catalog.API.Base
{
    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalRecords { get; set; }
        public IEnumerable<T> Records { get; set; }

        public PaginatedResult(int pageNumber, int pageSize, long totalRecords, IEnumerable<T> records)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Records = records;
        }
    }
}
