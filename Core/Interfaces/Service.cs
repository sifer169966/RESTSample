namespace RESTSample.Core.Interfaces{

    public interface IDeviceInteractionService
    {
        void CreateOne(Entities.DeviceInteraction dvi);
        Entities.DeviceInteraction GetById(int id);

    }
}