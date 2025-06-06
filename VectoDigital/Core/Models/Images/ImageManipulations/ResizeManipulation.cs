using VectoDigital.Core.Interfaces;

namespace VectoDigital.Core.Models.Images.ImageManipulations
{
    public class ResizeManipulation(int width, int height) : IImageManipulation
    {
        private readonly int _width = width;
        private readonly int _height = height;

        public byte[] Apply(byte[] image)
        {
            //do resize
            return image;
        }
    }
}
