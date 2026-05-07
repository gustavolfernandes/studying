namespace Storebook.Api;

public class PagedResponse<TData> : Response<TData>
{
    public PagedResponse(TData? data) : base(data)
    {
        
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}