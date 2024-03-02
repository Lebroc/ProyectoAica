namespace ProyectoAica.Responses;

public class ResponseApi<T>
{
    public T? Response { get; set; }
}

public class ResponseApi
{
    public string? Error { get; set; }
}