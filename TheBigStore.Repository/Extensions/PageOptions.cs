namespace TheBigStore.Repository.Extensions
{
    public class PageOptions
    {

        // PAGING
        public const int DefaultPageSize = 8;   //default page size is 10
        public const int DefaultPageNumber = 1;  //default page number is 1

        public int CurrentPage { get; set; } = DefaultPageNumber;

        public int PageSize { get; set; } = DefaultPageSize;

        public int TotalPages { get; set; }

    }
}
