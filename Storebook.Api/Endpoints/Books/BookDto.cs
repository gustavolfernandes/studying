using System.ComponentModel.DataAnnotations;

namespace Storebook.Api.Endpoints.Books;

public class BookDto
{
    [Required, MinLength(1), MaxLength(200)]
    public string Title { get; set; } = default!;

    [Required, MinLength(1), MaxLength(150)]
    public string Author { get; set; } = default!;

    [Required, MinLength(1), MaxLength(100)]
    public string Publisher { get; set; } = default!;

    [Required]
    public int PublicationYear { get; set; }

    [Required, Range(1, int.MaxValue, ErrorMessage = "The value must be greater than zero.")]
    public int PageCount { get; set; }

    [Required]
    public int StockQuantity { get; set; }
}
