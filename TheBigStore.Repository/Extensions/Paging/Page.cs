namespace TheBigStore.Repository.Extensions.Paging
{
    public class Page<E>
    {
        public List<E> Items { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount => (int)Math.Ceiling(decimal.Divide(Total, PageSize));
    }
}
