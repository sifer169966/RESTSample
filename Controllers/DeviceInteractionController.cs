using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RESTSample.Core.Interfaces;
using System.Text.Json.Serialization;

namespace RESTSample.Controllers;
public class CreateDeviceInteractionRequest
{

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
public class DeviceInteractionResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    // Other properties
}

[ApiController]
[Route("device-interactions")]
public class DeviceInteractionsController : ControllerBase
{
    private readonly IDeviceInteractionService _dviSvc;
    public DeviceInteractionsController(IDeviceInteractionService dviSvc)
    {
        _dviSvc = dviSvc;
    }

    
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult GetById([FromRoute(Name = "id")] int id)
    {
        var dvi = _dviSvc.GetById(id);
        return Ok(new DeviceInteractionResponse{ Id = dvi.Id, Name = dvi.Name});
    }

    [HttpPost(Name = "Create")]
    public ActionResult Create(CreateDeviceInteractionRequest body)
    {
         var dvi = new Core.Entities.DeviceInteraction{
            Name = body.Name,
        };
        Console.WriteLine(dvi.Name);
        try {
             _dviSvc.CreateOne(dvi);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    Console.WriteLine("got request");
        return Ok();
    }
}
