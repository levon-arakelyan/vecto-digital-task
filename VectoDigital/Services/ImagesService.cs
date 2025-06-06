using System.Diagnostics;
using VectoDigital.Core.Entities;
using VectoDigital.Core.Enums;
using VectoDigital.Core.Interfaces;
using VectoDigital.Core.Models.Images;
using VectoDigital.Core.Models.Images.ImageManipulations;

namespace VectoDigital.Services
{
    public class ImagesService : IImagesService
    {
        private readonly string ErrorNotFound = "Image not found with";

        public List<Image> GetImages()
        {
            return Images;
        }

        public Image SetPlugins(int imageId, ImagePlugin[] pluginsIds)
        {
            var image = Get(imageId);
            image.Plugins = pluginsIds.ToList();
            return image;
        }

        public Image Manipulate(int imageId, ImageManipulationRequest request)
        {
            var image = Get(imageId);

            // TODO:
            // better to move this checks to manipluation classes for easy scalability
            // have list of all manipulation classes, iterate over them and call appropriate methods to check and apply manipulation to image

            var imageProcessor = new ImageProcessor();
            if (request.RotationAngle.HasValue && image.Plugins.Contains(ImagePlugin.Rotation))
            {
                imageProcessor.AddManipulation(new RotateManipulation(request.RotationAngle.Value));
            }
            if (request.ResizeMetrics != null && image.Plugins.Contains(ImagePlugin.Resize))
            {
                imageProcessor.AddManipulation(new ResizeManipulation(request.ResizeMetrics.Item1, request.ResizeMetrics.Item2));
            }
            if (request.BlurSize.HasValue && image.Plugins.Contains(ImagePlugin.Blur))
            {
                imageProcessor.AddManipulation(new BlurManipulation(request.BlurSize.Value));
            }
            image.ImageBytes = imageProcessor.Process(image.ImageBytes);

            return image;
        }

        private Image Get(int id)
        {
            var image = Images.FirstOrDefault(x => x.Id == id);
            return image ?? throw new Exception(ErrorNotFound);
        }

        private List<Image> Images => Database.Images;
    }
}
