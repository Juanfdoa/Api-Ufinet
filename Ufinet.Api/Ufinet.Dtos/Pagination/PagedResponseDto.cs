namespace Ufinet.Dtos.Pagination
{
    public class PagedResponseDto<T>
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Resource { get; set; }


        public PagedResponseDto(T data, int pageNumber, int rowsPerPage)
        {
            this.PageNumber = pageNumber;
            this.RowsPerPage = rowsPerPage;
            this.Resource = data;
        }
    }
}
