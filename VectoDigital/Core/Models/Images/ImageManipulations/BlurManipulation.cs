using VectoDigital.Core.Interfaces;

namespace VectoDigital.Core.Models.Images.ImageManipulations
{
    public class BlurManipulation(int blurSize) : IImageManipulation
    {
        private readonly int _blurSize = blurSize;

        public byte[] Apply(byte[] image)
        {
            // do blur
            return image;
        }
    }
}
