
namespace RESTSample.Repositories;


public class DeviceInteractionRepository : Core.Interfaces.IDeviceInteractionRepository
    {
        private readonly Infrastructure.DeviceInteractionContext _context;
        public DeviceInteractionRepository(Infrastructure.DeviceInteractionContext context)
        {
            _context = context;
        }

        public Core.Entities.DeviceInteraction GetByID(int id)
        {
            Infrastructure.DeviceInteraction? deviceInteraction = null;
            try 
            {
                deviceInteraction = _context.DeviceInteraction.Find(id);
            } 
            catch (Exception e)
            {
               Console.WriteLine(e);
               throw new Errors.Business.InternalError();
            }

            if (deviceInteraction == null) {
               throw new Errors.Business.ResourceNotFound("not found"); 
            }
            return new Core.Entities.DeviceInteraction{
                ID = deviceInteraction.ID,
                Name = deviceInteraction.Name
            };
            
        }

        public void CreateOne(Core.Entities.DeviceInteraction dvi)
        {
            try {
                _context.Add(new Infrastructure.DeviceInteraction{
                    Name = dvi.Name
                });
                _context.SaveChanges();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw new Errors.Business.InternalError(e);
            }
        }

    }
