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

            var imageProcessor = new ImageProcessor();
            if (request.RotationAngle.HasValue)
            {
                imageProcessor.AddManipulation(new RotateManipulation(request.RotationAngle.Value));
            }
            if (request.ResizeMetrics != null)
            {
                imageProcessor.AddManipulation(new ResizeManipulation(request.ResizeMetrics.Item1, request.ResizeMetrics.Item2));
            }
            if (request.BlurSize.HasValue)
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
