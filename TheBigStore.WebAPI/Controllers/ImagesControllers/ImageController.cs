using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.OrderInterfaces;

namespace TheBigStore.WebAPI.Controllers.ImagesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ImageController : ControllerBase
    {
        #region
        private readonly IImageService _imageService;
        private readonly ILogger<ImageController> _logger;
        #endregion

        #region Constructor
        public ImageController(IImageService imageService, ILogger<ImageController> logger)
        {
            _imageService = imageService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        [Route("getimagesbyid/{itemId:int}")]
        public async Task<IEnumerable<ImageDto>> Get(int itemId)
        {
            return await _imageService.GetAllImagesByItemId(itemId);
        }
    }
}
