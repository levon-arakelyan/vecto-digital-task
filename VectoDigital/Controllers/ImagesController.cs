using Microsoft.AspNetCore.Mvc;
using VectoDigital.Core.Enums;
using VectoDigital.Core.Interfaces;
using VectoDigital.Core.Models.Images;

namespace VectoDigital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController(IImagesService imagesService) : ControllerBase
    {
        private readonly IImagesService _imagesService = imagesService;

        [HttpGet]
        public IActionResult GetImages()
        {
            var data = _imagesService.GetImages();
            return Ok(data);
        }

        [HttpPost("/{imageId}/[action]")]
        public IActionResult SetPlugins(int imageId, [FromBody] ImagePlugin[] pluginsIds)
        {
            var image = _imagesService.SetPlugins(imageId, pluginsIds);
            return Ok(image);
        }

        [HttpPost("/{imageId}/[action]")]
        public IActionResult Manipulate(int imageId, [FromBody] ImageManipulationRequest req)
        {
            var data = _imagesService.Manipulate(imageId, req);
            return Ok(data);
        }
    }
}
