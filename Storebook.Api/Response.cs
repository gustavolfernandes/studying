using System.Text.Json.Serialization;

namespace Storebook.Api;
public class Response<TData>
{
    public Response(
        TData? data,
        string? message = null)
    {
        Data = data;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }
}