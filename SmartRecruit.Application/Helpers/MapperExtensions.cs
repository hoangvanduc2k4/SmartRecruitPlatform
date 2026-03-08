using AutoMapper;

namespace SmartRecruit.Application.Helpers
{
    public static class MapperExtensions
    {
        public static PagedList<TDestination> MapToPagedList<TSource, TDestination>(
            this PagedList<TSource> source,
            IMapper mapper)
        {
            var mappedItems = mapper.Map<List<TDestination>>(source);

            return new PagedList<TDestination>(
                mappedItems,
                source.TotalCount,
                source.CurrentPage,
                source.PageSize
            );
        }
    }
}
