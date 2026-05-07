namespace Storebook.Application.Books.ListBooksEndpoint;

public class ListBooksRequest
{
    public ListBooksRequest(int pageSize, int pageNumber)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}