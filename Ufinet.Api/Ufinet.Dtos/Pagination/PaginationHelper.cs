using Microsoft.EntityFrameworkCore;

namespace Ufinet.Dtos.Pagination
{
    public static class PaginationHelper
    {
        public static PagedResponseDto<IEnumerable<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationParametersDto validFilter, int totalRecords)
        {
            var result = new PagedResponseDto<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.RowsPerPage);
            var totalPages = ((double)totalRecords / (double)validFilter.RowsPerPage);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            result.TotalPages = roundedTotalPages;
            result.TotalRecords = totalRecords;
            return result;
        }

        public static async Task<PagedResponseDto<IEnumerable<TModel>>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            PaginationParametersDto filter)
            where TModel : class
        {
            var totalItemsCountTask = query.Count();

            var startRow = filter.PageNumber * filter.RowsPerPage;
            var data = await query
                       .Skip(startRow)
                       .Take(filter.RowsPerPage)
                       .ToListAsync();

            return CreatePagedReponse(data, filter, totalItemsCountTask);
        }
    }
}
