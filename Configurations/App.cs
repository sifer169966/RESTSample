namespace RESTSample.Configurations;

public class App
{
    public required string URL { get; set; }
    public required DBPostgres DBPostgres { get; set; }
} 

public class DBPostgres
{
     public required string Host { get; set; }
     public required string Port { get; set; }
     public required string Username { get; set; }
     public required string Password { get; set; }
     public required string DBName { get; set; }
}