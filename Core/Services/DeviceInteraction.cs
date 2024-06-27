using RESTSample.Core.Interfaces;

namespace RESTSample.Core.Services{
    public class DeviceInteractionService : IDeviceInteractionService
    {
        private readonly IDeviceInteractionRepository _dviRepo;
        public DeviceInteractionService(IDeviceInteractionRepository dviRepo)
        {
            _dviRepo = dviRepo;
        }
        public void CreateOne(Entities.DeviceInteraction dvi)
        {
           _dviRepo.CreateOne(dvi);
        }

        public Entities.DeviceInteraction GetById(int id)
        {
            return  _dviRepo.GetById(id);
        }
    }
}