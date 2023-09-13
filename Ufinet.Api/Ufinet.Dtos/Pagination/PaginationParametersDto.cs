namespace Ufinet.Dtos.Pagination
{
    public class PaginationParametersDto
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }

        public PaginationParametersDto()
        {
            this.PageNumber = 0;
            this.RowsPerPage = 10;
        }

        public PaginationParametersDto(int? pageNumber, int? RowsPerPage)
        {
            if (pageNumber.HasValue)
            {
                this.PageNumber = pageNumber < 0 ? 0 : pageNumber.Value;
            }
            else
            {
                this.PageNumber = 0;
            }
            if (RowsPerPage.HasValue)
            {
                this.RowsPerPage = RowsPerPage < 1 ? 10 : RowsPerPage > 50 ? 50 : RowsPerPage!.Value;
            }
            else
            {
                this.RowsPerPage = 10;
            }
        }
    }
}
