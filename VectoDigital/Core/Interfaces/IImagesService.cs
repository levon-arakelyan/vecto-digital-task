using VectoDigital.Core.Entities;
using VectoDigital.Core.Enums;
using VectoDigital.Core.Models.Images;

namespace VectoDigital.Core.Interfaces
{
    public interface IImagesService
    {
        List<Image> GetImages();
        Image SetPlugins(int imageId, ImagePlugin[] pluginsIds);
        Image Manipulate(int imageId, ImageManipulationRequest request);
    }
}
