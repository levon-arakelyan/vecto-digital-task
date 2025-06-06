using VectoDigital.Core.Interfaces;

namespace VectoDigital.Core.Models.Images.ImageManipulations
{
    public class RotateManipulation(float angle) : IImageManipulation
    {
        private readonly float _angle = angle;

        public byte[] Apply(byte[] image)
        {
            //do rotation
            return image;
        }
    }
}
