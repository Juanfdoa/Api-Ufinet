namespace Ufinet.Dtos.Pagination
{
    public class QueryParamsDto : PaginationParametersDto
    {
        public QueryParamsDto()
        {
            this.PageNumber = 0;
            this.RowsPerPage = 10;
        }

        public QueryParamsDto(int? pageNumber, int? rowsPerPage)
        {
            if (pageNumber.HasValue)
            {
                this.PageNumber = pageNumber < 0 ? 0 : pageNumber.Value;
            }
            else
            {
                this.PageNumber = 0;
            }

            if (rowsPerPage.HasValue)
            {
                this.RowsPerPage = rowsPerPage < 1 ? 10 : rowsPerPage > 50 ? 50 : rowsPerPage!.Value;
            }
            else
            {
                this.RowsPerPage = 10;
            }

        }
    }
}
