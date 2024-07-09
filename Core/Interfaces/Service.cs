namespace RESTSample.Core.Interfaces;

public interface IDeviceInteractionService
{
    void CreateInteraction(Entities.DeviceInteraction dvi);
    Entities.DeviceInteraction GetInteraction(int id);

}
