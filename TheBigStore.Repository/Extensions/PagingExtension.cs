namespace TheBigStore.Repository.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int start, int take) => query.Skip((start - 1) * take).Take(take);
    }
}
