namespace Planet.Application.Common
{
    public sealed class Pagination<T>
    {
        public int RecordCount { get; init; }
        public int PageSize { get; init; }
        public int CurrentPage { get; init; }
        public int PageCount => (int)Math.Ceiling((decimal)(RecordCount == 0 ? RecordCount + 1 : RecordCount) / PageSize);
        public List<T> Items { get; init; }
    }
}
