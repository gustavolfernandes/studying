namespace Storebook.Domain.Entities;

[StronglyTypedId(backingType:StronglyTypedIdBackingType.Guid)]
public readonly partial struct LivroId { }
public class Livro
{
    //EF
    private Livro() { }
    private Livro(string titulo, string autor, string editora, int anoPublicacao, int quantidadePaginas, int quantidadeEstoque)
    {
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        AnoPublicacao = anoPublicacao;
        QuantidadePaginas = quantidadePaginas;
        QuantidadeEstoque = quantidadeEstoque;
        DataCadastro = DateTimeOffset.UtcNow;
    }

    //Cadastro Seed
    private Livro(
    LivroId id,
    string titulo,
    string autor,
    string editora,
    int anoPublicacao,
    int quantidadePaginas,
    DateTimeOffset dataCadastro,
    bool ativo,
    int quantidadeEstoque)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        AnoPublicacao = anoPublicacao;
        QuantidadePaginas = quantidadePaginas;
        DataCadastro = dataCadastro;
        Ativo = ativo;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public static Livro Seed(
    LivroId id,
    string titulo,
    string autor,
    string editora,
    int anoPublicacao,
    int quantidadePaginas,
    int quantidadeEstoque)
    {
        return new Livro(
            id,
            titulo,
            autor,
            editora,
            anoPublicacao,
            quantidadePaginas,
            new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero),
            true,
            quantidadeEstoque);
    }

    public static Livro CadastrarLivro(string titulo, string autor, string editora, int anoPublicacao, int quantidadePaginas, int quantidadeEstoque)
    {
        return new Livro(titulo, autor, editora, anoPublicacao, quantidadePaginas, quantidadeEstoque);
    }

    public LivroId Id { get; private set; }
    public string Titulo { get; private set; } = default!;
    public string Autor { get; private set; } = default!;
    public string Editora { get; private set; } = default!;
    public int AnoPublicacao { get; private set; } = default!;
    public int QuantidadePaginas { get; private set; } = default!;
    public int QuantidadeEstoque { get; private set; } = default!;
    public DateTimeOffset DataCadastro { get; private set; }
    public bool Ativo { get; private set; }

    public void EditarLivro(string? titulo, string? autor, string? editora, int? anoPublicacao, int? quantidadePaginas, int? quantidadeEstoque) 
    {
        Titulo = titulo ?? Titulo;
        Autor = autor ?? Autor;
        Editora = editora ?? Editora;
        AnoPublicacao = anoPublicacao ?? AnoPublicacao;
        QuantidadePaginas = quantidadePaginas ?? QuantidadePaginas;
        QuantidadeEstoque = quantidadeEstoque ?? QuantidadeEstoque;
    }

    public void Remover() => Ativo = false;
}