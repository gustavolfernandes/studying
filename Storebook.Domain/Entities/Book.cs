namespace Storebook.Domain.Entities;

[StronglyTypedId(backingType:StronglyTypedIdBackingType.Guid)]
public readonly partial struct BookId { }
public class Book
{
    //EF
    private Book() { }
    private Book(string title, string author, string publisher, int publicationYear, int pageCount, int stockQuantity)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        PublicationYear = publicationYear;
        PageCount = pageCount;
        StockQuantity = stockQuantity;
        CreatedOn = DateTimeOffset.UtcNow;
    }

    //Creating Seed
    private Book(
    BookId id,
    string title,
    string author,
    string publisher,
    int publicationYear,
    int pageCount,
    DateTimeOffset createdOn,
    bool active,
    int stockQuantity)
    {
        Id = id;
        Title = title;
        Author = author;
        Publisher = publisher;
        PublicationYear = publicationYear;
        PageCount = pageCount;
        CreatedOn = createdOn;
        Active = active;
        StockQuantity = stockQuantity;
    }

    public static Book Seed(
    BookId id,
    string title,
    string author,
    string publisher,
    int publicationYear,
    int pageCount,
    int stockQuantity)
    {
        return new Book(
            id,
            title,
            author,
            publisher,
            publicationYear,
            pageCount,
            new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero),
            true,
            stockQuantity);
    }

    public static Book CreateBook(string title, string author, string publisher, int publicationYear, int pageCount, int stockQuantity)
    {
        return new Book(title, author, publisher, publicationYear, pageCount, stockQuantity);
    }

    public BookId Id { get; private set; }
    public string Title { get; private set; } = default!;
    public string Author { get; private set; } = default!;
    public string Publisher { get; private set; } = default!;
    public int PublicationYear { get; private set; } = default!;
    public int PageCount { get; private set; } = default!;
    public int StockQuantity { get; private set; } = default!;
    public DateTimeOffset CreatedOn { get; private set; }
    public bool Active { get; private set; }

    public void EditBook(string? title, string? author, string? publisher, int? publicationYear, int? pageCount, int? stockQuantity) 
    {
        Title = title ?? Title;
        Author = author ?? Author;
        Publisher = publisher ?? Publisher;
        PublicationYear = publicationYear ?? PublicationYear;
        PageCount = pageCount ?? PageCount;
        StockQuantity = stockQuantity ?? StockQuantity;
    }

    public void Remove() => Active = false;
}