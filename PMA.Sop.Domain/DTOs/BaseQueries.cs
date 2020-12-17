namespace PMA.Sop.Domain.DTOs
{
    public class BaseQueries
    {
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public string SearchKey { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}