namespace Planet.Application.Common
{
    public class PaginationQuery<TResponse> : QueryBase<TResponse> where TResponse : ResponseBase, new()
    {
        public int PageSize { get; init; } = 50;
        public int CurrentPage { get; init; } = 1;
    }
}
