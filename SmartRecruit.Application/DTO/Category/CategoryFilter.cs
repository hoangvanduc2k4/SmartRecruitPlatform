using SmartRecruit.Application.Filters;

namespace SmartRecruit.Application.DTO.Category
{
    public class CategoryFilter : PaginationFilter
    {
        public string? SearchTerm { get; set; }

        public CategoryFilter() : base()
        {
        }

        public CategoryFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }
    }
}
