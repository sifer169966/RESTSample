
namespace RESTSample.Repositories{


public class DeviceInteractionRepository : Core.Interfaces.IDeviceInteractionRepository
    {
        private readonly Infrastructure.DeviceInteractionContext _context;
        public DeviceInteractionRepository(Infrastructure.DeviceInteractionContext context)
        {
            _context = context;
        }

        public Core.Entities.DeviceInteraction GetById(int id)
        {
            Infrastructure.DeviceInteraction? deviceInteraction = null;
            try 
            {
                deviceInteraction = _context.DeviceInteraction.Find(id);
            } 
            catch (Exception ex)
            {
               Console.WriteLine(ex);
               throw new Errors.Business.InternalError();
            }

            if (deviceInteraction == null) {
               throw new Errors.Business.ResourceNotFound("not found"); 
            }
            return new Core.Entities.DeviceInteraction{
                Id = deviceInteraction.Id,
                Name = deviceInteraction.Name
            };
            
        }

        public void CreateOne(Core.Entities.DeviceInteraction dvi)
        {
            try {
                Console.WriteLine("inserting into db...");
                Console.WriteLine(dvi.Name);
                _context.Add(new Infrastructure.DeviceInteraction{
                    Name = dvi.Name
                });
                _context.SaveChanges();
            } catch (Exception ex) {
                  Console.WriteLine("inn catch");
                Console.WriteLine(ex);
                throw new Errors.Business.InternalError();
            }
        }

    }
}