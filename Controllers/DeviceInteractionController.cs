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
    public int ID { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    // Other properties
}

public class ErrorResponse
{
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }
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

    
    [HttpGet("{id}", Name = "GetInteraction")]
    public ActionResult GetInteraction([FromRoute(Name = "id")] int id)
    {
        var dvi = _dviSvc.GetInteraction(id);
        return Ok(new DeviceInteractionResponse{ ID = dvi.ID, Name = dvi.Name});
    }

    [HttpPost(Name = "CreateInteraction")]
    public ActionResult CreateInteraction(CreateDeviceInteractionRequest body)
    {
         var dvi = new Core.Entities.DeviceInteraction{
            Name = body.Name,
        };
        try {
             _dviSvc.CreateInteraction(dvi);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, new ErrorResponse{
                Code = "ERR-001",
                Message = ex.Message,
            });
        }
        
        return Ok();
    }
}
