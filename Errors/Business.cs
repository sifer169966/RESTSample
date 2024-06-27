namespace RESTSample.Errors.Business;
public class ResourceNotFound : Exception
{
    public ResourceNotFound() : base("resource not found")
    {}
    public ResourceNotFound(string message) : base(message)
    {}
}


public class InternalError : Exception
{
    public InternalError() : base("internal server error")
    {}
}