using System.ComponentModel.DataAnnotations;

namespace Storebook.Api.Endpoints.Livros.AtualizarLivroEndpoint;
public class AtualizarLivroRequest
{
    [MinLength(1), MaxLength(200)]
    public string? Titulo { get; set; }
    [MinLength(1), MaxLength(150)]
    public string? Autor { get; set; }
    [MinLength(1), MaxLength(100)]
    public string? Editora { get; set; }
    public int? AnoPublicacao { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public int? QuantidadePaginas { get; set; }
    public int? QuantidadeEstoque { get; set; }
}