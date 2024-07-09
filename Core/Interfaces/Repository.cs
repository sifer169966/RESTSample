namespace RESTSample.Core.Interfaces;

public interface IDeviceInteractionRepository
{
    Entities.DeviceInteraction GetByID(int id);
    void CreateOne(Entities.DeviceInteraction dvi);
}
