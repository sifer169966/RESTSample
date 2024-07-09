namespace RESTSample.Errors.Business;
public class ResourceNotFound : Exception
{
    public ResourceNotFound() : base("resource not found")
    { }
    public ResourceNotFound(string message) : base(message)
    { }
}


public class InternalError : Exception
{
    private const string DefaultMessage = "internal server error";
    public InternalError() : base(DefaultMessage)
    { }
    public InternalError(Exception innerException) : base(DefaultMessage, innerException)
    { }
    public InternalError(string message, Exception innerException) : base(message, innerException)
    { }
}