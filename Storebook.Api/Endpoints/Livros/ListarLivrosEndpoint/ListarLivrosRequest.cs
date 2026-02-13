namespace Storebook.Application.Livros.ListarLivrosEndpoint;

public class ListarLivrosRequest
{
    public ListarLivrosRequest(int pageSize, int pageNumber)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}