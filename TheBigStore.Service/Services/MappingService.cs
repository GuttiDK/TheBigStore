using AutoMapper;

namespace TheBigStore.Service.Services
{
    public class MappingService
    {
        public readonly IMapper _mapper;

        public MappingService()
        {
            MapperConfiguration config = new(cfg =>
            {

            });

            if (config == null || _mapper == null)
            {
                Console.WriteLine("Failed to create map: config is null or _mapper");
                throw new ArgumentNullException(nameof(config));
            }

            try
            {
                _mapper = config.CreateMapper();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create map: " + ex.Message);
            }
        }
    }
}
