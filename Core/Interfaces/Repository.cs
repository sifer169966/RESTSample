namespace RESTSample.Core.Interfaces{

    public interface IDeviceInteractionRepository
    {
        Entities.DeviceInteraction GetById(int id);
        void CreateOne(Entities.DeviceInteraction dvi);
    }
}