using System.Net;

namespace Infrastructure.Response;

public class Responce<T>
{
    public T? Data { get; set; }
    public int HttpStatusCode { get; set; }
    public string Messenge { get; set; }

    public Responce(T data)
    {
        Data = data;
        HttpStatusCode = 200;
        Messenge = "";
    }

    public Responce(HttpStatusCode statusCode, string messenge)
    {
        HttpStatusCode = (int)statusCode;
        Messenge = messenge;
    }
    
}